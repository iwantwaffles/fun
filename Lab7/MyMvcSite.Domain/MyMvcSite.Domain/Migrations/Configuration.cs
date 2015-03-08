namespace MyMvcSite.Domain.Migrations
{
    using MyMvcSite.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyMvcSite.Domain.DAL.ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MyMvcSite.Domain.DAL";
        }

        protected override void Seed(MyMvcSite.Domain.DAL.ForumContext context)
        {
            var members = new List<Member>
            {
            new Member{MemberID=1,UserName="UserName1",Password="password1",Name="Joe",Email="username1@gmail.com"},
            new Member{MemberID=2,UserName="UserName2",Password="password2",Name="Bob",Email="username2@gmail.com"},
            new Member{MemberID=3,UserName="UserName3",Password="password3",Name="Job",Email="username3@gmail.com"},
            new Member{MemberID=4,UserName="UserName4",Password="password4",Name="Boj",Email="username4@gmail.com"},
            new Member{MemberID=5,UserName="UserName5",Password="password5",Name="Boe",Email="username5@gmail.com"}
            };
            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();
            var forums = new List<Forum>
            {
            new Forum{ForumID=1,Title="Anime",Description="Talk about all and everything Anime"},
            new Forum{ForumID=2,Title="Video Games",Description="Talk about all and everything Video Games"}
            };

            forums.ForEach(s => context.Forums.Add(s));
            context.SaveChanges();
            var topics = new List<Topic>
            {
            new Topic{TopicID=1,Title="Chemistry",Subject="Subject",Member="",CreationDate=DateTime.Parse("2005-09-01"),LastUpdated=DateTime.Parse("2005-10-01")},
            new Topic{TopicID=2,Title="Chemistry",Subject="Subject",Member="",CreationDate=DateTime.Parse("2005-09-02"),LastUpdated=DateTime.Parse("2005-10-02")},
            new Topic{TopicID=3,Title="Chemistry",Subject="Subject",Member="",CreationDate=DateTime.Parse("2005-09-03"),LastUpdated=DateTime.Parse("2005-10-03")},
            new Topic{TopicID=4,Title="Chemistry",Subject="Subject",Member="",CreationDate=DateTime.Parse("2005-09-04"),LastUpdated=DateTime.Parse("2005-10-04")},
            new Topic{TopicID=5,Title="Chemistry",Subject="Subject",Member="",CreationDate=DateTime.Parse("2005-09-05"),LastUpdated=DateTime.Parse("2005-10-05")}
            };
            topics.ForEach(s => context.Topics.Add(s));
            context.SaveChanges();
            var posts = new List<Post>
            {
            new Post{PostID=1,Body="This is a test",MemberID="1",CreationDate=DateTime.Parse("2005-09-01"),LastUpdated=DateTime.Parse("2005-10-01")},
            new Post{PostID=2,Body="This is a test",MemberID="1",CreationDate=DateTime.Parse("2005-09-02"),LastUpdated=DateTime.Parse("2005-10-02")},
            new Post{PostID=3,Body="This is a test",MemberID="2",CreationDate=DateTime.Parse("2005-09-03"),LastUpdated=DateTime.Parse("2005-10-03")},
            new Post{PostID=4,Body="This is a test",MemberID="2",CreationDate=DateTime.Parse("2005-09-04"),LastUpdated=DateTime.Parse("2005-10-04")},
            new Post{PostID=5,Body="This is a test",MemberID="2",CreationDate=DateTime.Parse("2005-09-05"),LastUpdated=DateTime.Parse("2005-10-05")}
            };
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();
        }
    }
}
