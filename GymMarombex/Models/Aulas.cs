namespace GymMarombex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aulas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aulas()
        {
            AlunoAula = new HashSet<AlunoAula>();
        }

        [Key]
        public int AulaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public int DuracaoMinutos { get; set; }

        [Required]        
        public int DiasDaSemana { get; set; }

        public int InstrutorID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlunoAula> AlunoAula { get; set; }

		[ForeignKey("InstrutorID")]
        public virtual Funcionarios Funcionarios { get; set; }
    }
}
