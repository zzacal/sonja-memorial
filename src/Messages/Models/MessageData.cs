namespace SonjaMemorial.Messages;
public class MessageData : IMessage
{
  public MessageData(string body, DateTime created)
  {
    Body = body;
    Created = created;
  }
  public string Body { get; set; }
  public DateTime Created { get; set; }
}
