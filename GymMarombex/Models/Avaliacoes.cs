namespace GymMarombex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avaliacoes
    {
        [Key]
        public int AvaliacaoID { get; set; }

        [StringLength(5000)]
        public string InfoAnamnese { get; set; }

        [StringLength(5000)]
        public string ExameDobrasCutaneas { get; set; }

        [StringLength(5000)]
        public string ExameErgometrico { get; set; }

        public DateTime DataRealizacao { get; set; }

        public int AlunoID { get; set; }

        public int FisioterapeutaID { get; set; }

        public virtual Alunos Alunos { get; set; }

		[ForeignKey("FisioterapeutaID")]
        public virtual Funcionarios Funcionarios { get; set; }
    }
}
