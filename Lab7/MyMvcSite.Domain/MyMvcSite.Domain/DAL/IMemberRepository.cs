using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.DAL
{
    public interface IMemberRepository : IDisposable
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int MemberId);
        void InsertMember(Member member);
        void DeleteMember(int MemberID);
        void UpdateMember(Member member);
        void Save();

        


        
      
    }
}