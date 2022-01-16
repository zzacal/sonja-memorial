namespace SonjaMemorial.Messages;
public class MessageViewModel : IMessage 
{
    public IEnumerable<MessageData> Messages { get; set; } =  new List<MessageData>();
    public bool IsSubmitted { get; set; }
    public int Limit { get; set; } = 500;
    public string Body { get; set; }  = "";
}
