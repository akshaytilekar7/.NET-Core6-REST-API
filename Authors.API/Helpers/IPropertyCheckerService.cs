namespace Authors.API.Helpers;
public interface IPropertyCheckerService
{
    bool TypeHasProperties<T>(string? fields);
}
