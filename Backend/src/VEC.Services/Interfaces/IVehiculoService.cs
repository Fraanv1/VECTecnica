using System;
using VEC.Domain;
using VEC.Domain.DTOs;

namespace VEC.Services.Interfaces
{
    public interface IVehiculoService
    {
        Task<Vehiculo> AgregarVehiculo(Vehiculo vehiculo);
        Task ModificarVehiculo(VehiculoDto vehiculo);
        Task EliminarVehiculo(int vehiculoId);
        Task<List<Vehiculo>> GetVehiculos();
        Task<Vehiculo> GetVehiculo(int vehiculoId);
    }
}

