namespace MyMvcSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Username = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Member", t => t.Member_MemberId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Username = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Member", t => t.Member_MemberId)
                .Index(t => t.Member_MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Member_MemberId", "dbo.Member");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "Member_MemberId", "dbo.Member");
            DropIndex("dbo.Post", new[] { "Member_MemberId" });
            DropIndex("dbo.Comment", new[] { "Member_MemberId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropTable("dbo.Post");
            DropTable("dbo.Member");
            DropTable("dbo.Comment");
        }
    }
}
