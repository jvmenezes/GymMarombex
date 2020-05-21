using System;
using System.ComponentModel.DataAnnotations;

namespace GymMarombex.Models {
  public class Perfis {
	[Key]
	public int PerfilID { get; set; }
	public string Descricao { get; set; }
  }
}