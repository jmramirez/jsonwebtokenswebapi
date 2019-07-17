using JsonWebTokensWebApi.Infrastructure;
using JsonWebTokensWebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using System.Web.Http;

namespace JsonWebTokensWebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFatory;
        private ApplicationUserManager _AppUserManager = null;

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public BaseApiController() { }

        protected ModelFactory TheModelFatory
        {
            get
            {
                if(_modelFatory == null)
                {
                    _modelFatory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFatory;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if(result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if(result.Errors != null)
                {
                    foreach(string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if (ModelState.IsValid)
                {
                    // No Modelstate errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }
            }
            return null;
        }
    }
}