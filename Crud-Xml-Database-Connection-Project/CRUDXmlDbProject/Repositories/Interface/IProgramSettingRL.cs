using Clix_ProgramSetting.Common.RequestModel;
using Clix_ProgramSetting.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clix_ProgramSetting.Repositories.Interface
{
    public interface IProgramSettingRL
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
