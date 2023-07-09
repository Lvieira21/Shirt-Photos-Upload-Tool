namespace TShirt.Photos.App.Application.Services;

using FluentValidation.Results;

public class ResultService
{
    //TODO: Maybe use Exception Handling
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<ErrorValidation> Errors { get; set; }

    public static ResultService RequestError(string message, ValidationResult result)
    {
        return new()
        {
            IsSuccess = false,
            Message = message,
            Errors = result.Errors
                .Select(x => new ErrorValidation{Field = x.PropertyName, Message = x.ErrorMessage})
                .ToList(),
        };
    }

    public static ResultService<T> RequestError<T>(string message, ValidationResult result)
    {
        return new()
        {
            IsSuccess = false,
            Message = message,
            Errors = result.Errors
                .Select(x => new ErrorValidation{Field = x.PropertyName, Message = x.ErrorMessage})
                .ToList(),
        };
    }

    public static ResultService Fail(string message) => new() { IsSuccess = false, Message = message };
    public static ResultService<T> Fail<T>(string message) => new() { IsSuccess = false, Message = message };

    public static ResultService Ok(string message) => new() { IsSuccess = true, Message = message };
    public static ResultService<T> Ok<T>(T data) => new() { IsSuccess = true, Data = data };

}

public class ResultService<T> : ResultService
{
    public T Data { get; set; }
}
