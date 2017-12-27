using SqlEasyStudio.Infrastructure.Messaging;

namespace SqlEasyStudio.UI.Model
{
    public interface IMenuItem
    {
        string Text { get; set; }
        ICommand Command { get; set; }
    }
}
