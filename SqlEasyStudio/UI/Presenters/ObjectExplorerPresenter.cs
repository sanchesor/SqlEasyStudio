using SqlEasyStudio.Application.Interfaces;
using SqlEasyStudio.Application.Models;
using SqlEasyStudio.UI.Views;
using System;
using System.Collections.Generic;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.UI.Forms.Implementation;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.UI.Model.Extensions;

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
            //throw new NotImplementedException();
        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadObjectExplorerTree();
        }

        private void LoadObjectExplorerTree()
        {            
            var objectExplorerTree = ObjectExplorerLoader.Load();
            foreach (var objectExplorerNode in objectExplorerTree.Nodes)
            {
                View.Nodes.Add(objectExplorerNode.ToUITreeNode(TreeNodeFactory));
            }
        }        

    }
}
