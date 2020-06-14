namespace GymMarombex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alunos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alunos()
        {
            AlunoAula = new HashSet<AlunoAula>();
            Avaliacoes = new HashSet<Avaliacoes>();
        }

        [Key]
        public int AlunoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string CPF { get; set; }

        [Required]
        [StringLength(50)]
        public string RG { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataUltimoAcesso { get; set; }

        public int MelhorDiaMesPagmto { get; set; }        

        public DateTime? DataUltimoPagmto { get; set; }

		public DateTime? DataProximoPagmto { get; set; }

        public double? ValorTotalPago { get; set; }

        public int? QtdParcelas { get; set; }

        public double? ValorParcela { get; set; }

        public int? NumeroParcelaAtual { get; set; }

		[StringLength(500)]
		public string FeriasDescricaoMotivo { get; set; }

		public DateTime? FeriasDataInicio { get; set; }

		public DateTime? FeriasDataFim { get; set; }

        public bool Ativo { get; set; }

        public int PlanoID { get; set; }

        public int FormaPagmtoID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlunoAula> AlunoAula { get; set; }

        public virtual FormasPagmtos FormasPagmtos { get; set; }

        public virtual Planos Planos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avaliacoes> Avaliacoes { get; set; }
    }
}
