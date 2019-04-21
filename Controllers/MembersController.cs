using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MacApi.Models;
using MacApi.Data;

namespace MacApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberContext membersContext;

        public MembersController(MemberContext context) {
            membersContext = context;
        }
        public List<Member> Members = new List<Member>();

        // GET api/members
        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get() {
            var members = membersContext.Member.ToList();
            // Members.Add(new Member() {
            //     Id = 1,
            //     Name = "MemberName"
            // });
            return members;
        }

        // GET api/members/5
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            var member = membersContext.Member.FirstOrDefault(m => m.Id == id);
            return member;
        }

        // POST api/members
        [HttpPost]
        public void Post([FromBody] Member member)
        {
            membersContext.Member.Add(member);
            membersContext.SaveChanges();
        }

        // PUT api/members/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var member = membersContext.Member.FirstOrDefault(m => m.Id == id);
            if(member == null) {
                throw new Exception("Provided member id not found");
            }
            member.Name = value;
            membersContext.SaveChanges();
        }

        // DELETE api/members/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var member = membersContext.Member.FirstOrDefault(m => m.Id == id);
            if(member == null) {
                throw new Exception("Provided member id not found");
            }
            membersContext.Member.Remove(member);
            membersContext.SaveChanges();
        }
    }
}
