using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class SeguimientoTiempo
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int EstadoId { get; set; }

    public int TiempoEnEstado { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
