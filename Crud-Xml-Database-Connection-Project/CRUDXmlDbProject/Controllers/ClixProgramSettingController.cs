using Clix_ProgramSetting.Common.RequestModel;
using Clix_ProgramSetting.Common.ResponseModel;
using Clix_ProgramSetting.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clix_ProgramSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClixProgramSettingController : ControllerBase
    {
        
        private readonly IProgramSettingSL _programSettingSL;
        private readonly ILogger<ClixProgramSettingController> _logger;

        public ClixProgramSettingController(IProgramSettingSL programSettingSL, ILogger<ClixProgramSettingController> logger)
        {
            _logger = logger;
            _programSettingSL = programSettingSL;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginResponse response = null;
            try
            {
                _logger.LogInformation($"Login API Calling => {JsonConvert.SerializeObject(request)}");
                response = await _programSettingSL.Login(request);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Login Error => {ex}");
            }
            return Ok();
        }
    }
}
