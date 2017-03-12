namespace SharpForum.Data
{
    public class Data
    {
        private static SharpForumContext context;

        public static SharpForumContext Context => context ?? (context = new SharpForumContext());
    }
}