using log4net;
using PolyusGeo.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MyBlog.Controllers
{
    public class AbstractController : Controller
    {

        static protected readonly ILog _logger = LogManager.GetLogger("Logger");

        protected IUnitOfWork _unitOfWork { get; set; }

        public IDictionary<string, object> actionParams { get; set; }

        public AbstractController (IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.actionParams = filterContext.ActionParameters;

            _unitOfWork.BeginTransaction();
        }
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                    _unitOfWork.Commit();
            }
        

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            string message = e.Message;
            if (e.InnerException != null)
            {
                message = message + " " + e.InnerException.Message;
            }

            if (e.GetType() == typeof(DbEntityValidationException))
            {
                DbEntityValidationException dbEx = e as DbEntityValidationException;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message = message + "," + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            var args = string.Join(",", filterContext.RouteData.Values.Select(x => x.Key + " = " + x.Value));
            var parameters = new JavaScriptSerializer().Serialize(this.actionParams);

            message = message + e.StackTrace;
            _logger.Fatal(createRecord("Exception"
                    , ControllerContext.Controller.GetType().Name
                    , filterContext.Result.ToString()
                    , args + parameters
                    , message));

            throw new Exception(message);
        }
    
        protected virtual string createRecord(string head, string className, string methodName, string args, string body = "")
        {

            string result = string.Format(@"{0,15}:{1:yyyy\/MM\/dd hh:mm:ss K}-{2}:{3}-User:{4} -Args: {5} - {6}",
                head,
                DateTime.UtcNow,
                className,
                methodName,
                HttpContext.User.Identity.Name,
                args,
                body);
            return result;
        }

    }

}