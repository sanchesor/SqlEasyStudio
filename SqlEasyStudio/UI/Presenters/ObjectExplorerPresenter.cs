using SqlEasyStudio.Application.Interfaces;
using SqlEasyStudio.Application.Models;
using SqlEasyStudio.UI.Views;
using System;
using System.Collections.Generic;
using SqlEasyStudio.UI.Model;
using SqlEasyStudio.UI.Forms.Implementation;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Filesystem;

namespace SqlEasyStudio.UI.Presenters
{
    public class ObjectExplorerPresenter
    {
        private IObjectExplorerView View;
        //private IObjectExplorerLoader ObjectExplorerLoader;


        public ObjectExplorerPresenter(IObjectExplorerView view)
        {
            View = view;

            view.Loaded += View_Load;
            view.TreeMouseClick += View_TreeMouseClick;
            
        }

        private void View_TreeMouseClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_Load(object sender, EventArgs e)
        {
            //var loader = ContainerDelivery.GetContainer().Resolve<IObjectExplorerLoader>();
            var loader = new XMLObjectExplorerLoader();
            foreach(var node in loader.Load().Nodes)
            {
                View.Nodes.Add(node);
            }
            

        }


    }
}
