using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clix_ProgramSetting.Common.ResponseModel
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public int UserID { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
    }
}
