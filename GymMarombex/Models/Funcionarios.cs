namespace GymMarombex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Funcionarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
        {
            Aulas = new HashSet<Aulas>();
            Avaliacoes = new HashSet<Avaliacoes>();
        }

        [Key]
        public int FuncionarioID { get; set; }

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

        [Required]
        [StringLength(500)]
        public string TiposDeAtividades { get; set; }

        public int PerfilID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aulas> Aulas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avaliacoes> Avaliacoes { get; set; }

        public virtual Perfis Perfis { get; set; }
    }
}
