namespace SonjaMemorial.Messages;

public class InMemoryMessageStore : IMessageStore
{
  private List<MessageData> _messages = new List<MessageData>();
  public Task Add(MessageData message)
  {
    _messages.Add(message);
    return Task.CompletedTask;
  }

  public Task<IEnumerable<MessageData>> GetAll()
  {
    return Task.FromResult(_messages as IEnumerable<MessageData>);
  }
}
