using System.Linq;
using System.Web.Mvc;
using GymMarombex.DAL;
using GymMarombex.Models;

namespace GymMarombex.Controllers {
  public class LoginController : Controller {

	private EFContext db = new EFContext();

	// GET: Login
	public ActionResult Index() {
	  return View();
	}

	// POST: Login/Authorize
	[HttpPost]
	public ActionResult Authorize(Login login) {
	  Alunos aluno = null;
	  Funcionarios funcionario = null;

	  aluno = db.Alunos.Where(w => w.Login == login.UserName && w.Senha == login.Password).FirstOrDefault();

	  if (aluno == null) {
		funcionario = db.Funcionarios.Where(w => w.Login == login.UserName && w.Senha == login.Password).FirstOrDefault();
	  }

	  if (aluno == null && funcionario == null) {
		login.LoginErrorMessage = "O usuário ou senha digitado está errado!";
		return View("Index", login);
	  } else {
		Session["userID"] = aluno != null ? aluno.AlunoID : funcionario.FuncionarioID;
	  }

	  return RedirectToAction("Index", "Funcionarios");
	}

	// GET: Login/LogOut
	public ActionResult LogOut() {
	  Session.Abandon();
	  return RedirectToAction("Login");
	}
  }
}
