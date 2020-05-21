using System;
using System.ComponentModel.DataAnnotations;

namespace GymMarombex.Models {
  public class AvisoFerias {
	[Key]
	public int AvisoFeriasID { get; set; }
	public string DescricaoMotivo { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataFim { get; set; }
  }
}