using System.Threading.Tasks;

namespace BE.Contracts
{
    public interface INotificationService<T> where T: class
    {
        Task<bool> Send(T message);
    }
}
