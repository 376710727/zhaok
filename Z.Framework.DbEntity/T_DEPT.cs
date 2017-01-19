namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DEPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_DEPT()
        {
            T_ACCOUNT_DEPT = new HashSet<T_ACCOUNT_DEPT>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Dept_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Dept_Code { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? Create_Time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ACCOUNT_DEPT> T_ACCOUNT_DEPT { get; set; }
    }
}
