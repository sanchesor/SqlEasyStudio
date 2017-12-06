using System;

namespace SqlEasyStudio.Interfaces.Views
{
    public interface IObjectExplorerView
    {
        event EventHandler Loaded;
        event EventHandler TreeMouseClick;        
    }
}
