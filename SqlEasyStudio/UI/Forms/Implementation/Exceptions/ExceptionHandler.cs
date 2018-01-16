using SqlEasyStudio.Infrastructure.Exceptions;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Windows.Forms;

namespace SqlEasyStudio.UI.Forms.Implementation.Exceptions
{
    [Component]
    public class ExceptionHandler : IExceptionHandler
    {
        public void Handle(string message)
        {
            MessageBox.Show(message, "Something went wrong");
        }
    }
}
