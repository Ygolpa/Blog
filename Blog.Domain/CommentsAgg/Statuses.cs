namespace Blog.Domain.CommentsAgg
{
    public partial class Comment
    {
        public static class Statuses
        {
            public const int New = 1;
            public const int Confirmed = 2;
            public const int Canceled = 3;
        }

    }
}
