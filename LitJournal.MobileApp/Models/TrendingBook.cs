using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitJournal.MobileApp.Models
{
    public class TrendingBook
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string CoverUrl { get; set; } = "";
        public double Rating { get; set; }
        public int ReadersCount { get; set; }
        public string Genre { get; set; } = "";
        public int TrendingRank { get; set; }
    }
}
