namespace GymMarombex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlunoAula")]
    public partial class AlunoAula
    {
		[Key]
        public int AlunoAulaID { get; set; }

        public int AulaID { get; set; }

        public int AlunoID { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual Aulas Aulas { get; set; }
    }
}
