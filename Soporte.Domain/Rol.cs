using System;
using System.Collections.Generic;

namespace Soporte.Domain;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? ModificadoPor { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
