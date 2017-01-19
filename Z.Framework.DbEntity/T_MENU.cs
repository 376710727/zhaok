namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_MENU()
        {
            T_ACCOUNT_ROLES = new HashSet<T_ACCOUNT_ROLES>();
            T_MENU_INFO = new HashSet<T_MENU_INFO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Menu_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Menu_Code { get; set; }

        public int Menu_Authorize { get; set; }

        public int Parent { get; set; }

        public bool? Is_Valid { get; set; }

        public bool? Is_Deleted { get; set; }

        public int? Category { get; set; }

        public DateTime? Create_Time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ACCOUNT_ROLES> T_ACCOUNT_ROLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_MENU_INFO> T_MENU_INFO { get; set; }
    }
}
