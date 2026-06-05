using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }

    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLength() => _lengthSeconds;
    public int GetCommentCount() => _comments.Count;
    public List<Comment> GetComments() => _comments;

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
}