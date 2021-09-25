using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CompressedUnbufferedResponse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            HttpContext.Features.Get<IHttpResponseBodyFeature>()?.DisableBuffering();

            using StreamWriter writer = new(HttpContext.Response.Body, Encoding.UTF8, 1024, leaveOpen: true) { NewLine = "\n" };

            await writer.WriteLineAsync("Hello!");
        }
    }
}
