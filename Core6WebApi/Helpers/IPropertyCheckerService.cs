namespace Core6WebApi.Helpers;
public interface IPropertyCheckerService
{
    bool TypeHasProperties<T>(string? fields);
}
