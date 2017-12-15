using SqlEasyStudio.Domain.Enums;
using System.Collections.Generic;

namespace SqlEasyStudio.Domain
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
