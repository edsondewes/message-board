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
    }
}