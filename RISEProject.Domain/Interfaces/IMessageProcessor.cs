using RISEProject.Domain.Entities;

namespace RISEProject.Domain.Interfaces
{
    public interface IMessageProcessor
    {
        void Process(Message message);
    }
}
