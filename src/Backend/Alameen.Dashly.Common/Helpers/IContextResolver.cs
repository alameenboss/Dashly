namespace Dashly.API.Helpers
{
    public interface IContextResolver
    {
        string GetCurrentUser();
    }
}