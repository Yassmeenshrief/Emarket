namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "product_id", "dbo.Product");
            DropPrimaryKey("dbo.Cart");
            AddPrimaryKey("dbo.Cart", new[] { "added_at", "product_id" });
            AddForeignKey("dbo.Cart", "product_id", "dbo.Product", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "product_id", "dbo.Product");
            DropPrimaryKey("dbo.Cart");
            AddPrimaryKey("dbo.Cart", "product_id");
            AddForeignKey("dbo.Cart", "product_id", "dbo.Product", "id");
        }
    }
}
