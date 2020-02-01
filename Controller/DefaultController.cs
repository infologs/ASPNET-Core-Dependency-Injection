using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirstCoreWebApplication.Interface;

namespace MyFirstCoreWebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public readonly IOptions<AppConfiguration> options;
        public readonly ILog Log;
        public DefaultController(IOptions<AppConfiguration> _options, ILog log)
        {            
            options = _options;
            Log = log;
        }

        [HttpGet]
        public string get()
        {
            Log.WriteLog(); // Will create a single instance for the scopped service and use that instance             
            
            //Enable this method only for testing the scopped service.
            Log.WriteLog(); // for calling second time the same instance will be used for the scopped instance.

            GetNewMethod(1, 1);

            return string.Format("ConnectionString: {0} \n Interval: {1} \n ApplicationName: {2}", options.Value.ConnectionString, options.Value.Interval, options.Value.ApplicationName); 
        }

        [HttpGet]
        [Route("GetService")]
        public string GetMethod(int data, [FromServices] ILog _tempLog)
        {
            _tempLog.WriteLog("Method1");

            _tempLog.WriteLog("Method2");

            Log.WriteLog();

            return "";
        }

        [HttpGet]
        [Route("GetServices")]
        public string GetNewMethod(int d1, int d2)
        {
            var services = this.HttpContext.RequestServices;
            ILog _log = (ILog)services.GetService(typeof(ILog));
            _log.WriteLog();
            _log.WriteLog();

            return "";
        }

    }
}