namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        currencyID = c.Int(nullable: false, identity: true),
                        table = c.String(),
                        currency = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.currencyID);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        rateID = c.Int(nullable: false, identity: true),
                        mid = c.Single(nullable: false),
                        bid = c.Single(nullable: false),
                        ask = c.Single(nullable: false),
                        effectiveDate = c.String(),
                        Currency_currencyID = c.Int(),
                    })
                .PrimaryKey(t => t.rateID)
                .ForeignKey("dbo.Currencies", t => t.Currency_currencyID)
                .Index(t => t.Currency_currencyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "Currency_currencyID", "dbo.Currencies");
            DropIndex("dbo.Rates", new[] { "Currency_currencyID" });
            DropTable("dbo.Rates");
            DropTable("dbo.Currencies");
        }
    }
}
