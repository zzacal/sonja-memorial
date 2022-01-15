namespace SonjaMemorial.Messages;
public interface IMessageStore {
    void Add(MessageData message);
    IEnumerable<MessageData> GetAll();
}
