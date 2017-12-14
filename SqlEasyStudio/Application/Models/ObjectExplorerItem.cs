using SqlEasyStudio.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.Application.Models
{
    public class ObjectExplorerItem
    {
        public ObjectExplorerItemType ItemType { get; set; }
        public string Name { get; set; }
        public object Data { get; set; }
        public List<ObjectExplorerItem> Items { get; set; }

        public ObjectExplorerItem()
        {
            Items = new List<ObjectExplorerItem>();
        }
    }
}
