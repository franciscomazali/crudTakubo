namespace DadosCrud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class funcionario
    {
        public int id { get; set; }

        [Required]
        [StringLength(60)]
        public string nome { get; set; }

        public DateTime dataNascimento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cpf { get; set; }

        public int? cidade { get; set; }

        public virtual cidade cidade1 { get; set; }
    }
}
