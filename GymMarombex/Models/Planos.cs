using System;
using System.ComponentModel.DataAnnotations;

namespace GymMarombex.Models {
  public class Planos {
	[Key]
	public int PlanoID { get; set; }
	public string Descricao { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }
  }
}