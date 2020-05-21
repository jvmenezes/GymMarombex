using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GymMarombex.Models;

namespace GymMarombex.DAL {
  public class EFContext : DbContext {
	public EFContext() : base("EFConnectionString") { }

	protected override void OnModelCreating(DbModelBuilder modelBuilder){

	  /*
	   * Por Default o DotNet cria as tabelas no plural, 
	   * então usando essa convenção você faz com que a tabela seja criada exatamente com a nomenclatura da sua classe
	   */
	  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
	  base.OnModelCreating(modelBuilder);
	}

	public DbSet<Aulas> Aulas { get; set; }
	public DbSet<Avaliacoes> Avaliacoes { get; set; }
	public DbSet<AvisoFerias> AvisoFerias { get; set; }
	public DbSet<DadoFinanceiros> DadoFinanceiros { get; set; }
	public DbSet<FormasPagmtos> FormasPagmtos { get; set; }
	public DbSet<Perfis> Perfis { get; set; }
	public DbSet<UsuarioAula> UsuarioAula { get; set; }
	public DbSet<Usuarios> Usuarios { get; set; }
	public DbSet<Planos> Planos { get; set; }
  }
}