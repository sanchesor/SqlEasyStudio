using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlEasyStudio.UI.Model;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.Menu;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsMenuItemCollection : IMenuItemCollection<IMenuItem>
    {
        MenuItemCollection _menuItemCollection;
        public FormsMenuItemCollection(MenuItemCollection menuItemCollection)
        {
            _menuItemCollection = menuItemCollection;
        }

        public int Count => _menuItemCollection.Count;

        public bool IsReadOnly => _menuItemCollection.IsReadOnly;

        public void Add(IMenuItem item)
        {
            _menuItemCollection.Add((item as FormsMenuItem).SourceMenuItem);
        }

        public void Clear()
        {
            _menuItemCollection.Clear();
        }

        public bool Contains(IMenuItem item)
        {
            return _menuItemCollection.Cast<MenuItem>().Any(mi => mi.Tag == item);
        }

        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _menuItemCollection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _menuItemCollection.Cast<MenuItem>().Select(mi => mi.Tag as FormsMenuItem).GetEnumerator();
        }

        public bool Remove(IMenuItem item)
        {
            MenuItem menuItem = _menuItemCollection.Cast<MenuItem>().First(mi => mi.Tag == item);
            if (!_menuItemCollection.Contains(menuItem))
                return false;

            _menuItemCollection.Remove(menuItem);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _menuItemCollection.GetEnumerator();
        }
    }
}
