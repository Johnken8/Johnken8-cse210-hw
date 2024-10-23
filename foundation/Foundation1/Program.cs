using System;
using System.Collections.Generic;

/// <summary>
/// Represents a comment on a YouTube video.
/// Stores information about who made the comment and what they said.
/// </summary>
public class Comment
{
    private string _commenterName;  // Name of the person who made the comment
    private string _commentText;    // The actual comment text

    /// <summary>
    /// Initializes a new comment with the specified commenter name and text.
    /// </summary>
    /// <param name="commenterName">The name of the person making the comment</param>
    /// <param name="commentText">The text content of the comment</param>
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    /// <summary>
    /// Returns the name of the commenter.
    /// </summary>
    public string GetCommenterName()
    {
        return _commenterName;
    }

    /// <summary>
    /// Returns the text of the comment.
    /// </summary>
    public string GetCommentText()
    {
        return _commentText;
    }
}

/// <summary>
/// Represents a YouTube video with its basic information and associated comments.
/// Manages video metadata and a collection of comments on the video.
/// </summary>
public class Video
{
    private string _title;            // Title of the video
    private string _author;           // Creator of the video
    private int _lengthInSeconds;     // Duration of the video in seconds
    private List<Comment> _comments;  // List to store all comments on the video

    /// <summary>
    /// Initializes a new video with the specified title, author, and length.
    /// </summary>
    /// <param name="title">The title of the video</param>
    /// <param name="author">The creator of the video</param>
    /// <param name="lengthInSeconds">The duration of the video in seconds</param>
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    /// <summary>
    /// Adds a new comment to the video's comment list.
    /// </summary>
    /// <param name="comment">The Comment object to add</param>
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    /// <summary>
    /// Returns the total number of comments on the video.
    /// </summary>
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    /// <summary>
    /// Returns the title of the video.
    /// </summary>
    public string GetTitle()
    {
        return _title;
    }

    /// <summary>
    /// Returns the author of the video.
    /// </summary>
    public string GetAuthor()
    {
        return _author;
    }

    /// <summary>
    /// Returns the length of the video in seconds.
    /// </summary>
    public int GetLength()
    {
        return _lengthInSeconds;
    }

    /// <summary>
    /// Returns the list of all comments on the video.
    /// </summary>
    public List<Comment> GetComments()
    {
        return _comments;
    }
}

/// <summary>
/// Main program class that demonstrates the usage of Video and Comment classes.
/// Creates sample videos with comments and displays their information.
/// </summary>
public class Program
{
    public static void Main()
    {
        // Create three different video objects with varying content
        Video pythonTutorial = new Video(
            "Python Programming for Beginners", 
            "CodeMaster", 
            600  // 10 minutes
        );
        
        Video webDevelopment = new Video(
            "Full Stack Web Development", 
            "TechPro", 
            900  // 15 minutes
        );
        
        Video dataScience = new Video(
            "Introduction to Data Science", 
            "DataExpert", 
            750  // 12.5 minutes
        );

        // Add comments to the Python tutorial video
        pythonTutorial.AddComment(new Comment("JohnDev", "This helped me understand Python basics!"));
        pythonTutorial.AddComment(new Comment("LearnerX", "Great explanations of variables and functions."));
        pythonTutorial.AddComment(new Comment("PythonNewbie", "Can you make more videos on OOP?"));

        // Add comments to the web development video
        webDevelopment.AddComment(new Comment("WebBuilder", "Excellent coverage of frontend frameworks!"));
        webDevelopment.AddComment(new Comment("CodeStudent", "The backend section was very informative."));
        webDevelopment.AddComment(new Comment("FullStackDev", "Would love to see more about API design."));

        // Add comments to the data science video
        dataScience.AddComment(new Comment("DataAnalyst", "Clear explanation of statistical concepts."));
        dataScience.AddComment(new Comment("MLEnthusiast", "The machine learning intro was perfect."));
        dataScience.AddComment(new Comment("BigDataPro", "Please cover more pandas tutorials."));

        // Store all videos in a list for easy iteration
        List<Video> videos = new List<Video> { pythonTutorial, webDevelopment, dataScience };

        // Display information for each video and its comments
        foreach (Video video in videos)
        {
            // Display video metadata
            Console.WriteLine("Video Details:");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            
            // Display all comments for this video
            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            
            // Add separator between videos for better readability
            Console.WriteLine("\n-------------------\n");
        }
    }
}