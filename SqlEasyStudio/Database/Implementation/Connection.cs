using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Data.SqlClient;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace SqlEasyStudio.Database.Implementation
{
    [Component]
    public class Connection : IConnection
    {
        public SqlConnection SourceConnection { get; private set; }

        public ConnectionStatus Status { get; private set; }

        private CancellationTokenSource cancelSource;

        public Connection(SqlConnection conn)
        {
            Status = ConnectionStatus.Closed;
            SourceConnection = conn;

            cancelSource = new CancellationTokenSource();
        }

        public event EventHandler Opened;
        public event EventHandler OpenFailed;
        public event EventHandler Closed;

        public void Open()
        {
            try
            {
                SourceConnection.Open();
                Status = ConnectionStatus.Open;
                Opened?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                Status = ConnectionStatus.Closed;
                OpenFailed?.Invoke(this, EventArgs.Empty);
            }

        }
        public void StartOpen()
        {
            StartOpenAsync();
        }

        //todo: repair DRY violation

        private async void StartOpenAsync()
        {
            try
            {
                Status = ConnectionStatus.Opening;
                await SourceConnection.OpenAsync(cancelSource.Token);

                Status = ConnectionStatus.Open;                
            }
            catch(Exception)
            {
                Status = ConnectionStatus.Closed;                
            }     
            
            if(Status == ConnectionStatus.Open)
                Opened?.Invoke(this, EventArgs.Empty);
            else
                OpenFailed?.Invoke(this, EventArgs.Empty);
        }

        public void Close()
        {
            if (Status == ConnectionStatus.Open)
                SourceConnection.Close();
            else if (Status == ConnectionStatus.Opening)
                cancelSource.Cancel();

            Status = ConnectionStatus.Closed;
            Closed?.Invoke(this, EventArgs.Empty);
        }

    }
}
