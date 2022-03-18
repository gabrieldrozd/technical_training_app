using System.ComponentModel.DataAnnotations;

namespace Cinema.Domain;

public class Result
{
    private Result(bool isSuccess, string message, IEnumerable<Error> errors)
    {
        IsSuccess = isSuccess;
        Message = message;
        Errors = errors;
    }

    public string Message { get; }
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
    public IEnumerable<Error> Errors { get; }

    public static Result Fail(string message)
        => new Result(false, message, Enumerable.Empty<Error>());

    // TODO: Errors jakis problem pokazuje, tak jakby w ValidationResult nie było listy errorów
    // public static Result Fail(ValidationResult validationResult)
    //     => new Result(
    //         false,
    //         string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
    //         validationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage))
    //     );

    public static Result Ok()
        => new Result(false, "", Enumerable.Empty<Error>());

    public class Error
    {
        public Error(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public string PropertyName { get; }
        public string Message { get; }
    }
}