using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcSite.Domain.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Post> PostRepo { get; }
        IGenericRepository<Forum> ForumRepo { get; }
        IGenericRepository<Member> MemberRepo { get; }
        void Save();
    }
}
