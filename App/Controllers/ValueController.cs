using Microsoft.AspNetCore.Mvc;
namespace TimesGroupon.Controllers
{
    [ApiController]
    [Route("/api/value")]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        [Route("getvalue")]
        public string GetValue()
        {
            return "hello world";
        }

        [HttpPost]
        [Route("gree")]
        public string Gree(string name)
        {
            return $"hello {name}";
        }
    }
}