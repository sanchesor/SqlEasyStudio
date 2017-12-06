﻿namespace SqlEasyStudio.PluginGateway.PluginForm
{
    public interface IPluginForm
    {
        string Name { get; }

        bool Visible { get; }

        void Show();
        void Hide();
        void ToggleVisible();
    }
}
