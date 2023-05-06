namespace ConciergeBackend.Logic.Interfaces
{
    public interface IHostLogic
    {
        Task DeleteHost(Models.Host audit);
        Task<Models.Host> GetHostById(int id);
        Task<IEnumerable<Models.Host>> GetHosts();
        Task PostHost(Models.Host audit);
        Task UpdateHost(Models.Host audit);
    }
}