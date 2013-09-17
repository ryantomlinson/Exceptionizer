using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Business.Domain;
using Environment = Exceptionizer.Business.Domain.Environment;

namespace Exceptionizer.WebApi.Controllers
{
    public class ExceptionController : ApiController
    {
	    private readonly IExceptionService exceptionService;

	    public ExceptionController(IExceptionService exceptionService)
	    {
		    this.exceptionService = exceptionService;
	    }

	    // GET api/exception
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/exception/5
		public ExceptionizerMessage Get(string productid)
        {
	        var exception = new ExceptionizerMessage();

	        exception.ClientSource = new ClientSource
		        {
			        Name = "local",
			        Url = "http://ryantomlinson.com",
			        Version = "0.1"
		        };
	        exception.Environment = new Environment
		        {
			        OperatingSystem = "windows",
			        Url = "http://exceptionizer.com",
			        ProductVersion = "1.0.0",
			        SourceEnvironment = "production"
		        };
	        exception.UserInformation = new UserInformation
		        {
			        UserEmail = "tomlinsonryan@gmail.com",
			        UserId = "1235",
			        UserName = "ryan.tomlinson"
		        };
	        exception.Exceptions = new List<ExceptionizerException>()
		        {
			        new ExceptionizerException()
				        {
					        Message = "something gone wrong like",
					        StackTrace = "this be the stacktracez",
					        Type = "this be the type"
				        }
		        };
			exceptionService.Add(exception);
            return exception;
        }

        // POST api/exception
        public void Post([FromBody]string value)
        {
        }

        // PUT api/exception/5
        public void Put(ExceptionizerMessage message)
        {

        }
    }
}
