using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Ticket
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int EstadoId { get; set; }

    public int PrioridadId { get; set; }

    public int ClienteId { get; set; }

    public int ProyectoId { get; set; }

    public int? DesarrolladorId { get; set; }

    public int? Qaid { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaCierre { get; set; }

    public int? TicketDerivadoDe { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario? Desarrollador { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<HistorialEstado> HistorialEstados { get; set; } = new List<HistorialEstado>();

    public virtual ICollection<Ticket> InverseTicketDerivadoDeNavigation { get; set; } = new List<Ticket>();

    public virtual Prioridad Prioridad { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual Usuario? Qa { get; set; }

    public virtual ICollection<SeguimientoTiempo> SeguimientoTiempos { get; set; } = new List<SeguimientoTiempo>();

    public virtual Ticket? TicketDerivadoDeNavigation { get; set; }
}
