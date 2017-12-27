using SqlEasyStudio.Domain.Repositories;
using SqlEasyStudio.Domain;
using SqlEasyStudio.UI.Views;
using System;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.UI.Model.Extensions;
using System.Linq;
using System.Collections.Generic;
using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Infrastructure.Messaging;
using SqlEasyStudio.Domain.Enums;

namespace SqlEasyStudio.UI.Presenters
{
    public class ObjectExplorerPresenter
    {
        private IObjectExplorerView View;
        private IObjectExplorerRepositoryFactory ObjectExplorerRepositoryFactory;
        private ITreeNodeFactory TreeNodeFactory;
        private IMenuFactory MenuFactory;
        private ICommandBus CommandBus;

        public ObjectExplorerPresenter(IObjectExplorerView view)
        {
            View = view;

            view.Loaded += View_Load;            
            view.NodeMouseClick += View_NodeMouseClick;
            view.NodeAfterSelect += View_NodeAfterSelect;

            TreeNodeFactory = ContainerDelivery.GetContainer().Resolve<ITreeNodeFactory>();
            ObjectExplorerRepositoryFactory = ContainerDelivery.GetContainer().Resolve<IObjectExplorerRepositoryFactory>();
            MenuFactory = ContainerDelivery.GetContainer().Resolve<IMenuFactory>();
            CommandBus = ContainerDelivery.GetContainer().Resolve<ICommandBus>();
        }

        private void View_NodeAfterSelect(object sender, EventArgs e)
        {
            SetNodeContextMenu(View.SelectedNode);
        }

        private void View_NodeMouseClick(object sender, NodeMouseClickArgs e)
        {
            View.SelectedNode = e.Node;
            SetNodeContextMenu(View.SelectedNode);            
        }

        private void SetNodeContextMenu(ITreeNode node)
        {
            if (node.ContextMenu == null)
            {                
                IMenuItem[] menuItems = GetNodeMenuItems(node);
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

        private IMenuItem[] GetNodeMenuItems(ITreeNode treeNode)
        {
            ObjectExplorerItem objectExplorerItem = treeNode.Data as ObjectExplorerItem;
            switch (objectExplorerItem.ItemType)
            {
                case ObjectExplorerItemType.Connections:
                    {
                        return new IMenuItem[]
                            {
                                MenuFactory.CreateMenuItem("Add connection", () => CommandBus.Send(new ConnectionAddCommand()))
                            };

                    }
                case ObjectExplorerItemType.Connection:
                    {
                        string connectionString = objectExplorerItem.Data.ToString();

                        return new IMenuItem[]
                            {
                                MenuFactory.CreateMenuItem("Connect", () => CommandBus.Send(new ConnectCommand(connectionString)) ),
                                MenuFactory.CreateMenuItem("Edit", () => CommandBus.Send(new ConnectionEditCommand(objectExplorerItem)) )
                            };
                    }
                default:
                    return new IMenuItem[] { };                    
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
