using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMarombex.Models {
  public class UsuarioAula {
	[Key]
	public int UsuarioAulaID { get; set; }

	public int UsuarioID { get; set; }
	[ForeignKey("UsuarioID")]
	public virtual Usuarios Usuarios { get; set; }

	public int AulaID { get; set; }
	[ForeignKey("AulaID")]
	public virtual Aulas Aulas { get; set; }
  }
}