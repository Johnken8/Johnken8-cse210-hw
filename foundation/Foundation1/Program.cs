using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _commentText;
    }
}

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _lengthInSeconds;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

public class Program
{
    public static void Main()
    {
        // Create video objects
        Video pythonTutorial = new Video("Python Programming for Beginners", "CodeMaster", 600);
        Video webDevelopment = new Video("Full Stack Web Development", "TechPro", 900);
        Video dataScience = new Video("Introduction to Data Science", "DataExpert", 750);

        // Create and add comments for first video
        pythonTutorial.AddComment(new Comment("JohnDev", "This helped me understand Python basics!"));
        pythonTutorial.AddComment(new Comment("LearnerX", "Great explanations of variables and functions."));
        pythonTutorial.AddComment(new Comment("PythonNewbie", "Can you make more videos on OOP?"));

        // Create and add comments for second video
        webDevelopment.AddComment(new Comment("WebBuilder", "Excellent coverage of frontend frameworks!"));
        webDevelopment.AddComment(new Comment("CodeStudent", "The backend section was very informative."));
        webDevelopment.AddComment(new Comment("FullStackDev", "Would love to see more about API design."));

        // Create and add comments for third video
        dataScience.AddComment(new Comment("DataAnalyst", "Clear explanation of statistical concepts."));
        dataScience.AddComment(new Comment("MLEnthusiast", "The machine learning intro was perfect."));
        dataScience.AddComment(new Comment("BigDataPro", "Please cover more pandas tutorials."));

        // Create list of videos
        List<Video> videos = new List<Video> { pythonTutorial, webDevelopment, dataScience };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine("Video Details:");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            Console.WriteLine("\n-------------------\n");
        }
    }
}