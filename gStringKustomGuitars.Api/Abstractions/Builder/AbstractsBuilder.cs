using gStringKustomGuitars.Api.Controllers.Base;

namespace gStringKustomGuitars.Api.Abstractions.Builder
{
    public abstract class AbstractBuilder
    {
        protected IAptConnection aptConnection;

        public AbstractBuilder(IAptConnection aptConnection)
        {
            this.aptConnection = aptConnection;
        }
    }
}
