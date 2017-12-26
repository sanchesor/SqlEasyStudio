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
        
        public event EventHandler<NodeMouseClickArgs> NodeMouseClick;
        public event EventHandler Loaded;
        public event EventHandler AfterSelect;


        public ITreeNode SelectedNode { get { return _tree.SelectedNode.Tag as ITreeNode; } set { _tree.SelectedNode = ((FormsTreeNode)value).Node; } }

        public ObjectExplorerForm()
        {
            InitializeComponent();            

            VisibleChanged += ObjectExplorerForm_VisibleChanged;            
            _tree.NodeMouseClick += _tree_NodeMouseClick;
            _tree.AfterSelect += _tree_AfterSelect;            

            presenter = new ObjectExplorerPresenter(this);            
            
        }

        private void _tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterSelect?.Invoke(sender, e);
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
        

    }
}
