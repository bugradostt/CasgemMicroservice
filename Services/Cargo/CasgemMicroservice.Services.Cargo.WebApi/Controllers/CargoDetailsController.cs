using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoDetailGet(int id)
        {
            var foundId = _cargoDetailService.TGetById(id);
            return Ok(foundId);
        }

        [HttpPost]
        public IActionResult CargoDetailCreate(CargoDetail p)
        {
             _cargoDetailService.TInsert(p);
            return Ok("Ekleme işlemi yapıldı");
        }

        [HttpPut]
        public IActionResult CargoDetailUpdate(CargoDetail p)
        {
            _cargoDetailService.TUpdate(p);
            return Ok("Güncelleme işlemi yapıldı");
        }

        [HttpDelete]
        public IActionResult CargoDetailDetele(CargoDetail p)
        {
            _cargoDetailService.TDelete(p);
            return Ok("Silme işlemi yapıldı");
        }
    }
}
