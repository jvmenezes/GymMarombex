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

	public DbSet<AlunoAula> AlunoAula { get; set; }
	public DbSet<Alunos> Alunos { get; set; }
	public DbSet<Aulas> Aulas { get; set; }
	public DbSet<Avaliacoes> Avaliacoes { get; set; }
	public DbSet<FormasPagmtos> FormasPagmtos { get; set; }
	public DbSet<Funcionarios> Funcionarios { get; set; }
	public DbSet<Perfis> Perfis { get; set; }
	public DbSet<Planos> Planos { get; set; }
  }
}