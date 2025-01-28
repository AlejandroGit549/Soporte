using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Proyecto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? ModificadoPor { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
