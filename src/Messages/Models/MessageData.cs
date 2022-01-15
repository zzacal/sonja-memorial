namespace SonjaMemorial.Messages;
public class MessageData: IMessage {
  public MessageData(string body) {
    Body = body;
    Created = DateTime.Now;
  }
  public string Body { get; set; }
  public DateTime Created { get; set; }
}
