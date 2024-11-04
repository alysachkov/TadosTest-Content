namespace Content.Domain.Entities
{
    using Enums;
    using System;

    public class Article : Content
    {
        [Obsolete("Only for reflection", true)]
        public Article() { }

        protected internal Article(string name, User creator, string text)
            : base(ContentCategory.Article, name, creator)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));

            Text = text;
        }

        public virtual string Text { get; protected set; }


        public virtual void SetText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));

            Text = text;
        }
    }
}
