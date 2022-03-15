using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.IO;
using System.Linq;

namespace TEKenable.ProjectTemplate.Services
{
    /// <summary>
    /// http://www.oakwoodinsights.com/adding-log4net-mvc-site/
    /// CREATE TABLE [dbo].[Log4Net] (
    /// [ID] [int] primary key IDENTITY (1, 1) NOT NULL ,
    /// [Date] [datetime] NOT NULL ,
    /// [Thread] [varchar] (255) NOT NULL ,
    /// [Level] [varchar] (10) NOT NULL ,
    /// [Logger] [varchar] (1000) NOT NULL ,
    /// [Message] [varchar] (4000) NOT NULL ,
    /// [Exception] [varchar] (4000) NOT NULL
    /// ) ON [PRIMARY]
    /// </summary>
    public static class Log4NetManager
    {
        public static void InitializeLog4Net()
        {
            //initialize the log4net configuration based on the log4net.config file
            XmlConfigurator.ConfigureAndWatch(new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + @"\Log4Net.config"));

            Hierarchy hier = log4net.LogManager.GetRepository() as Hierarchy;
            if (hier != null)
            {
                // Get ADONetAppender by name
                AdoNetAppender adoAppender = (from appender in hier.GetAppenders()
                                              where appender.Name.Equals("DbAppender", StringComparison.InvariantCultureIgnoreCase)
                                              select appender).FirstOrDefault() as AdoNetAppender;

                // Change only when the auto setting is set
                if (adoAppender != null && adoAppender.ConnectionString.Contains("{auto}"))
                {
                    adoAppender.ConnectionString = GetEntitiyConnectionStringFromWebConfig();

                    //refresh settings of appender
                    adoAppender.ActivateOptions();

                }
            }
        }

        private static string GetEntitiyConnectionStringFromWebConfig()
        {
            return ConfigurationManager.ConnectionStrings["ProjectTemplateDBContext"].ConnectionString;
        }

        private static string ExtractConnectionStringFromEntityConnectionString(string entityConnectionString)
        {
            // create a entity connection string from the input
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);

            // read the db connectionstring
            return entityBuilder.ProviderConnectionString;
        }
    }
}
