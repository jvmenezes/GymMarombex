using System;
using System.ComponentModel.DataAnnotations;

namespace GymMarombex.Models {
  public class Aulas {
	[Key]
	public int AulaID { get; set; }
	public string Descricao { get; set; }
	public TimeSpan HoraInicio { get; set; }
	public int DuracaoMinutos { get; set; }
	public string DiasDaSemana { get; set; }
}
}