using System.Linq;

namespace Videos.Models
{
    public interface IVideoDataSource
    {
        IQueryable<Video> GetAllvideos();
    }
}