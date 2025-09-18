using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitJournal.MobileApp.Models
{
    public static class FeedUtilities
    {
        public static string FormatCount(int count)
        {
            if (count >= 1000000)
                return $"{count / 1000000.0:0.0}M";
            if (count >= 1000)
                return $"{count / 1000.0:0.0}K";
            return count.ToString();
        }

        public static string GetTimeAgo(DateTime createdAt)
        {
            var timeSpan = DateTime.Now - createdAt;

            if (timeSpan.TotalMinutes < 1)
                return "just now";
            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes}m";
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours}h";
            if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays}d";
            if (timeSpan.TotalDays < 30)
                return $"{(int)(timeSpan.TotalDays / 7)}w";
            return createdAt.ToString("MMM dd");
        }

        public static string GetActionText(FeedItemType type)
        {
            return type switch
            {
                FeedItemType.FinishedReading => "finished reading",
                FeedItemType.StartedReading => "started reading",
                FeedItemType.AddedToLibrary => "added to library",
                FeedItemType.RatedBook => "rated",
                FeedItemType.ReviewedBook => "reviewed",
                FeedItemType.CreatedReadingGoal => "set a reading goal for",
                FeedItemType.JoinedBookClub => "joined book club",
                _ => "interacted with"
            };
        }
    }
}
