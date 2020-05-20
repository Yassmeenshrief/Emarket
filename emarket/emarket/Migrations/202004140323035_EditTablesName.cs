namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTablesName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Products", newName: "Product");
            AlterColumn("dbo.Product", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "image", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "description", c => c.String());
            AlterColumn("dbo.Product", "image", c => c.String());
            AlterColumn("dbo.Product", "name", c => c.String());
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
