namespace emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "category_id");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_category_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_category_id", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.Products", name: "category_id", newName: "CategoryId");
        }
    }
}
