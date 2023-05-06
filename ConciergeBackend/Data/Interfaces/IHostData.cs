namespace ConciergeBackend.Data.Interfaces
{
    public interface IHostData
    {
        Task DeleteHost(Models.Host host, bool local);
        Task<Models.Host> GetHostById(int id);
        Task<IEnumerable<Models.Host>> GetHosts();
        Task PostHost(Models.Host host, bool local);
        Task UpdateHost(Models.Host host, bool local);
    }
}
