using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Framework.DbEntity
{
    public class CoreDbInitialiser: DropCreateDatabaseIfModelChanges<zEntity>
    {
        protected override void Seed(zEntity context)
        {
            context.T_ACCOUNT.Add(new T_ACCOUNT()
            {
                ID=1,
                Account_Name = "zk",
                Account_Pwd = "	202cb962ac59075b964b07152d234b70",
                Is_Valid = true,
                Is_Deleted = false,               
            });
            context.T_ACCOUNT_INFO.Add(new T_ACCOUNT_INFO()
            {
                ID = 1,
                User_id = 1,
                User_Name = "Mr. Z",
                User_Code = "0001",
                Is_Deleted = false,
                Create_Time = DateTime.Now
            });
            context.T_ACCOUNT_ROLES.Add(new T_ACCOUNT_ROLES()
            {
                ID = 1,
                User_Id = 1,
                Level = 999,
                Create_Time = DateTime.Now
            });

            base.Seed(context);
        }
    }
}
