namespace GoodReads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDetails",
                c => new
                    {
                        BookName = c.String(nullable: false, maxLength: 128),
                        BookId = c.Int(nullable: false),
                        Author = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.BookName);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        BookName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookDetails", t => t.BookName)
                .Index(t => t.BookName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "BookName", "dbo.BookDetails");
            DropIndex("dbo.Genres", new[] { "BookName" });
            DropTable("dbo.Users");
            DropTable("dbo.Genres");
            DropTable("dbo.BookDetails");
        }
    }
}
