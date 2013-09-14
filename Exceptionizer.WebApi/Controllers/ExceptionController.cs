using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Business.Domain;

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
        public string Get(string productid)
        {
            return "value";
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
