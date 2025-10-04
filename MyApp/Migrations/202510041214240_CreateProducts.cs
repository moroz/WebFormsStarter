namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(maxLength: 50),
                        ImageUrl = c.String(maxLength: 255),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .Index(t => t.SKU, unique: true);

            Sql("alter table \"Products\" add constraint \"Products_Price_NonNegative\" check (\"Price\" >= 0)");
        }
        
        public override void Down()
        {
            DropIndex("public.Products", new[] { "SKU" });
            DropTable("public.Products");
        }
    }
}
