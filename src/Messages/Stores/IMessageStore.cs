namespace SonjaMemorial.Messages;
public interface IMessageStore {
    Task Add(MessageData message);
    Task<IEnumerable<MessageData>> GetAll();
}
