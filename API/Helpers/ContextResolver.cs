using System;

namespace Dashly.API.Helpers
{
    public class ContextResolver : IContextResolver
    {
        public ContextResolver()
        {
        }

        public string GetCurrentUser()
        {
            return new Guid("dcdf9e61-cd71-4cb6-8092-21914402ee88").ToString();
        }
    }

    public interface IContextResolver
    {
        string GetCurrentUser();
    }
}