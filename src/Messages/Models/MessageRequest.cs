namespace SonjaMemorial.Messages;
public record MessageRequest : IMessage {
  public MessageRequest() {
    Body = "";
  }

  public string Body { get; set; }
}
