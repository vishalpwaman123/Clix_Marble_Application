using Clix_ProgramSetting.Common.RequestModel;
using Clix_ProgramSetting.Common.ResponseModel;
using Clix_ProgramSetting.Repositories.Interface;
using CRUDXmlDbProject.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Clix_ProgramSetting.Repositories.Service
{
    public class ProgramSettingRL : IProgramSettingRL
    {
        private readonly ILogger<ProgramSettingRL> _logger;
        private readonly IConfiguration _configuration;
/*        private readonly ClixProgramSettingProcessor _clixProgramSettingProcessor;*/
        private int ConnectionTimeOut = 180;

        public ProgramSettingRL(ILogger<ProgramSettingRL> logger, IConfiguration configuration/*, ClixProgramSettingProcessor clixProgramSettingProcessor*/)
        {
            _logger = logger;
            _configuration = configuration;
/*            _clixProgramSettingProcessor = clixProgramSettingProcessor;*/
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
             LoginResponse response = new LoginResponse();
            response.IsSuccess = true;
            int status = 0;
            string SqlQuery = null, Password = null;
            MySqlConnection sqlConnection = null;
            MySqlCommand sqlCommand = null;

            try
            {
                string sqlConnectionString = _configuration["ConnectionStrings:DBConnectionString"];
                sqlConnection = new MySqlConnection(sqlConnectionString);
                if (sqlConnection != null)
                {
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        await sqlConnection.OpenAsync();
                    }

                    SqlQuery = SqlQueries.Login;
                    sqlCommand = new MySqlCommand(SqlQuery, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlCommand.Parameters.AddWithValue("#UserName", request.UserName);
/*                    Password = _clixProgramSettingProcessor.Encrypt(request.Password);*/
/*                    sqlCommand.Parameters.AddWithValue("#Password", Password);*/
                    using (DbDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            await dataReader.ReadAsync();
                            response.UserID = Convert.ToInt32(dataReader["UserID"]);
                            response.EmailID = Convert.ToString(dataReader["EmailID"]);
                            response.MobileNumber = Convert.ToString(dataReader["MobileNo"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login Error => {ex}");
                response.IsSuccess = false;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    await sqlConnection.DisposeAsync();
                }
            }
            return response;
        }
   
    }
}
