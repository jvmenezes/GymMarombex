using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMarombex.Models {
  public class Usuarios {
	[Key]
	public int UsuarioID { get; set; }
	public string Nome { get; set; }
	public string CPF { get; set; }
	public string RG { get; set; }
	public string Endereco { get; set; }
	public string Login { get; set; }
	public string Senha { get; set; }
	public DateTime DataCadastro { get; set; }
	public DateTime DataUltimoAcesso { get; set; }
	public int PerfilID { get; set; }
	[ForeignKey("PerfilID")]
	public virtual Perfis Perfis { get; set; }

	public int DadoFinanceiroID { get; set; }
	[ForeignKey("DadoFinanceiroID")]
	public virtual DadoFinanceiros DadoFinanceiros { get; set; }
  }
}