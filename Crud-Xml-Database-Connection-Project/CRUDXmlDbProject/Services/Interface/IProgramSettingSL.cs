using Clix_ProgramSetting.Common.RequestModel;
using Clix_ProgramSetting.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clix_ProgramSetting.Services.Interface
{
    public interface IProgramSettingSL
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
