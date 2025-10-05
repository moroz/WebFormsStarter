using System;
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
            context.Products.AddOrUpdate(new Product[]
            {
                new Product
                {
                    ProductId = new Guid("0199b327-17b7-7e22-8926-c35f6d19a1e8"),
                    Title = "Wrangler GREENSBORO Sunset Rinse W34 L32",
                    SKU = "112357414 W34 L32",
                    Price = 56.29M,
                    Description = "Wrangler Greensboro 803 Regular Straight Sunset Rinse W34 L32",
                    ImageUrl = "https://a.allegroimg.com/original/111327/73f12ec0425ab72d4cb0821314e1",
                },
                new Product
                {
                    ProductId = new Guid("0199b32b-32ef-7676-804f-f2206b8c2d92"),
                    Title = "Wrangler LARSTON Rodeo FREE TO STRETCH W32 L32",
                    SKU = "5401139119734 W32 L32",
                    Description = "Wrangler Larston 812 Slim Tapered FREE TO STRETCH Midnight Rodeo W32 L32",
                    Price = 47.05M,
                    ImageUrl = "https://a.allegroimg.com/original/114ba9/1f6db55d4a8faf676810614e2c0b",
                }
            });
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