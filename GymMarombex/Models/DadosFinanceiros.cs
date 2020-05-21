using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMarombex.Models {
  public class DadoFinanceiros {
	[Key]
	public int DadoFinanceiroID { get; set; }
	public double ValorTotal { get; set; }
	public int NumeroParcelaAtual { get; set; }
	public int MelhorDiaMesPagmto { get; set; }
	public DateTime DataPrimeiroPagmto { get; set; }
	public DateTime DataUltimoPagmto { get; set; }
	public DateTime DataRealizacao { get; set; }
	public double ValorJaPago { get; set; }
	public double ValorParcela { get; set; }
	public int QtdParcelas { get; set; }

	public int PlanoID { get; set; }
	[ForeignKey("PlanoID")]
	public virtual Planos Planos { get; set; }

	public int FormaPagmtoID { get; set; }
	[ForeignKey("FormaPagmtoID")]
	public virtual FormasPagmtos FormasPagmtos { get; set; }

	public int AvisoFeriasID { get; set; }
	[ForeignKey("AvisoFeriasID")]
	public virtual AvisoFerias AvisoFerias { get; set; }
  }
}