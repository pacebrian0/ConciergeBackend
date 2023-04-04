using Microsoft.AspNetCore.Mvc;
using Net.Codecrete.QrCodeGenerator;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        // GET: api/<QRCodeController>
        [HttpGet]
        public IActionResult Get()
        {
            var qr = QrCode.EncodeText("Hello, world!", QrCode.Ecc.Medium);
            string svg = qr.ToSvgString(4);

            // Return the SVG string as the API response
            return Content(svg, "image/svg+xml");
        }

        // GET api/<QRCodeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QRCodeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QRCodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QRCodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
