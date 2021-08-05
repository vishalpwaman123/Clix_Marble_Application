using Clix_ProgramSetting.Common.RequestModel;
using Clix_ProgramSetting.Common.ResponseModel;
using Clix_ProgramSetting.Repositories.Interface;
using Clix_ProgramSetting.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clix_ProgramSetting.Services.Service
{
    public class ProgramSettingSL : IProgramSettingSL
    {
        private readonly ILogger<ProgramSettingSL> _logger;
        private readonly IProgramSettingRL _programSettingRL;
        public ProgramSettingSL(ILogger<ProgramSettingSL> logger, IProgramSettingRL programSettingRL)
        {
            _logger = logger;
            _programSettingRL = programSettingRL;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = null;
            try
            {
                response = await _programSettingRL.Login(request);                
            }catch(Exception ex)
            {
                _logger.LogError($"Login Services Error => {ex}");
            }
            return response;
        }
    }
}
