using SqlEasyStudio.UI.Presenters;
using SqlEasyStudio.UI.Views;
using System;
using System.Windows.Forms;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.UI.Forms.Implementation;
using System.Linq;
using System.Collections.Generic;

namespace SqlEasyStudio.UI.Forms
{
    public partial class ObjectExplorerForm : Form, IObjectExplorerView
    {
        private ObjectExplorerPresenter presenter;

        public event EventHandler TreeMouseClick;
        public event EventHandler<NodeMouseClickArgs> NodeMouseClick;
        public event EventHandler Loaded;        

        public ObjectExplorerForm()
        {
            InitializeComponent();            

            VisibleChanged += ObjectExplorerForm_VisibleChanged;
            _tree.MouseClick += _tree_MouseClick;
            _tree.NodeMouseClick += _tree_NodeMouseClick;

            presenter = new ObjectExplorerPresenter(this);            
            
        }

        private void _tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NodeMouseClick?.Invoke(sender, new NodeMouseClickArgs() { Node = e.Node.Tag as ITreeNode});           
        }

        bool _isLoaded = false;

        public ITreeNodeCollection<ITreeNode> Nodes => new FormsTreeNodeCollection(_tree.Nodes);

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
