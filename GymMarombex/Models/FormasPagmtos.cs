using System;
using System.ComponentModel.DataAnnotations;

namespace GymMarombex.Models {
  public class FormasPagmtos {
	[Key]
	public int FormaPagmtoID { get; set; }
	public string Descricao { get; set; }
  }
}