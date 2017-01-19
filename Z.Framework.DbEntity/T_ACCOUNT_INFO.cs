namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ACCOUNT_INFO
    {
        public int ID { get; set; }

        public int? User_id { get; set; }

        [Required]
        [StringLength(20)]
        public string User_Name { get; set; }

        [StringLength(50)]
        public string User_Phone { get; set; }

        [StringLength(200)]
        public string User_Address { get; set; }

        [StringLength(200)]
        public string User_Code { get; set; }

        public bool? Is_Deleted { get; set; }

        public DateTime? Create_Time { get; set; }

        public virtual T_ACCOUNT T_ACCOUNT { get; set; }
    }
}
