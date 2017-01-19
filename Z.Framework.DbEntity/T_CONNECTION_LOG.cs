namespace Z.Framework.DbEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    namespace Z.Framework.DbEntity
    {
        public partial class T_CONNECTION_LOG
        {
            public int ID { get; set; }

            [Required]
            [StringLength(32)]
            public string IpAddress { get; set; }

            public DateTime OnConnectedTime { set; get; }

            public DateTime? DisposeTime { set; get; }
        }
    }
}
