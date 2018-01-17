﻿using SqlEasyStudio.Domain.Repositories;
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
using SqlEasyStudio.Infrastructure.IoC.Container;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Domain.Factories;

namespace SqlEasyStudio.UI.Presenters
{
    public class ObjectExplorerPresenter
    {
        private IObjectExplorerView View;
        private IContainer Container;
        private IObjectExplorerRepositoryFactory ObjectExplorerRepositoryFactory;
        private ITreeNodeFactory TreeNodeFactory;
        private IMenuFactory MenuFactory;
        private ICommandBus CommandBus;
        private IDocumentConnector documentConnector;

        private Dictionary<ObjectExplorerItem, List<ITreeNode>> nodesForItem;

        public ObjectExplorerPresenter(IObjectExplorerView view)
        {
            nodesForItem = new Dictionary<ObjectExplorerItem, List<ITreeNode>>();

            View = view;

            view.Loaded += View_Load;            
            view.NodeMouseClick += View_NodeMouseClick;
            view.NodeAfterSelect += View_NodeAfterSelect;

            Container = ContainerDelivery.GetContainer();

            TreeNodeFactory = Container.Resolve<ITreeNodeFactory>();
            ObjectExplorerRepositoryFactory = Container.Resolve<IObjectExplorerRepositoryFactory>();
            MenuFactory = Container.Resolve<IMenuFactory>();
            CommandBus = Container.Resolve<ICommandBus>();

            documentConnector = Container.Resolve<IDocumentConnector>();
            documentConnector.DocumentConnected += DocumentConnector_DocumentConnected;
            documentConnector.DocumentDisconnected += DocumentConnector_DocumentDisconnected;
        }

        private void DocumentConnector_DocumentConnected(object sender, DocumentConnectionEvent e)
        {
            var item = e.ConnectionLink.ConnectionItem;
            ApplyForItemNodes(item, (ITreeNode node) => 
            {
                node.Text = "[C] " + item.Name;
                node.IsBold = true;
            });
        }
        private void DocumentConnector_DocumentDisconnected(object sender, DocumentConnectionEvent e)
        {
            var item = e.ConnectionLink.ConnectionItem;
            ApplyForItemNodes(item, (ITreeNode node) =>
            {
                node.Text = item.Name;
                node.IsBold = false;
            });
        }

        private void ApplyForItemNodes(ObjectExplorerItem item, Action<ITreeNode> action)
        {            
            if (nodesForItem.ContainsKey(item))
            {
                foreach (ITreeNode node in nodesForItem[item])
                {
                    action(node);
                }
            }
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
                IMenuItem[] menuItems = GenerateNodeMenuItems(node);
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

        private IMenuItem[] GenerateNodeMenuItems(ITreeNode treeNode)
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
                        return new IMenuItem[]
                            {
                                MenuFactory.CreateMenuItem("Connect", () => CommandBus.Send(new ConnectCommand(objectExplorerItem)) ),
                                MenuFactory.CreateMenuItem("Edit", () => CommandBus.Send(new ConnectionEditCommand(objectExplorerItem)) )                                
                            };
                    }
                default:
                    return new IMenuItem[] { };                    
            }            
        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadObjectExplorerTreeView();
            ExpandConnections();
        }

        private void LoadObjectExplorerTreeView()
        {
            var objectExplorerTree = GenerateObjectExplorerTree();
            foreach (var item in objectExplorerTree.Items)
            {
                ITreeNode n = CreateTreeNodeForItem(item);
                View.Nodes.Add(n);
            }            
        }        

        private void ExpandConnections()
        {
            var connectionsNode = View.Nodes.FirstOrDefault();
            if (connectionsNode != null)
                connectionsNode.Expanded = true;
        }

        private ObjectExplorerTree GenerateObjectExplorerTree()
        {
            var objectExplorerRepository = ObjectExplorerRepositoryFactory.Create();
            return objectExplorerRepository.Load();
        }

        private ITreeNode CreateTreeNodeForItem(ObjectExplorerItem item)
        {
            ITreeNode n = item.ToUITreeNode(TreeNodeFactory, AddNodeForItem);
            AddNodeForItem(n, item);
            return n;
        }        

        private void AddNodeForItem(ITreeNode node, ObjectExplorerItem item)
        {
            if (!nodesForItem.ContainsKey(item))
                nodesForItem.Add(item, new List<ITreeNode>());
            
            nodesForItem[item].Add(node);
        }
        

    }
}
