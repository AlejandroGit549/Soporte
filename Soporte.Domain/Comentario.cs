using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Comentario
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int UsuarioId { get; set; }

    public string Comentario1 { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
