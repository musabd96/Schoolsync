
namespace Application.Dtos.MediatR
{
    public class OperationResult<T>
    {
        public T? Result { get; set; }
        public required bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
