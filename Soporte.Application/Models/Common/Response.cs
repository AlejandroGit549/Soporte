namespace Soporte.Application.Models.Common;

public class Response<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? TransactionId { get; set; }
    public short? StatusCode { get; set; }

    public Response()
    {
        Success = true;
        Message = default;
        TransactionId = default;
        Data = typeof(T) == typeof(string) ? (T)(object)string.Empty : default;
    }
    public void AddError(Exception ex)
    {
        Success = false;
        Message = $"error:\"{ex.Message}\", stacktrace:\"{ex.StackTrace}\"";
    }
    public void AddError(string ex)
    {
        Success = false;
        Message = $"error:\"{ex}\", stacktrace:null";
    }
    public void AddError<X>(Response<X> ex) where X : class
    {
        Success = false;
        Message = ex.Message;
    }
}
