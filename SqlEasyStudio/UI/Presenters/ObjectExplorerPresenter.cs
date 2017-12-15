using SqlEasyStudio.Application.Interfaces;
using SqlEasyStudio.UI.Views;
using System;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.UI.Model.Extensions;
using System.Linq;

namespace SqlEasyStudio.UI.Presenters
{
    public class ObjectExplorerPresenter
    {
        private IObjectExplorerView View;
        private IObjectExplorerLoader ObjectExplorerLoader;
        private ITreeNodeFactory TreeNodeFactory;


        public ObjectExplorerPresenter(IObjectExplorerView view)
        {
            View = view;

            view.Loaded += View_Load;
            view.TreeMouseClick += View_TreeMouseClick;

            TreeNodeFactory = ContainerDelivery.GetContainer().Resolve<ITreeNodeFactory>();
            ObjectExplorerLoader = ContainerDelivery.GetContainer().Resolve<IObjectExplorerLoader>();
        }

        private void View_TreeMouseClick(object sender, EventArgs e)
        {

        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadObjectExplorerTree();
        }

        private void LoadObjectExplorerTree()
        {            
            var objectExplorerTree = ObjectExplorerLoader.Load();
            foreach (var items in objectExplorerTree.Items)
            {
                View.Nodes.Add(items.ToUITreeNode(TreeNodeFactory));
            }

            var connectionsNode = View.Nodes.FirstOrDefault();
            if (connectionsNode != null)
                connectionsNode.Expanded = true;
        }        

    }
}
