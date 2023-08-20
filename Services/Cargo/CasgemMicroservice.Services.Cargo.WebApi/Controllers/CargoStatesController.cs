using CasgemMicroservice.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatesController : ControllerBase
    {
        private readonly ICargoStateService _cargoStateService;

        public CargoStatesController(ICargoStateService cargoStateService)
        {
            _cargoStateService = cargoStateService;
        }

        [HttpGet]
        public IActionResult CargoStateList()
        {
            var values = _cargoStateService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoStateGet(int id)
        {
            var foundId = _cargoStateService.TGetById(id);
            return Ok(foundId);
        }

        [HttpPost]
        public IActionResult CargoStateCreate(CargoState p)
        {
            _cargoStateService.TInsert(p);
            return Ok("Ekleme işlemi yapıldı");
        }

        [HttpPut]
        public IActionResult CargoStateUpdate(CargoState p)
        {
            _cargoStateService.TUpdate(p);
            return Ok("Güncelleme işlemi yapıldı");
        }

        [HttpDelete]
        public IActionResult CargoStateDetele(CargoState p)
        {
            _cargoStateService.TDelete(p);
            return Ok("Silme işlemi yapıldı");
        }
    }
}
