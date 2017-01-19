namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ACCOUNT_ROLES
    {
        public int ID { get; set; }

        public int? User_Id { get; set; }

        public int? Authorize_Menu { get; set; }

        public int Level { get; set; }

        public DateTime? Create_Time { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual T_ACCOUNT T_ACCOUNT { get; set; }

        public virtual T_MENU T_MENU { get; set; }
    }
}
