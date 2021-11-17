namespace gStringKustomGuitars.Data.Abstractions
{
    public interface IgStringKustomConnection
    {
        string String { get; }
        void SetString(string connStr);
    }
}