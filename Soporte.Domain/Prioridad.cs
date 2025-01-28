using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Prioridad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
