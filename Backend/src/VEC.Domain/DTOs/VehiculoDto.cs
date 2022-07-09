using System;
namespace VEC.Domain.DTOs
{
	public class VehiculoDto
	{
        public int VehiculoId { get; set; }
        public int CantidadRuedas { get; set; }
        public string TipoVehiculo { get; set; }
        public string Marca { get; set; }
        public int Modelo { get; set; }
        public string Patente { get; set; }
        public string NumeroChasis { get; set; }
        public string KmRecorridos { get; set; }
        public string KmMantenimiento { get; set; }
    }
}

