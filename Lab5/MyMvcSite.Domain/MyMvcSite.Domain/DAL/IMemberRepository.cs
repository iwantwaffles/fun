using MyMvcSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.DAL
{
    public class IMemberRepository : IDisposable
    {
        IEnumerable<Member> GetMembers();
        Member GetStudentByID(int MemberId);
        void InsertStudent(Member member);
        void DeleteStudent(int MemberID);
        void UpdateStudent(Member member);
        void Save();

        internal object GetMembers()
        {
            throw new NotImplementedException();
        }

        internal Member GetMemberByID(int p)
        {
            throw new NotImplementedException();
        }

        internal void InsertMember(Member member)
        {
            throw new NotImplementedException();
        }

        internal void Save()
        {
            throw new NotImplementedException();
        }

        internal void UpdateMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}