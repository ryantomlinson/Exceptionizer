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

        // For testing purposes only
		public ExceptionizerMessage Get(string productid)
        {
	        var exception = new ExceptionizerMessage();

			exception.ApiKey = "a6584184-14a6-4ddf-a652-0c86ac1d16e0";

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
			try
			{
				exceptionService.Add(exception);
			}
			catch (Exception)
			{
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
					{
						Content = new StringContent("An error occured trying to process your request. Please contact us for details support@exceptionizer.com"),
						ReasonPhrase = "Critical Exception"
					});
			}
			
            return exception;
        }

        // POST api/exception
		public void Post(ExceptionizerMessage message)
        {
        }

        // PUT api/exception/5
        public void Put(ExceptionizerMessage message)
        {
			try
			{
				exceptionService.Add(message);
			}
			catch (Exception)
			{
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent("An error occured trying to process your request. Please contact us for details support@exceptionizer.com"),
					ReasonPhrase = "Critical Exception"
				});
			}
        }
    }
}
