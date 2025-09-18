using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitJournal.MobileApp.Models
{
    public class FeedItem
    {
        public string Id { get; set; } = "";
        public FeedItemType Type { get; set; }
        public string UserName { get; set; } = "";
        public string UserAvatarUrl { get; set; } = "";
        public string BookTitle { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string CallToAction { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public bool IsLiked { get; set; }
        public bool IsOnline { get; set; }
    }

    public enum FeedItemType
    {
        FinishedReading,
        StartedReading,
        AddedToLibrary,
        RatedBook,
        ReviewedBook,
        CreatedReadingGoal,
        JoinedBookClub,
        Advertisement
    }
}
