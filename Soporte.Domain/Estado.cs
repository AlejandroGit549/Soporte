using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Estado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? ModificadoPor { get; set; }

    public virtual ICollection<HistorialEstado> HistorialEstadoEstadoAnteriors { get; set; } = new List<HistorialEstado>();

    public virtual ICollection<HistorialEstado> HistorialEstadoEstadoNuevos { get; set; } = new List<HistorialEstado>();

    public virtual ICollection<SeguimientoTiempo> SeguimientoTiempos { get; set; } = new List<SeguimientoTiempo>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
