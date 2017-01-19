namespace Z.Framework.DbEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using global::Z.Framework.DbEntity.Z.Framework.DbEntity;

    public partial class zEntity : DbContext
    {
        public zEntity()
            : base("name=zEntity")
        {
        }

        public virtual DbSet<T_ACCOUNT> T_ACCOUNT { get; set; }
        public virtual DbSet<T_ACCOUNT_DEPT> T_ACCOUNT_DEPT { get; set; }
        public virtual DbSet<T_ACCOUNT_INFO> T_ACCOUNT_INFO { get; set; }
        public virtual DbSet<T_ACCOUNT_ROLES> T_ACCOUNT_ROLES { get; set; }
        public virtual DbSet<T_DEPT> T_DEPT { get; set; }
        public virtual DbSet<T_MENU> T_MENU { get; set; }
        public virtual DbSet<T_MENU_INFO> T_MENU_INFO { get; set; }
        public virtual DbSet<T_CONNECTION_LOG> T_CONNECTION_LOG { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CoreDbInitialiser());
            modelBuilder.Entity<T_ACCOUNT>()
                .HasMany(e => e.T_ACCOUNT_INFO)
                .WithOptional(e => e.T_ACCOUNT)
                .HasForeignKey(e => e.User_id);

            modelBuilder.Entity<T_ACCOUNT>()
                .HasMany(e => e.T_ACCOUNT_DEPT)
                .WithOptional(e => e.T_ACCOUNT)
                .HasForeignKey(e => e.User_id);

            modelBuilder.Entity<T_ACCOUNT>()
                .HasMany(e => e.T_ACCOUNT_ROLES)
                .WithOptional(e => e.T_ACCOUNT)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<T_DEPT>()
                .HasMany(e => e.T_ACCOUNT_DEPT)
                .WithOptional(e => e.T_DEPT)
                .HasForeignKey(e => e.Dept_id);

            modelBuilder.Entity<T_MENU>()
                .HasMany(e => e.T_ACCOUNT_ROLES)
                .WithOptional(e => e.T_MENU)
                .HasForeignKey(e => e.Authorize_Menu);

            modelBuilder.Entity<T_MENU>()
                .HasMany(e => e.T_MENU_INFO)
                .WithOptional(e => e.T_MENU)
                .HasForeignKey(e => e.Menu_Id);
        }
    }
}
