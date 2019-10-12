namespace AttentyPractice.Internals.DAL
{
    public interface IApiAccess
    {
        TResponseDto ExecuteGetEntry<TResponseDto>(string apiRoute);
    }
}