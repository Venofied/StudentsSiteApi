using Microsoft.AspNetCore.Mvc;

namespace WebAPITask_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public Guid GetNewGuid()
        {
            var newGuid = Guid.NewGuid();
            return newGuid;
        }
    }
}
