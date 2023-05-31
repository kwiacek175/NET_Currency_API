namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rates", "Currency_currencyID", "dbo.Currencies");
            RenameColumn(table: "dbo.Rates", name: "Currency_currencyID", newName: "Currency_ID");
            RenameIndex(table: "dbo.Rates", name: "IX_Currency_currencyID", newName: "IX_Currency_ID");
            DropPrimaryKey("dbo.Currencies");
            AddColumn("dbo.Currencies", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Currencies", "currencyID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Currencies", "ID");
            AddForeignKey("dbo.Rates", "Currency_ID", "dbo.Currencies", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "Currency_ID", "dbo.Currencies");
            DropPrimaryKey("dbo.Currencies");
            AlterColumn("dbo.Currencies", "currencyID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Currencies", "ID");
            AddPrimaryKey("dbo.Currencies", "currencyID");
            RenameIndex(table: "dbo.Rates", name: "IX_Currency_ID", newName: "IX_Currency_currencyID");
            RenameColumn(table: "dbo.Rates", name: "Currency_ID", newName: "Currency_currencyID");
            AddForeignKey("dbo.Rates", "Currency_currencyID", "dbo.Currencies", "currencyID");
        }
    }
}
