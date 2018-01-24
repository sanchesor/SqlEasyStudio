using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Connections
{
    public interface IConnection
    {
        void Open();
        void StartOpen();
        void Close();

        event EventHandler Opened;
        event EventHandler OpenFailed;
        event EventHandler Closed;

        ConnectionStatus Status { get; }
        
    }
}
