using SqlEasyStudio.Domain.Repositories;
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
        private IObjectExplorerRepositoryFactory ObjectExplorerRepositoryFactory;
        private ITreeNodeFactory TreeNodeFactory;
        private IMenuFactory MenuFactory;

        public ObjectExplorerPresenter(IObjectExplorerView view)
        {
            View = view;

            view.Loaded += View_Load;
            view.TreeMouseClick += View_TreeMouseClick;
            view.NodeMouseClick += View_NodeMouseClick;

            TreeNodeFactory = ContainerDelivery.GetContainer().Resolve<ITreeNodeFactory>();
            ObjectExplorerRepositoryFactory = ContainerDelivery.GetContainer().Resolve<IObjectExplorerRepositoryFactory>();
            MenuFactory = ContainerDelivery.GetContainer().Resolve<IMenuFactory>();
        }

        private void View_NodeMouseClick(object sender, NodeMouseClickArgs e)
        {
            ITreeNode node = e.Node;
            IContextMenu contextMenu = MenuFactory.CreateContextMenu();
            IMenuItem menu = MenuFactory.CreateMenuItem();
            menu.Name = "menu do " + node.Text;
            contextMenu.MenuItems.Add(menu);
            node.ContextMenu = contextMenu;
            
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
            var objectExplorerRepository = ObjectExplorerRepositoryFactory.Create();
            var objectExplorerTree = objectExplorerRepository.Load();
            foreach (var item in objectExplorerTree.Items)
            {
                ITreeNode n = item.ToUITreeNode(TreeNodeFactory);
                View.Nodes.Add(n);
            }

            var connectionsNode = View.Nodes.FirstOrDefault();
            if (connectionsNode != null)
                connectionsNode.Expanded = true;
        }        

    }
}
