using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.UI.Models
{
    public enum NodeType
    {
        database,
        connection,
        folder
    }

    public class NodeInfo
    {
        public NodeType Type { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

    }
}
