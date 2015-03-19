using MyMvcSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.DAL
{
    public class MessageBoardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MessageBoardContext>
    {
        protected override void Seed(MessageBoardContext context)
        {
            var members = new List<Member>
            {
            new Member{Username="User_1", Password="user1", Email="user1@gmail.com"},
            new Member{Username="User_2", Password="user2", Email="user2@gmail.com"},
            new Member{Username="User_3", Password="user3", Email="user3@gmail.com"},
            new Member{Username="User_4", Password="user4", Email="user4@gmail.com"},
            new Member{Username="User_5", Password="user5", Email="user5@gmail.com"}
            };
            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var posts = new List<Post>
            {
            new Post{PostId=1, Message="I think that programming is fun.", Username="User_1", DatePosted=DateTime.Parse("2005-01-01")},
            new Post{PostId=2, Message="I think that html is the best programming language.", Username="User_1", DatePosted=DateTime.Parse("2005-02-02")},
            new Post{PostId=3, Message="I think that computers are the new man's best friend.", Username="User_1", DatePosted=DateTime.Parse("2005-03-03")},
            new Post{PostId=4, Message="Toilet paper is useless.", Username="User_2", DatePosted=DateTime.Parse("2005-04-04")},
            new Post{PostId=5, Message="Pants are for children.", Username="User_2", DatePosted=DateTime.Parse("2005-05-05")},
            new Post{PostId=6, Message="This site sucks.", Username="User_3", DatePosted=DateTime.Parse("2005-06-06")},
            new Post{PostId=7, Message="The world is coming to an end.", Username="User_4", DatePosted=DateTime.Parse("2005-07-07")},
            new Post{PostId=8, Message="Lets talk about rocks.", Username="User_5", DatePosted=DateTime.Parse("2005-08-08")},
            new Post{PostId=9, Message="Playing with dirt is fun.", Username="User_5", DatePosted=DateTime.Parse("2005-09-09")},
            new Post{PostId=10, Message="I need friends.", Username="User_5", DatePosted=DateTime.Parse("2005-10-10")}
            };
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
            new Comment{Message="Programming sucks.", Username="User_3", DatePosted=DateTime.Parse("2006-01-01"), PostId=1},
            new Comment{Message="I think english is the best language.", Username="User_3", DatePosted=DateTime.Parse("2006-02-02"), PostId=2},
            new Comment{Message="You're a wierdo.", Username="User_3", DatePosted=DateTime.Parse("2006-03-03"), PostId=3},
            new Comment{Message="Toilet paper is my only friend.", Username="User_5", DatePosted=DateTime.Parse("2006-04-04"), PostId=4},
            new Comment{Message="You're useless.", Username="User_2", DatePosted=DateTime.Parse("2006-05-05"), PostId=4},
            new Comment{Message="You suck, I hate you.", Username="User_2", DatePosted=DateTime.Parse("2006-06-06"), PostId=4},
            new Comment{Message="You're coming to an end.", Username="User_3", DatePosted=DateTime.Parse("2006-07-07"), PostId=7},
            new Comment{Message="I'm ending it tonight! jk ;)", Username="User_4", DatePosted=DateTime.Parse("2006-08-08"), PostId=7},
            new Comment{Message="Who needs friends.", Username="User_5", DatePosted=DateTime.Parse("2006-09-09"), PostId=10},
            new Comment{Message="Not me.", Username="User_5", DatePosted=DateTime.Parse("2006-10-10"), PostId=10}
            };
            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }
    }
}