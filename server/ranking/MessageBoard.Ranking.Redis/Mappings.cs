namespace MessageBoard.Ranking.Redis
{
    internal static class Mappings
    {
        public static string MapKey(string optionName) => $"ranking:{optionName}";
    }
}