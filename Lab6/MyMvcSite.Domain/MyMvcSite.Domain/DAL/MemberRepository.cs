using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.DAL
{
    public class MemberRepository: IMemberRepository, IDisposable
    {
        private ForumContext context;

        public MemberRepository(ForumContext c)
        {
            this.context = c;
        }

        public IEnumerable<Member> GetMembers()
        {
            return context.Members.ToList();
        }

        public Member GetMemberByID(int id)
        {
            return context.Members.Find(id);
        }

        public void InsertMember(Member member)
        {
            context.Members.Add(member);
        }

        public void DeleteMember(int memberID)
        {
            Member member = context.Members.Find(memberID);
            context.Members.Remove(member);
        }

        public void UpdateMember(Member member)
        {
            context.Entry(member).State = EntityState.Modified;
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