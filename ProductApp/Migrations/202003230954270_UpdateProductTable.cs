namespace ProductApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Product", name: "Supplier_SupplierId", newName: "SupplierId");
            RenameIndex(table: "dbo.Product", name: "IX_Supplier_SupplierId", newName: "IX_SupplierId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Product", name: "IX_SupplierId", newName: "IX_Supplier_SupplierId");
            RenameColumn(table: "dbo.Product", name: "SupplierId", newName: "Supplier_SupplierId");
        }
    }
}
