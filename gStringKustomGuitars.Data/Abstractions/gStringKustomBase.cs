namespace gStringKustomGuitars.Data.Abstractions
{
    public abstract class gStringKustomBase
    {
        protected IgStringKustomConnection aptConnection;

        public gStringKustomBase(IgStringKustomConnection aptConnection)
        {
            this.aptConnection = aptConnection;
        }
    }
}
