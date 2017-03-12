namespace SharpForum.Services
{
    using SharpForum.Data;

    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }

        protected SharpForumContext Context { get; }
    }
}