namespace MessageBoard.Voting.Redis
{
    internal static class Mappings
    {
        public static string MapKey(string id) => $"voting:{id}";
    }
}