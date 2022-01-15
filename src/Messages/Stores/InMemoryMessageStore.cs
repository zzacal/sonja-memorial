namespace SonjaMemorial.Messages;

public class InMemoryMessageStore : IMessageStore
{
  private List<MessageData> _messages = new List<MessageData>();
  public void Add(MessageData message)
  {
    _messages.Add(message);
  }

  public IEnumerable<MessageData> GetAll()
  {
    return _messages;
  }
}
