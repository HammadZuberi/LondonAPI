using LondonAPI.Models;

namespace LondonAPI.Service
{
    public interface IRoomService
    {
        Task<Room> GetRoomAsyncId(Guid id);
        Task<List<Room>> GetRoomAsync();
    }
}
