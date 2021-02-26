using System.Collections.Generic;

namespace SingleFileProcessDemo.Models
{
    public class PagerModel<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}