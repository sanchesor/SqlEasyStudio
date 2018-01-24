
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
using SqlEasyStudio.Application.Documents;
using SqlEasyStudio.Application;

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
        private static IDocumentsController documentController;

        public static void OnNotification(ScNotification notification)
        {            
            switch((NppMsg)notification.Header.Code)
            {
                case NppMsg.NPPN_BUFFERACTIVATED:
                    {
                        // todo: should be eventPublisher.publish(new event..) and objectExplorerPresenter should subscribe
                        documentController.ActivateDocument(
                            documentController.GetDocumentById(notification.Header.IdFrom));
                    }
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        internal static void CommandMenuInit()
        {
            BootStrapper.RegisterComponents();
            BootStrapper.RegisterCommandHandlers();

            var container = ContainerDelivery.GetContainer();
            pluginFormProvider = container.Resolve<IPluginFormProvider>();
            commandBus = container.Resolve<ICommandBus>();
            documentController = container.Resolve<IDocumentsController>();

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