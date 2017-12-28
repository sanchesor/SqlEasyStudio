using Kbg.NppPluginNET.PluginInfrastructure;
using SqlEasyStudio.Application;
using System;
using System.Runtime.InteropServices;

namespace SqlEasyStudio.PluginGateway.Implementation
{
    public class NppDocument : IDocument
    {
        public string Text
        {
            get
            {
                int length = (int)Win32.SendMessage(_internalDocument, SciMsg.SCI_GETLENGTH, 0, 0);
                IntPtr ptrToText = Marshal.AllocHGlobal(length + 1);
                Win32.SendMessage(_internalDocument, SciMsg.SCI_GETTEXT, length + 1, ptrToText);
                string textAnsi = Marshal.PtrToStringAnsi(ptrToText);
                Marshal.FreeHGlobal(ptrToText);

                return textAnsi;
            }
        }

        public string SelectedText
        {
            get
            {
                int length = (int)Win32.SendMessage(_internalDocument, SciMsg.SCI_GETLENGTH, 0, 0);
                IntPtr ptrToText = Marshal.AllocHGlobal(length + 1);
                Win32.SendMessage(_internalDocument, SciMsg.SCI_GETSELTEXT, length + 1, ptrToText);
                string textAnsi = Marshal.PtrToStringAnsi(ptrToText);
                Marshal.FreeHGlobal(ptrToText);

                return textAnsi;
            }
        }

        IntPtr _internalDocument;

        public NppDocument(IntPtr internalAddress)
        {
            _internalDocument = internalAddress;
        }
    }
}
