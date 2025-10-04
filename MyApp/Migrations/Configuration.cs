using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using MyApp.Models;

namespace MyApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetHistoryContextFactory("Npgsql", (conn, schema) => new MyHistoryContext(conn, schema));
        }

        protected override void Seed(AppDbContext context)
        {
            // Seed data comes here
        }
    }

    public class MyHistoryContext : HistoryContext
    {
        public MyHistoryContext(DbConnection dbConnection, string defaultSchema)
            : base(dbConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Move the migration history table to schema public
            modelBuilder.Entity<HistoryRow>().ToTable("__MigrationHistory", "public");
        }
    }
}