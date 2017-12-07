using SqlEasyStudio.Application.Interfaces;
using SqlEasyStudio.Application.Models;
using SqlEasyStudio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.Application.Implementation
{
    public class ObjectExplorerLoader : IObjectExplorerLoader
    {
        IConnectionRepository connectionRepository;
        public ObjectExplorerTree Load()
        {
            throw new NotImplementedException();
        }
    }
}
