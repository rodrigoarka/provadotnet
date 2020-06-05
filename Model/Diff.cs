namespace ProAgil.API.Model
{
    public class Diff
    {
        public int diffId { get; set; }
        public string jsonArchiveLeft { get; set; }
        public string jsonArchiveRight { get; set; }
        public string jsonArchiveResult { get; set; }

    }
}