using System.Threading.Tasks;

namespace DreamHome
{
    public interface IUserNotifier
    {
        Task NotifyUser(HomeAd homeAd);
    }
}