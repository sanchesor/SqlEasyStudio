
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Drawing;
using System;
using System.Runtime.InteropServices;
using SqlEasyStudio.Properties;


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
        public const string PluginName = "ssss";

        static Bitmap tbBmp = Resources.ses;
        static Bitmap tbBmp_tbTab = Resources.ses_bmp;


        public static void OnNotification(ScNotification notification)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void CommandMenuInit()
        {
            
            PluginBase.SetCommand(0, "Object explorer", ToggleAllWindows);
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

        internal static void ToggleAllWindows()
        {


        }

    }
}