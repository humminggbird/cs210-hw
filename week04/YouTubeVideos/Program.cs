using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();


        Video video1 = new Video(
            "Is Africa the Next Silicon Valley?",
            "Tech Untold",
            1380);
        video1.AddComment(new Comment(
            "Kwame",
            "The startup scene in Nairobi and Lagos is growing fast."));
        video1.AddComment(new Comment(
            "Priya",
            "Great breakdown of the challenges and opportunities."));
        video1.AddComment(new Comment(
            "Tomás",
            "Would love a follow-up on funding access for African founders."));
        video1.AddComment(new Comment(
            "Ama",
            "This is the kind of content the world needs to see more of."));
        videos.Add(video1);


        Video video2 = new Video(
            "How to Start Investing on a Small Salary",
            "Money Mindset Africa",
            860);
        video2.AddComment(new Comment(
            "Kofi",
            "Finally someone talking about investing for everyday people."));
        video2.AddComment(new Comment(
            "Beatriz",
            "The compound interest example was really eye-opening."));
        video2.AddComment(new Comment(
            "Yaw",
            "I started a small mutual fund account after watching this."));
        videos.Add(video2);


        Video video3 = new Video(
            "24 Hours in Accra — What No One Tells You",
            "Passport Chronicles",
            1540);
        video3.AddComment(new Comment(
            "Abena",
            "You missed Labadi Beach but still a solid video!"));
        video3.AddComment(new Comment(
            "Marcus",
            "This made me book flights immediately."));
        video3.AddComment(new Comment(
            "Ingrid",
            "The street food segment alone was worth watching."));
        video3.AddComment(new Comment(
            "Nana",
            "Accra always looks better on camera than people expect."));
        videos.Add(video3);


        Video video4 = new Video(
            "Morning Habits That Actually Changed My Life",
            "Live Well Daily",
            695);
        video4.AddComment(new Comment(
            "Grace",
            "I have been doing the 5-minute journaling tip for two weeks now."));
        video4.AddComment(new Comment(
            "Jerome",
            "No fluff, just practical habits — subscribed."));
        video4.AddComment(new Comment(
            "Mei",
            "The part about sleep consistency hit close to home."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            DisplayVideo(video);
        }
    }

    static void DisplayVideo(Video video)
    {

        Console.WriteLine($"Title:    {video.GetTitle()}");
        Console.WriteLine($"Author:   {video.GetAuthor()}");
        Console.WriteLine($"Length:   {video.GetLength()} seconds");
        Console.WriteLine($"Comments: {video.GetCommentCount()}");
        Console.WriteLine("\nComments:");
        foreach (Comment comment in video.GetComments())
        {
            Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
        }
        Console.WriteLine();
    }
}