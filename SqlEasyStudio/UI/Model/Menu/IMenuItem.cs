using SqlEasyStudio.Infrastructure.Messaging;
using System;

namespace SqlEasyStudio.UI.Model
{
    public interface IMenuItem
    {        
        string Text { get; set; }

        Action CommandHandler {get; set;}
    }
}
