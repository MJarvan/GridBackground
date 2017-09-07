using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace 光标
{
	public class Win32Api
	{
		#region  
		//private const int CB_ERR = -1;
		//private const int SEARCH_ALL = -1;
		//private const int CB_SELECTSTRING = 0x014D;
		//private const int WM_SETTEXT = 0x000C;
		//private const int BM_CLICK = 0x00F5;
		//public const int WM_COPY = 0x301;
		//public const int WM_CUT = 0x300;
		//public const int WM_PASTE = 0x302;
		#endregion

		#region DllImports
		[DllImport("user32.dll")]
		public static extern int GetWindowText(int hWnd,StringBuilder text,int count);

		[DllImport("user32.dll",SetLastError = true)]
		public static extern uint GetWindowThreadProcessId(int hWnd,out uint lpdwProcessId);

		[DllImport("user32.dll",EntryPoint = "GetGUIThreadInfo")]
		public static extern bool GetGUIThreadInfo(uint tId,out GUITHREADINFO threadInfo);

		[DllImport("user32.dll")]
		public static extern int GetForegroundWindow();

		[DllImport("user32.dll")]
		public static extern bool ClientToScreen(IntPtr hWnd,out Point position);

		[DllImport("user32.dll")]
		public static extern Int32 FindWindow(string strClassName,string strWindowName);
		#endregion

		#region 
		public delegate bool Win32Callback(int hwnd,int lParam);
		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public uint Left;
			public uint Top;
			public uint Right;
			public uint Bottom;
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct GUITHREADINFO
		{
			public uint cbSize;
			public uint flags;
			public IntPtr hwndActive;
			public IntPtr hwndFocus;
			public IntPtr hwndCapture;
			public IntPtr hwndMenuOwner;
			public IntPtr hwndMoveSize;
			public IntPtr hwndCaret;
			public RECT rcCaret;
		};

		#endregion

	}

}
