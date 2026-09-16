using FINOVA.DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.Logging
{
    public interface ILoggingService
    {
        Task LogError(Exception exception, Log log, object moreInfo = null);
        Task LogError(Exception exception, object loggerClass, object moreInfo = null);
        Task LogError(Exception exception, Log log, object loggerClass, object moreInfo = null);
        Task LogError(Exception exception, object loggerClass, IFINOVAServiceUser serviceUser, object moreInfo = null);
        Task LogError(Exception exception, object loggerClass, string moduleName, string title, object moreInfo = null);
        Task LogMessage(string message, IFINOVAServiceUser serviceUser, object moreInfo = null);
        Task LogMessage(Log log, object loggerClass, object moreInfo = null);
        Task LogMessage(string message, IFINOVAServiceUser spineUser, string moduleName, string title, object moreInfo = null);
    }
}
