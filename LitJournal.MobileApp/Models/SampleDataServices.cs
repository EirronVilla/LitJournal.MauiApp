namespace LitJournal.MobileApp.Models
{
        public static class SampleDataService
        {
            public static List<TrendingBook> GetSampleTrendingBooks()
            {
                return new List<TrendingBook>
            {
                new() {
                    Id = "1", Title = "The Seven Husbands of Evelyn Hugo", Author = "Taylor Jenkins Reid",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1618151455i/32620332.jpg",
                    Rating = 4.6, ReadersCount = 890000, Genre = "Romance", TrendingRank = 1
                },
                new() {
                    Id = "2", Title = "Project Hail Mary", Author = "Andy Weir",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1597695864i/54493401.jpg",
                    Rating = 4.5, ReadersCount = 456000, Genre = "Sci-Fi", TrendingRank = 2
                },
                new() {
                    Id = "3", Title = "The Midnight Library", Author = "Matt Haig",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1602190253i/52578297.jpg",
                    Rating = 4.2, ReadersCount = 723000, Genre = "Fiction", TrendingRank = 3
                },
                new() {
                    Id = "4", Title = "Klara and the Sun", Author = "Kazuo Ishiguro",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1603206535i/54120408.jpg",
                    Rating = 4.1, ReadersCount = 234000, Genre = "Literary", TrendingRank = 4
                },
                new() {
                    Id = "5", Title = "The Invisible Life of Addie LaRue", Author = "V.E. Schwab",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1584633432i/50623864.jpg",
                    Rating = 4.4, ReadersCount = 567000, Genre = "Fantasy", TrendingRank = 5
                },
                new() {
                    Id = "6", Title = "The Guest List", Author = "Lucy Foley",
                    CoverUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1577342320i/52656911.jpg",
                    Rating = 4.0, ReadersCount = 312000, Genre = "Thriller", TrendingRank = 6
                }
            };
            }

            public static List<FeedItem> GenerateFeedItems(int page, int count)
            {
                var items = new List<FeedItem>();
                var random = new Random();

                // Add advertisement every 5-7 items
                for (int i = 0; i < count; i++)
                {
                    var globalIndex = (page - 1) * count + i;

                    // Insert ads occasionally
                    if (globalIndex > 0 && globalIndex % (random.Next(5, 8)) == 0)
                    {
                        items.Add(GenerateAdvertisement());
                    }

                    // Stop generating after page 5 to simulate end of feed
                    if (page > 5) break;

                    items.Add(GenerateActivityItem(globalIndex));
                }

                return items;
            }

            private static FeedItem GenerateActivityItem(int index)
            {
                var random = new Random(index); // Use index as seed for consistency
                var activityTypes = Enum.GetValues<FeedItemType>().Where(t => t != FeedItemType.Advertisement).ToArray();
                var type = activityTypes[random.Next(activityTypes.Length)];

                var users = new[]
                {
                ("Emma Chen", "https://images.unsplash.com/photo-1494790108755-2616b69e9c06?w=100&h=100&fit=crop&crop=face"),
                ("Alex Rodriguez", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=100&h=100&fit=crop&crop=face"),
                ("Sarah Johnson", "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&h=100&fit=crop&crop=face"),
                ("Michael Kim", "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=100&h=100&fit=crop&crop=face"),
                ("Jessica Wilson", "https://images.unsplash.com/photo-1544725176-7c40e5a71c5e?w=100&h=100&fit=crop&crop=face"),
                ("David Brown", "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&h=100&fit=crop&crop=face")
            };

                var books = new[]
                {
                "The Seven Husbands of Evelyn Hugo",
                "Project Hail Mary",
                "The Midnight Library",
                "Klara and the Sun",
                "The Invisible Life of Addie LaRue",
                "The Guest List",
                "Malibu Rising",
                "The Thursday Murder Club",
                "Where the Crawdads Sing",
                "Normal People"
            };

                var descriptions = type switch
                {
                    FeedItemType.ReviewedBook => new[]
                    {
                    "This book completely changed my perspective on life. The character development was incredible!",
                    "Couldn't put it down! The plot twists kept me guessing until the very end.",
                    "Beautiful writing style, though the pacing was a bit slow in the middle.",
                    "One of the best books I've read this year. Highly recommend to everyone!",
                    "The ending left me speechless. Still thinking about it days later."
                },
                    FeedItemType.FinishedReading => new[]
                    {
                    "What an incredible journey! Time to find my next read.",
                    "Finally finished this masterpiece. Worth every page!",
                    "That ending though... 😭",
                    "Book #15 of the year completed! 📚",
                    "Another amazing book checked off my reading list!"
                },
                    _ => new[] { "" }
                };

                var user = users[random.Next(users.Length)];
                var book = books[random.Next(books.Length)];
                var description = descriptions.Length > 1 ? descriptions[random.Next(descriptions.Length)] : "";

                return new FeedItem
                {
                    Id = $"feed-{index}",
                    Type = type,
                    UserName = user.Item1,
                    UserAvatarUrl = user.Item2,
                    BookTitle = book,
                    Description = description,
                    ImageUrl = type == FeedItemType.ReviewedBook && random.Next(3) == 0 ?
                        $"https://picsum.photos/400/300?random={index}" : "",
                    CreatedAt = DateTime.Now.AddHours(-random.Next(1, 72)),
                    LikesCount = random.Next(0, 500),
                    CommentsCount = random.Next(0, 50),
                    IsLiked = random.Next(4) == 0,
                    IsOnline = random.Next(3) == 0
                };
            }

            private static FeedItem GenerateAdvertisement()
            {
                var ads = new[]
                {
                new {
                    Title = "Kindle Unlimited",
                    Description = "Read unlimited books for just $9.99/month. Start your free trial today!",
                    CTA = "Try Free",
                    Image = "https://images.unsplash.com/photo-1481627834876-b7833e8f5570?w=300&h=200&fit=crop"
                },
                new {
                    Title = "BookClub Premium",
                    Description = "Join thousands of readers in our exclusive book discussions and author events.",
                    CTA = "Join Now",
                    Image = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=300&h=200&fit=crop"
                },
                new {
                    Title = "Speed Reading Course",
                    Description = "Double your reading speed in just 30 days. Learn the techniques that work!",
                    CTA = "Learn More",
                    Image = "https://images.unsplash.com/photo-1456513080510-7bf3a84b82f8?w=300&h=200&fit=crop"
                }
            };

                var random = new Random();
                var ad = ads[random.Next(ads.Length)];

                return new FeedItem
                {
                    Id = $"ad-{Guid.NewGuid()}",
                    Type = FeedItemType.Advertisement,
                    Title = ad.Title,
                    Description = ad.Description,
                    CallToAction = ad.CTA,
                    ImageUrl = ad.Image,
                    CreatedAt = DateTime.Now
                };
            }
        }
    }
