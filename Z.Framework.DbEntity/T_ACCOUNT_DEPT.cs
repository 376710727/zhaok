namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ACCOUNT_DEPT
    {
        public int ID { get; set; }

        public int? User_id { get; set; }

        public int? Dept_id { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual T_ACCOUNT T_ACCOUNT { get; set; }

        public virtual T_DEPT T_DEPT { get; set; }
    }
}
