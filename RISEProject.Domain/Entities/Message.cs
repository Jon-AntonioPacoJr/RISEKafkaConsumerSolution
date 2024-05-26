namespace RISEProject.Domain.Entities
{
    public class Message
    {
        public string Id { get; private set; }
        public string Content { get; private set; }

        public Message(string id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
