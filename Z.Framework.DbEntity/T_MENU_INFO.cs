namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_MENU_INFO
    {
        public int? Menu_Id { get; set; }

        public string Menu_Icon { get; set; }

        public string Menu_Description { get; set; }

        [Key]
        public string Menu_FilePath { get; set; }

        [StringLength(200)]
        public string Menu_Instance { get; set; }

        [StringLength(200)]
        public string Menu_Route { get; set; }

        [StringLength(200)]
        public string Menu_Url { get; set; }

        public bool? Is_Deleted { get; set; }

        public DateTime? Create_Time { get; set; }

        public int? Create_User { get; set; }

        public virtual T_MENU T_MENU { get; set; }
    }
}
