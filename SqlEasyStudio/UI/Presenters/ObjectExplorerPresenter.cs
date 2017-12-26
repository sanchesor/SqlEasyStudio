using SqlEasyStudio.Domain.Repositories;
using SqlEasyStudio.Domain;
using SqlEasyStudio.UI.Views;
using System;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.UI.Model.Extensions;
using System.Linq;
using System.Collections.Generic;

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
            view.NodeMouseClick += View_NodeMouseClick;
            view.AfterSelect += View_AfterSelect;

            TreeNodeFactory = ContainerDelivery.GetContainer().Resolve<ITreeNodeFactory>();
            ObjectExplorerRepositoryFactory = ContainerDelivery.GetContainer().Resolve<IObjectExplorerRepositoryFactory>();
            MenuFactory = ContainerDelivery.GetContainer().Resolve<IMenuFactory>();
        }

        private void View_AfterSelect(object sender, EventArgs e)
        {
            SetNodeContextMenu(View.SelectedNode);
        }

        private void View_NodeMouseClick(object sender, NodeMouseClickArgs e)
        {
            View.SelectedNode = e.Node;
            SetNodeContextMenu(View.SelectedNode);            
        }

        private IEnumerable<IMenuItem> GetNodeMenuItems(ITreeNode node)
        {
            ObjectExplorerItem item = node.Data as ObjectExplorerItem;
            switch(item.ItemType)
            {
                case Domain.Enums.ObjectExplorerItemType.Connection:
                    {
                        IMenuItem menuItem = MenuFactory.CreateMenuItem();
                        menuItem.Name = "Connect";
                        yield return menuItem;

                        menuItem = MenuFactory.CreateMenuItem();
                        menuItem.Name = "Edit";
                        yield return menuItem;
                    }
                    break;                    
            }
        }

        private void SetNodeContextMenu(ITreeNode node)
        {
            if (node.ContextMenu == null)
            {                
                IEnumerable<IMenuItem> menuItems = GetNodeMenuItems(node);
                if (menuItems.Count() > 0)
                {
                    IContextMenu contextMenu = MenuFactory.CreateContextMenu();
                    foreach (var menuItem in menuItems)
                    {
                        contextMenu.MenuItems.Add(menuItem);
                    }
                    node.ContextMenu = contextMenu;
                }
            }
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
