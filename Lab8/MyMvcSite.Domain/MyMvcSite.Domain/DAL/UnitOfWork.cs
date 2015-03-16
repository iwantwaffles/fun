using MyMvcSite.Domain.DAL;
using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ForumContext context = new ForumContext();
        private IGenericRepository<Post> postRepo;
        private IGenericRepository<Forum> forumRepo;
        private IGenericRepository<Member> memberRepo;


        public IGenericRepository<Post> PostRepo
        {
            get
            {
                if (this.postRepo == null)
                {
                    this.postRepo = new GenericRepository<Post>(context);
                }
                return postRepo;
            }
        }

        public IGenericRepository<Forum> ForumRepo
        {
            get
            {
                if (this.forumRepo == null)
                {
                    this.forumRepo = new GenericRepository<Forum>(context);
                }
                return forumRepo;
            }
        }

        public IGenericRepository<Member> MemberRepo
        {
            get
            {
                if (this.memberRepo == null)
                {
                    this.memberRepo = new GenericRepository<Member>(context);
                }
                return memberRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}