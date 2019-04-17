using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IQueueManager
    {
        Task AddMessageAsync(string message);
    }
}
