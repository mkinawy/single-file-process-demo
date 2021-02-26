namespace SingleFileProcessDemo.Models
{
    public class QueryModel
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;

        public int Skip => (Page - 1) * Size;
    }
}