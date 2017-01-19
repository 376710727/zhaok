namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_ACCOUNT()
        {
            T_ACCOUNT_INFO = new HashSet<T_ACCOUNT_INFO>();
            T_ACCOUNT_DEPT = new HashSet<T_ACCOUNT_DEPT>();
            T_ACCOUNT_ROLES = new HashSet<T_ACCOUNT_ROLES>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string Account_Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Account_Pwd { get; set; }

        public DateTime? Create_Time { get; set; }

        [StringLength(20)]
        public string Create_Ip { get; set; }

        public bool? Is_Valid { get; set; }

        public bool? Is_Deleted { get; set; }

        public DateTime? Deleted_Time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ACCOUNT_INFO> T_ACCOUNT_INFO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ACCOUNT_DEPT> T_ACCOUNT_DEPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_ACCOUNT_ROLES> T_ACCOUNT_ROLES { get; set; }
    }
}
