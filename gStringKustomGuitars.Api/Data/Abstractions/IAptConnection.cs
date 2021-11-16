namespace gStringKustomGuitars.Api.Controllers.Base
{
    public interface IAptConnection
    {
        string String { get; }
        void SetString(string connStr);
    }
}