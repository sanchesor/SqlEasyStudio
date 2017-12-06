using SqlEasyStudio.Interfaces.Views;
using System;

namespace SqlEasyStudio.Interfaces.Presenters
{
    public class ObjectExplorerPresenter
    {
        public IObjectExplorerView View { get; internal set; }        

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
            
        }
    }
}
