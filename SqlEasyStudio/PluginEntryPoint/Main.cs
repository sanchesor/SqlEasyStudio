
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Drawing;
using System;
using System.Runtime.InteropServices;
using SqlEasyStudio.Properties;
using SqlEasyStudio.PluginEntryPoint;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.PluginGateway;
using SqlEasyStudio.Infrastructure.Messaging;
using SqlEasyStudio.Application.Commands;

/// <summary>
/// 
/// </summary>
namespace Kbg.NppPluginNET
{
    /// <summary>
    /// 
    /// </summary>
    class Main
    {
        /// <summary>
        /// 
        /// </summary>
        public const string PluginName = "Sql Easy Studio";
        static Bitmap tbBmp = Resources.ses;

        private static IPluginFormProvider pluginFormProvider;
        private static ICommandBus commandBus;

        public static void OnNotification(ScNotification notification)
        {            
        }


        /// <summary>
        /// 
        /// </summary>
        internal static void CommandMenuInit()
        {
            BootStrapper.RegisterComponents();
            BootStrapper.RegisterCommandHandlers();

            pluginFormProvider = ContainerDelivery.GetContainer().Resolve<IPluginFormProvider>();
            commandBus = ContainerDelivery.GetContainer().Resolve<ICommandBus>();

            PluginBase.SetCommand(0, "Object explorer", ToggleObjectExplorer);
            PluginBase.SetCommand(1, "Output", ToggleOutput);
            PluginBase.SetCommand(2, "Execute", Execute);
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void SetToolBarIcon()
        {
            
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[0]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void PluginCleanUp()
        {            
        }

        internal static void ToggleObjectExplorer()
        {
            pluginFormProvider.ToggleVisible("object_explorer");
        }

        internal static void ToggleOutput()
        {
            pluginFormProvider.ToggleVisible("output");
        }

        internal static void Execute()
        {
            commandBus.Send(new ExecuteCommand());
        }
        
    }
}