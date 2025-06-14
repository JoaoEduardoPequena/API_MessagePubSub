using Infrastruture.Worker.DTO;
using Infrastruture.Worker.Interfaces;
using Infrastruture.Worker.Setting;
using Microsoft.Extensions.Options;
using NotificadorPedidos.Worker.Interfaces;

namespace NotificadorPedidos.Worker.Process
{
    public class SubscribeMessageProcess : ISubscribeMessageProcess
    {
        private readonly ISendEmailService _emailService;
        private readonly EmailSetting _emailSetting;
        private readonly IRedisService _redisService;
        private readonly RedisSetting _redisSetting;
        private readonly ILogger<SubscribeMessageProcess> _logger;
        public SubscribeMessageProcess(ISendEmailService emailService, IOptions<EmailSetting> emailSetting, IRedisService redisService, IOptions<RedisSetting> redisSetting, ILogger<SubscribeMessageProcess> logger)
        {
            _emailService = emailService;
            _emailSetting = emailSetting.Value;
            _redisService = redisService;
            _redisSetting = redisSetting.Value;
            _logger = logger;
        }

        public async Task SubscribeMessageWork()
        {
            var canal = $"{_redisSetting.Channel}";
            _redisService.Subscribe<MessageDTO>(canal, async (redisMessage) =>
            {
                if (redisMessage is null) return;
                var dtoEmail = new EmailDTO();
                dtoEmail.To = redisMessage.Email;
                dtoEmail.EmailSubject = _emailSetting.EmailSubject;
                dtoEmail.EmailText = redisMessage.Message;
                await _emailService.SendEmailAsync(dtoEmail);
            });

            await Task.CompletedTask;
        }
    }
}
