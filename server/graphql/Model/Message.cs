using System;

namespace MessageBoard.GraphQL.Model
{
    public class Message
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Text { get; set; }

        public Message(long id, DateTime created, string text)
        {
            Id = id;
            Created = created;
            Text = text;
        }
    }
}