using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymMarombex.DAL;
using GymMarombex.Models;

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
