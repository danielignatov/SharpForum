using SharpForum.API.Models.Domain;

namespace SharpForum.API.Data.Repository.Interfaces
{
    public interface ISharpForumData
    {
        public ICategoryRepository Categories { get; }

        public ITopicRepository Topics { get; }

        public IReplyRepository Replies { get; }

        public IUserRepository Users { get; }

        public IGenericRepository<Role> Roles { get; }
    }
}