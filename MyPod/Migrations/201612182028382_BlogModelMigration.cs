namespace MyPod.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogModelMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Post = c.String(),
                        BlogAuthor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.AspNetUsers", t => t.BlogAuthor_Id)
                .Index(t => t.BlogAuthor_Id);
            
            DropTable("dbo.Messages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId);
            
            DropForeignKey("dbo.Blogs", "BlogAuthor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "BlogAuthor_Id" });
            DropTable("dbo.Blogs");
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
