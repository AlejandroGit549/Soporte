using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class HistorialEstado
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int EstadoAnteriorId { get; set; }

    public int EstadoNuevoId { get; set; }

    public DateTime? FechaCambio { get; set; }

    public int UsuarioId { get; set; }

    public virtual Estado EstadoAnterior { get; set; } = null!;

    public virtual Estado EstadoNuevo { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
