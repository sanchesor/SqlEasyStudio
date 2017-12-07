using SqlEasyStudio.Interfaces.Presenters;
using SqlEasyStudio.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace SqlEasyStudio.UI.Forms
{
    public partial class ObjectExplorerForm : Form, IObjectExplorerView
    {
        private ObjectExplorerPresenter presenter;

        public event EventHandler TreeMouseClick;
        public event EventHandler Loaded;

        public ICollection<Interfaces.Models.TreeNode> Nodes
        {
            get
            {
                foreach(var node in _tree.Nodes)
                {
                    yield return JAK TO SIĘ ROBI !!??
                }
            }
        }

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
