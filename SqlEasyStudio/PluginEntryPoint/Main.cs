
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Drawing;
using System;
using System.Runtime.InteropServices;
using SqlEasyStudio.Properties;
using SqlEasyStudio.PlaginGateway;
using System.Windows.Forms;
using SqlEasyStudio.UI.Forms.Factories;

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
        static FormsFactory formsFactory = new FormsFactory();
        static PluginFormContainer pluginFormContainer = new PluginFormContainer();                

        public static void OnNotification(ScNotification notification)
        {            
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void CommandMenuInit()
        {            
            PluginBase.SetCommand(0, "Object explorer", ToggleObjectExplorer);
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
                       
            if(!pluginFormContainer.Forms.ContainsKey("object_explorer"))
            {
                Form objectExplorerForm = formsFactory.Create("object_explorer");
                pluginFormContainer.Register("object_explorer", objectExplorerForm, "Object explorer", 0, NppTbMsg.DWS_DF_CONT_LEFT);
            }
            else
            {
                pluginFormContainer.Forms["object_explorer"].ToggleVisible();
            }
                        
        }

    }
}