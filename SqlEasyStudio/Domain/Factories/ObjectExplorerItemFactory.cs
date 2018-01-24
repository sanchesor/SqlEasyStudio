using SqlEasyStudio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Domain.Factories
{
    public class ObjectExplorerItemFactory
    {
        public ObjectExplorerItem Create(ObjectExplorerItemType itemType)
        {
            switch(itemType)
            {
                case ObjectExplorerItemType.Connection:
                    return new ConnectionItem() { ItemType = itemType };
                case ObjectExplorerItemType.Connections:
                    return new ConnectionsItem() { ItemType = itemType };
            }
            throw new Exception("Invalid object explorer item type.");
        }
    }
}
