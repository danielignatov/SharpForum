using SharpForum.Domain;
using System.Threading.Tasks;

namespace SharpForum.Repository.Interfaces
{
    public interface ISharpForumData
    {
        public ICategoryRepository Categories { get; }

        public IGenericRepository<Topic> Topics { get; }

        public IGenericRepository<Reply> Replies { get; }

        public Task<bool> SaveAsync();
    }
}