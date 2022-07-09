
using Microsoft.AspNetCore.Mvc;
using VEC.Domain;
using VEC.Domain.DTOs;
using VEC.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VEC.API.Controllers.v1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VehiculoController : ControllerBase
    {
        #region Readonly Fields

        private readonly ILogger<VehiculoController> _logger;
        private readonly IVehiculoService _vehiculoService;

        #endregion

        #region Constructor

        public VehiculoController(ILogger<VehiculoController> logger, IVehiculoService vehiculoService)
        {
            _logger = logger;
            _vehiculoService = vehiculoService;
        }

        #endregion

        #region Methods
        [HttpGet]
        public async Task<List<Vehiculo>> GetVehiculos()
        {
            var vehiculos = await _vehiculoService.GetVehiculos();

            return vehiculos;
        } 

        [HttpGet]
        [Route("GetVehiculo")]
        public async Task<Vehiculo> GetVehiculo(int vehiculoId)
        {
            var vehiculos = await _vehiculoService.GetVehiculo(vehiculoId);

            return vehiculos;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehiculos(int vehiculoId)
        {
            await _vehiculoService.EliminarVehiculo(vehiculoId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddVehiculos(Vehiculo vehiculo)
        {
            await _vehiculoService.AgregarVehiculo(vehiculo);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehiculos(VehiculoDto vehiculoDto)
        {
            await _vehiculoService.ModificarVehiculo(vehiculoDto);
            return Ok();
        }
        #endregion
    }
}

