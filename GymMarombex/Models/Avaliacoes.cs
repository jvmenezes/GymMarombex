using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMarombex.Models {
  public class Avaliacoes {
	[Key]
	public int AvaliacaoID { get; set; }
	public string InfoAnamnese { get; set; }
	public string ExameDobrasCutaneas { get; set; }
	public string ExameErgometrico { get; set; }
	public DateTime DataRealizacao { get; set; }
	public int AlunoID { get; set; }
	[ForeignKey("AlunoID")]
	public virtual Usuarios Alunos { get; set; }

	public int FisioterapeutaID { get; set; }
	[ForeignKey("FisioterapeutaID")]
	public virtual Usuarios Fisioterapeutas { get; set; }
  }
}