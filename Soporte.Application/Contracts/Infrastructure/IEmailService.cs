using Soporte.Application.Models;
using Soporte.Application.Models.Common;

namespace Soporte.Application.Contracts.Infrastructure;

public interface IEmailService : IDisposable
{
    Task<Response<bool>> SendEmail(Email email);
    Task<Response<bool>> SendEmail(Email email, List<FileAttachments>? Attachments = null);
    Task<Response<bool>> SendEmail(Email email, List<byte[]>? Attachments = null, string nombreArchivo = "");
}
