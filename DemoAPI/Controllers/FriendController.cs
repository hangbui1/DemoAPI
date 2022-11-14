using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        List<Friend> Friends = new List<Friend>
        {
            new Friend(1, "Bùi", "Hằng", "Việt Nam", DateTime.Today),
            new Friend(2,"Oleander", "Yuba", "Nigeria", DateTime.Today),
            new Friend(3, "Saffron", "Lawrence", "Lagos", DateTime.Today),
            new Friend(4, "Jadon", "Munonye", "Asaba", DateTime.Today),
            new Friend(5, "Solace", "Okeke", "Oko", DateTime.Today)
        };

        // GET: api/Friend
        [HttpGet]
        public List<Friend> Get()
        {
            return Friends;
        }

        // GET: api/Friend/5
        [HttpGet("{id}", Name = "Get")]
        public Friend Get(int id)
        {
            Friend friend = Friends.Find(f => f.id == id);
            return friend;
        }

        // POST: api/Friend
        [HttpPost]
        public List<Friend> Post([FromBody] Friend friend)
        {
            Friends.Add(friend);
            return Friends;
        }

        // PUT: api/Friend/5
        [HttpPut]
        public List<Friend> Put(int id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = Friends.Find(f => f.id == friend.id);
            int index = Friends.IndexOf(friendToUpdate);

            Friends[index].firstname = friend.firstname;
            Friends[index].lastname = friend.lastname;
            Friends[index].location = friend.location;
            Friends[index].dateOfHire = friend.dateOfHire;

            return Friends;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Friend> Delete(int id)
        {
            Friend friend = Friends.Find(f => f.id == id);
            Friends.Remove(friend);
            return Friends;
        }
    }
}
