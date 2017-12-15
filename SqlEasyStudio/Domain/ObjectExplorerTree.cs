using System.Collections.Generic;

namespace SqlEasyStudio.Domain
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
