using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDXmlDbProject.Helper
{
    public class SqlQueries
    {

        static IConfiguration queriesConfig = new ConfigurationBuilder()
            .AddXmlFile("SqlQueries.xml", true, true)
            .Build();

        public static string InsertEmployeeData { get { return queriesConfig["InsertEmployeeData"]; } }

    }
}
