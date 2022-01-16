namespace SonjaMemorial.Messages;
public record MessageRequest : IMessage
{
  public MessageRequest()
  {
    Body = "";
  }

  public bool IsSubmitted { get; set; } = false;
  public string Body { get; set; }
}
