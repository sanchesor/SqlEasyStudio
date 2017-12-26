using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.UI.Model
{
    public interface IMenuItemCollection<T> : ICollection<T> where T : IMenuItem
    {
    }
}
