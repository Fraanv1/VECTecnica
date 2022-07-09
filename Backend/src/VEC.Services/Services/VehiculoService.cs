using System.Diagnostics.CodeAnalysis;
using VEC.Domain;
using VEC.Domain.DTOs;
using VEC.Domain.Interfaces;
using VEC.Infrastructure;
using VEC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VEC.Services;

public class VehiculoService : IVehiculoService
{
    #region Readonly Fields

    private readonly ApplicationDbContext _context;

    #endregion

    public VehiculoService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Vehiculo> AgregarVehiculo(Vehiculo vehiculo)
    {
        try
        {
            var vehiculoNuevo = new Vehiculo
            {
                CantidadRuedas = vehiculo.CantidadRuedas,
                TipoVehiculo = vehiculo.TipoVehiculo,
                Activo = true,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Patente = vehiculo.Patente,
                Chasis = vehiculo.Chasis,
                KmRecorridos = vehiculo.KmRecorridos,
                KmMantenimiento = vehiculo.KmMantenimiento,
            };

            _context.Vehiculo.Add(vehiculoNuevo);
            await _context.SaveChangesAsync();

            return vehiculoNuevo;
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task ModificarVehiculo(VehiculoDto vehiculo)
    {
        try
        {
            var vehiculoViejo = _context.Vehiculo.Find(vehiculo.VehiculoId);

            if (vehiculoViejo == null)
            {
                throw new Exception("Vehiculo no encontrado");
            }
            else
            {
                vehiculoViejo.CantidadRuedas = vehiculo.CantidadRuedas;
                vehiculoViejo.TipoVehiculo = vehiculo.TipoVehiculo;
                vehiculoViejo.Marca = vehiculo.Marca;
                vehiculoViejo.Modelo = vehiculo.Modelo;
                vehiculoViejo.Patente = vehiculo.Patente;
                vehiculoViejo.Chasis = vehiculo.NumeroChasis;
                vehiculoViejo.KmRecorridos = vehiculo.KmRecorridos;
                vehiculoViejo.KmMantenimiento = vehiculo.KmMantenimiento;
                _context.Vehiculo.Update(vehiculoViejo);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task EliminarVehiculo(int vehiculoId)
    {
        try
        {
            var vehiculo = _context.Vehiculo.Find(vehiculoId);

            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<Vehiculo>> GetVehiculos()
    {
        return await _context.Vehiculo.Where(x => x.Activo == true).ToListAsync();
    }

    public async Task<Vehiculo> GetVehiculo(int vehiculoId)
    {
        return await _context.Vehiculo.Where(x => x.Activo == true && x.VehiculoId == vehiculoId).FirstOrDefaultAsync();
    }
}

