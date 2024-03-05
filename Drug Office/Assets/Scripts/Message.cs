[System.Serializable]
public class Message
{
    public string subject;
    public string content;
    public bool hasBeenRead;

    public Message(string subject, string content)
    {
        this.subject = subject;
        this.content = content;
        this.hasBeenRead = false;
    }
}
