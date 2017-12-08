using SqlEasyStudio.UI.Presenters;
using SqlEasyStudio.UI.Views;
using System;
using System.Windows.Forms;
using SqlEasyStudio.UI.Models;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.UI.Forms.Implementation;

namespace SqlEasyStudio.UI.Forms
{
    public partial class ObjectExplorerForm : Form, IObjectExplorerView
    {
        private ObjectExplorerPresenter presenter;

        public event EventHandler TreeMouseClick;
        public event EventHandler Loaded;

        public IUITreeNodeCollection<UITreeNode> Nodes => new UITreeNodeCollection(_tree.Nodes);

        public ObjectExplorerForm()
        {
            InitializeComponent();

            VisibleChanged += ObjectExplorerForm_VisibleChanged;
            _tree.MouseClick += _tree_MouseClick;            

            presenter = new ObjectExplorerPresenter(this);
        }

        bool _isLoaded = false;

        

        private void ObjectExplorerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                Loaded?.Invoke(sender, e);
                _isLoaded = true;
            }
        }

        private void _tree_MouseClick(object sender, MouseEventArgs e)
        {
            TreeMouseClick?.Invoke(sender, e);
        }

    }
}
