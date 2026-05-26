using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Classes", "Code Academy", 480);
        video1.AddComment(new Comment("Sam", "This helped me understand classes better."));
        video1.AddComment(new Comment("Jordan", "Great explanation of abstraction."));
        video1.AddComment(new Comment("Emily", "The examples were easy to follow."));

        Video video2 = new Video("Top 10 Study Tips", "Student Success", 620);
        video2.AddComment(new Comment("Michael", "I need to try these tips."));
        video2.AddComment(new Comment("Ashley", "This was really helpful for finals."));
        video2.AddComment(new Comment("Chris", "The time management section was the best."));

        Video video3 = new Video("Beginner Workout Routine", "Fit Life", 755);
        video3.AddComment(new Comment("Taylor", "This workout is perfect for beginners."));
        video3.AddComment(new Comment("Morgan", "I like that no equipment is needed."));
        video3.AddComment(new Comment("Alex", "The instructions were very clear."));

        Video video4 = new Video("Easy Dinner Recipe", "Home Cooking", 530);
        video4.AddComment(new Comment("Rachel", "I made this and it tasted great."));
        video4.AddComment(new Comment("Daniel", "Simple and easy to follow."));
        video4.AddComment(new Comment("Jessica", "I will definitely make this again."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}