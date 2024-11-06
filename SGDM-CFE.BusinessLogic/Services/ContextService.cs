using SGDM_CFE.Model;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class ContextService
    {
        public Context Context { get; }

        public ContextService()
        {
            Context = new Context();
        }
    }
}