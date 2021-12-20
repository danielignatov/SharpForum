using System.Threading.Tasks;

namespace SharpForum.Repository.Interfaces
{
    public interface ISharpForumData
    {
        public ICategoryRepository Categories { get; }

        public Task<bool> CompleteAsync();
    }
}