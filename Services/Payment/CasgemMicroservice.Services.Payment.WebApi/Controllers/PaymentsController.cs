using CasgemMicroservice.Services.Payment.WebApi.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Payment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult PaymnetList()
        {
            var values = _context.PaymentDetails.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult PaymnetCreate(PaymentDetail paymentDetail)
        {
           _context.PaymentDetails.Add(paymentDetail);
            return Ok("Ödeme Yapıldı");
        }
    }
}
