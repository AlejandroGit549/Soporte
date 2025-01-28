using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RolId { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<HistorialEstado> HistorialEstados { get; set; } = new List<HistorialEstado>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual ICollection<Ticket> TicketDesarrolladors { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketQas { get; set; } = new List<Ticket>();
}
