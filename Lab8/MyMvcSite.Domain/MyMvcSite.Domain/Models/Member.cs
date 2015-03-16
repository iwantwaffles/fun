using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.Models
{
    public class Member : IEntityModels
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}