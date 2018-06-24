using System;
using MessageBoard.Messaging.Core;
using StackExchange.Redis;

namespace MessageBoard.Messaging.Redis
{
    internal static class Mappings
    {
        public const string IdKey = "message:id";
        public const string MessageListKey = "messages";

        public const string CreatedEntry = "created";
        public const string TextEntry = "text";

        public static string MapKey(long id) => MapKey(id.ToString());
        public static string MapKey(string id) => $"message:{id}";

        public static Message ToModel(long id, HashEntry[] entries)
        {
            var dictionary = entries.ToDictionary();
            return new Message
            {
                Created = new DateTime((long)dictionary[CreatedEntry], DateTimeKind.Local),
                Id = id,
                Text = dictionary[TextEntry]
            };
        }
    }
}