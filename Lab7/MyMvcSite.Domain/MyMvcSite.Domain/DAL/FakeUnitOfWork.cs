using BookInfo.DAL;
using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.DAL
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Post> postRepo;
        private IGenericRepository<Forum> forumRepo;
        private IGenericRepository<Member> memberRepo;

        private List<Post> posts;
        private List<Forum> forums;
        private List<Member> members;

        public FakeUnitOfWork(List<Post> p = null, List<Forum> f = null, List<Member> m = null)
        {
            if (p == null)
                posts = new List<Post>();
            else
                posts = p;

            if (f == null)
                forums = new List<Forum>();
            else
                forums = f;
            if (m == null)
                members = new List<Member>();
            else
                members = m;
        }

        public IGenericRepository<Models.Post> PostRepo
        {
            get
            {
                if (this.postRepo == null)
                {
                    this.postRepo = new FakeGenericRepository<Post>(posts);
                }
                return postRepo;
            }
        }

        public IGenericRepository<Models.Forum> ForumRepo
        {
            get
            {
                if (this.forumRepo == null)
                {
                    this.forumRepo = new FakeGenericRepository<Forum>(forums);
                }
                return forumRepo;
            }
        }

        public IGenericRepository<Models.Member> MemberRepo
        {
            get
            {
                if (this.memberRepo == null)
                {
                    this.memberRepo = new FakeGenericRepository<Member>(members);
                }
                return memberRepo;
            }
        }

        public void Save()
        {
            // Nothing to do here
        }

        public void Dispose()
        {
            // Nothing to do here
        }
    }
}