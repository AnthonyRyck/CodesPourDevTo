using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerGrpc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutoGrpcUsersController : ControllerBase
    {
        private IDataService DataService;

        public TutoGrpcUsersController(IDataService service)
        {
            DataService = service;
        }


        [HttpGet("count")]
        public int GetCountUser()
        {
            // requête :
            // https://localhost:5001/api/tutogrpcusers/count
            return DataService.GetCountUser();
        }

        [HttpGet("all")]
        public IEnumerable<User> GetUsers()
        {
            // requête :
            // https://localhost:5001/api/tutogrpcusers/all
            return DataService.GetAllUser();
        }

        [HttpGet("user")]
        public User GetUser(string id)
        {
            // requête :
            // https://localhost:5001/api/tutogrpcusers/user?id=61b6c9ceb0b039f7477bedef
            return DataService.GetUser(id);
        }
    }
}
