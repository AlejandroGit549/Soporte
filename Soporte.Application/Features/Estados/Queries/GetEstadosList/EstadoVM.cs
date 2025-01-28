
namespace Soporte.Application.Features.Estados.Queries.GetEstadosList;

public class EstadoVM
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int CreadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? ModificadoPor { get; set; }

    public EstadoVM(int id, string nombre, bool activo, DateTime? fechaCreacion, int creadoPor, DateTime? fechaModificacion, int? modificadoPor)
    {
        Id = id;
        Nombre = nombre;
        Activo = activo;
        FechaCreacion = fechaCreacion;
        CreadoPor = creadoPor;
        FechaModificacion = fechaModificacion;
        ModificadoPor = modificadoPor;
    }
    public EstadoVM()
    {
        
    }
}
