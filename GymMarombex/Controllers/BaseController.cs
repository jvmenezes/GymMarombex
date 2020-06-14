using System.Web.Mvc;

namespace GymMarombex.Controllers {
  public class BaseController : Controller {


	protected override void OnAuthorization(AuthorizationContext filterContext) {
	  prepareVisitorContext();
	  base.OnAuthorization(filterContext);
	}

	public void prepareVisitorContext() { 
	if(Session["userID"] == null) {		
	    Response.Redirect("~/Login/Index");
	}
}
}
}
