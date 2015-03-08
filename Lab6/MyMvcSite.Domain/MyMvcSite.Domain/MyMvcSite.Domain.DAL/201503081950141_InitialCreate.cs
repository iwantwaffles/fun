namespace MyMvcSite.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forum",
                c => new
                    {
                        ForumID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ForumID);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        TopicID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Subject = c.String(),
                        Member = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Forum_ForumID = c.Int(),
                    })
                .PrimaryKey(t => t.TopicID)
                .ForeignKey("dbo.Forum", t => t.Forum_ForumID)
                .Index(t => t.Forum_ForumID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        MemberID = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Topic_TopicID = c.Int(),
                        Member_MemberID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Topic", t => t.Topic_TopicID)
                .ForeignKey("dbo.Member", t => t.Member_MemberID)
                .Index(t => t.Topic_TopicID)
                .Index(t => t.Member_MemberID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Member_MemberID", "dbo.Member");
            DropForeignKey("dbo.Topic", "Forum_ForumID", "dbo.Forum");
            DropForeignKey("dbo.Post", "Topic_TopicID", "dbo.Topic");
            DropIndex("dbo.Post", new[] { "Member_MemberID" });
            DropIndex("dbo.Post", new[] { "Topic_TopicID" });
            DropIndex("dbo.Topic", new[] { "Forum_ForumID" });
            DropTable("dbo.Member");
            DropTable("dbo.Post");
            DropTable("dbo.Topic");
            DropTable("dbo.Forum");
        }
    }
}
