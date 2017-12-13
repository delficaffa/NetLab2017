namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedUser { get; set; }

        [StringLength(50)]
        public string UpdatedUser { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
