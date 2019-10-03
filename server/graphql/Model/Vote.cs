namespace MessageBoard.GraphQL.Model
{
    public class Vote
    {
        public uint Count { get; set; }
        public string OptionName { get; set; }

        public Vote(string optionName, uint count)
        {
            OptionName = optionName;
            Count = count;
        }
    }
}