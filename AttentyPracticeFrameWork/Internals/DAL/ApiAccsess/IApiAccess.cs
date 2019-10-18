using System.Threading.Tasks;

namespace AttentyPractice.Internals.DAL
{
    public interface IApiAccess
    {
        Task<TResponseDto> ExecuteGetEntry<TResponseDto>(string apiRoute);
    }
}