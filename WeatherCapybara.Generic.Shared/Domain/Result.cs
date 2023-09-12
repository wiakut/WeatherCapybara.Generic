namespace WeatherCapybara.Generic.Shared.Domain;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Errors = new[] { error };
    }
    
    protected internal Result(bool isSuccess, Error[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error[] Errors { get; }

    public static Result Success() => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);
    
    public static Result Failure(Error[] errors) => new(false, errors);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static Result<TValue> Failure<TValue>(Error[] errors) => new(default, false, errors);
    public static Result<TValue> Of<TValue>(TValue value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error) => _value = value;
    
    protected internal Result(TValue? value, bool isSuccess, Error[] errors)
        : base(isSuccess, errors) => _value = value;
    
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(TValue value) => Of(value);
    
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> predicate,
        Error error)
    {
        return predicate(value) 
            ? Success(value) 
            : Failure<TValue>(error);
    }
     
    public static Result<TValue> Ensure(
        TValue value,
        params (Func<TValue, bool> predicate, Error error)[] functions)
    {
        var results = new List<Result<TValue>>();
        foreach (var (predicate, error) in functions)
        {
            results.Add(Ensure(value, predicate, error));
        }

        if (results.Any(r => r.IsFailure))
        {
            return Failure<TValue>(
                results
                    .SelectMany(r => r.Errors)
                    .Distinct()
                    .ToArray());
        }

        return Success(results[0].Value);
    }
}