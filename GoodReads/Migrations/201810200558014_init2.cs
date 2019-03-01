namespace GoodReads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "BookName", "dbo.BookDetails");
            DropIndex("dbo.Genres", new[] { "BookName" });
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        BookName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Genres", "BookName");
            AddForeignKey("dbo.Genres", "BookName", "dbo.BookDetails", "BookName");
        }
    }
}
