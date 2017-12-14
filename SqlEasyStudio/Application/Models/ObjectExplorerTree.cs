using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.Application.Models
{
    public class ObjectExplorerTree
    {
        public List<ObjectExplorerItem> Items { get; set; }
        public ObjectExplorerTree()
        {
            Items = new List<ObjectExplorerItem>();
        }

    }
}
