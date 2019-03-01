namespace GoodReads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookDetails", "Imagepath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookDetails", "Imagepath");
        }
    }
}
