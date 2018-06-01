using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quan.UI.EF
{
    public class DBInitializer : SqliteCreateDatabaseIfNotExists<QuanDbContext>
    {
        public DBInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        protected override void Seed(QuanDbContext context)
        {
           // base.Seed(context);
        }
    }
}