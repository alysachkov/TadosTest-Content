namespace Content.Domain.Entities
{
    using Enums;
    using System;

    public class Video : Content
    {
        [Obsolete("Only for reflection", true)]
        public Video() { }

        protected internal Video(string name, User creator, string url)
            : base(ContentCategory.Video, name, creator)
        {
            SetUrl(url);
        }

        public virtual string Url { get; protected set; }

        public virtual void SetUrl(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
    }
}
