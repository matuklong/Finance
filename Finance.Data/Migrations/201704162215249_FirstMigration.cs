namespace Finance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 50),
                        BankName = c.String(nullable: false, maxLength: 50),
                        AccountAgency = c.String(nullable: false, maxLength: 50),
                        AccountNumber = c.String(nullable: false, maxLength: 50),
                        BalanceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountDescription = c.String(nullable: false, maxLength: 50),
                        LastTransactionDate = c.DateTime(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 50),
                        AccountId = c.Int(nullable: false),
                        TransactionTypeId = c.Int(),
                        TransactionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InclusionDate = c.DateTime(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionDescription = c.String(nullable: false, maxLength: 50),
                        Capitalization = c.Boolean(nullable: false),
                        BalanceBeforeTransaction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountTransfer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.TransactionType", t => t.TransactionTypeId)
                .Index(t => t.AccountId)
                .Index(t => t.TransactionTypeId);
            
            CreateTable(
                "dbo.TransactionType",
                c => new
                    {
                        TransactionTypeId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TransactionTypeId);
            
            CreateTable(
                "dbo.TransactionIdentification",
                c => new
                    {
                        TransactionIdentificationId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 50),
                        TransactionTypeId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        TransactionValue = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransactionIdentificationId)
                .ForeignKey("dbo.TransactionType", t => t.TransactionTypeId)
                .Index(t => t.TransactionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType");
            DropForeignKey("dbo.TransactionIdentification", "TransactionTypeId", "dbo.TransactionType");
            DropForeignKey("dbo.Transaction", "AccountId", "dbo.Account");
            DropIndex("dbo.TransactionIdentification", new[] { "TransactionTypeId" });
            DropIndex("dbo.Transaction", new[] { "TransactionTypeId" });
            DropIndex("dbo.Transaction", new[] { "AccountId" });
            DropTable("dbo.TransactionIdentification");
            DropTable("dbo.TransactionType");
            DropTable("dbo.Transaction");
            DropTable("dbo.Account");
        }
    }
}
