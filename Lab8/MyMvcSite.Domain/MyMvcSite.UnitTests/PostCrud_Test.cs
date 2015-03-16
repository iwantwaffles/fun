using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MyMvcSite.Domain.Models;
using MyMvcSite.Domain.Controllers;
using MyMvcSite.Domain.DAL;

namespace MyMvcSite.UnitTests
{
    [TestClass]
    public class Member_Tests
    {
        [TestMethod]
        public void Create_Member_Test()
        {
            // arrange
            List<Member> members = new List<Member>();
            var target = new MemberController();

            // act
            const string USERNAME = "Joebobby";
            var member = new Member() { UserName = USERNAME };
            target.Create(member);

            // assert
            Assert.AreEqual(USERNAME, members[0].UserName);
        }

        /*[TestMethod]
        public void Delete_Author_Test()
        {
            // arrange
            List<Author> authors = new List<Author>();
            var author = new Author() { Name = "Brian Bird", ID = 1 };
            authors.Add(author);
            const string NAME = "Dr. Seuss";
            author = new Author() { Name = NAME, ID = 2 };
            authors.Add(author);

            var target = new AuthorsCrudController(new FakeAuthorRepository(authors));

            // act
            target.DeleteConfirmed(2);

            // assert
            Assert.AreEqual(1, authors.Count);
            Assert.AreNotEqual(NAME, authors[0].Name);

        }*/
    }
}
