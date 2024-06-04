namespace MyCorePackages.Results.Abstract;

public interface IResult
{
    public bool Success { get; }
    public string Message { get; }
}
