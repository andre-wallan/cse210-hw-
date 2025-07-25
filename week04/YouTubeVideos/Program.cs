using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create video objects
        List<Video> videos = new List<Video>();

        var video1 = new Video("How to Cook Ugandan Rolex", "Chef Mary", 300);
        video1.AddComment(new Comment("Andrew", "This looks so delicious!"));
        video1.AddComment(new Comment("Lydia", "Tried it today and loved it."));
        video1.AddComment(new Comment("Jacob", "Can't wait to make this at home."));
        videos.Add(video1);

        var video2 = new Video("Top 10 Nature Spots in Uganda", "NatureTV", 720);
        video2.AddComment(new Comment("Faith", "So beautiful! Uganda is amazing."));
        video2.AddComment(new Comment("Brian", "Thanks for this guide."));
        video2.AddComment(new Comment("Nina", "We visited #4 last month!"));
        videos.Add(video2);

        var video3 = new Video("Kampala City Tour 2024", "Urban Vibes", 480);
        video3.AddComment(new Comment("Ronnie", "So vibrant and lively."));
        video3.AddComment(new Comment("Hope", "Loved the music in the background."));
        video3.AddComment(new Comment("Martin", "Brings back memories."));
        videos.Add(video3);

        var video4 = new Video("DIY Solar Power Setup", "GreenLife", 610);
        video4.AddComment(new Comment("Susan", "Very informative!"));
        video4.AddComment(new Comment("Peter", "Is it cost-effective in Uganda?"));
        video4.AddComment(new Comment("Joan", "Great explanation, thank you."));
        videos.Add(video4);

        // Display all videos
        foreach (var video in videos)
        {
            video.Display();
        }
    }
}
