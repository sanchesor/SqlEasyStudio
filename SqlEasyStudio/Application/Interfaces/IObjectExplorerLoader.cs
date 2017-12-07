using SqlEasyStudio.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.Application.Interfaces
{
    public interface IObjectExplorerLoader
    {
        ObjectExplorerTree Load();
    }
}
