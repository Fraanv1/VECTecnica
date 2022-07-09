using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VEC.Domain.Interfaces;

namespace VEC.Domain;

public class Vehiculo : IEntity, ISoftDelete
{
    #region Properties

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VehiculoId { get; set; }
    public string TipoVehiculo { get; set; } = null!;
    public int CantidadRuedas { get; set; }
    public string Marca { get; set; } = null!;
    public int Modelo { get; set; }
    public string Patente { get; set; } = null!;
    public string Chasis { get; set; } = null!;
    public string KmRecorridos { get; set; } = null!;
    public string KmMantenimiento { get; set; } = null!;
    public bool Activo { get;  set; }

    #endregion
}

