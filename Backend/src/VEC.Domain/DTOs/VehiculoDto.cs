using System;
namespace VEC.Domain.DTOs
{
	public class VehiculoDto
	{
        public int VehiculoId { get; set; }
        public string TipoVehiculo { get; set; } = null!;
        public int CantidadRuedas { get; set; }
        public string Marca { get; set; } = null!;
        public int Modelo { get; set; }
        public string Patente { get; set; } = null!;
        public string Chasis { get; set; } = null!;
        public string KmRecorridos { get; set; } = null!;
        public string KmMantenimiento { get; set; } = null!;
    }
}

