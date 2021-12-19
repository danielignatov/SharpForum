using System.Threading.Tasks;

namespace SharpForum.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Categories { get; }

        public Task<bool> CompleteAsync();
    }
}