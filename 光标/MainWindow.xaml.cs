using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 光标
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow:Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		System.Timers.Timer timer = new System.Timers.Timer();
		static int elapsedTimes;
		Win32Api.GUITHREADINFO guiInfo;
		System.Drawing.Point caretPosition;

		#region 鼠标光标
		//[DllImport("user32.dll")]
		//public static extern bool GetCursorPos(out POINT lpPoint);
		//[StructLayout(LayoutKind.Sequential)]
		//public struct POINT
		//{
		//	public int X;
		//	public int Y;
		//	public POINT(int x,int y)
		//	{
		//		this.X = x;
		//		this.Y = y;
		//	}
		//}
		#endregion


		private void buttonStart_Click(object sender,RoutedEventArgs e)
		{
			timer.Start();
		}

		private void Window_Loaded(object sender,RoutedEventArgs e)
		{
			Screen sc = Screen.PrimaryScreen;

			this.Top = sc.Bounds.Top;
			this.Left = (sc.Bounds.Left + sc.Bounds.Right) / 4;

			//this.TopMost = true;
			timer.Interval = 1000;
			timer.Elapsed += OnTimedEvent;
		}

		static IntPtr WindowHwnd;

		/// <summary>
		/// Timer的Elapsed事件处理程序
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void OnTimedEvent(object source,ElapsedEventArgs e)
		{
			GetWindowIntptr();

			if((IntPtr)Win32Api.GetForegroundWindow() == WindowHwnd)
			{
				return;
			}
			string activeProcess = GetActiveProcess();

			if((activeProcess.ToLower().Contains("explorer") | (activeProcess == string.Empty)))
			{
				return;
			}
			else
			{
				EvaluateCaretPosition();
				this.textblock.Dispatcher.Invoke(
					new Action(
						delegate
						{
							textblock.Text = " 当前程序 : " + activeProcess;
						}
					)
				);
				//this.Visibility = Visibility.Visible;
			}

			//Point p = CaretPos();
			//System.Windows.MessageBox.Show("光标的坐标x:" + p.X.ToString() + " y:" + p.Y.ToString());
			++elapsedTimes;
		}

		private void buttonStop_Click(object sender,RoutedEventArgs e)
		{
			timer.Stop();
			System.Windows.MessageBox.Show("Timer已停止，之前共触发次" + (elapsedTimes).ToString() + "事件","Timer测试");
			elapsedTimes = 0;
		}

		private string GetActiveProcess()
		{
			const int nChars = 256;
			int handle = 0;
			StringBuilder Buff = new StringBuilder(nChars);
			handle = (int)Win32Api.GetForegroundWindow();

			if(Win32Api.GetWindowText(handle,Buff,nChars) > 0)
			{
				uint lpdwProcessId;
				uint dwCaretID = Win32Api.GetWindowThreadProcessId(handle,out lpdwProcessId);
				uint dwCurrentID = (uint)Thread.CurrentThread.ManagedThreadId;
				return Process.GetProcessById((int)lpdwProcessId).ProcessName;
			}

			return String.Empty;
		}

		public void GetWindowIntptr()
		{
			this.main.Dispatcher.Invoke(
				new Action(
					delegate
					{
						WindowHwnd = ((HwndSource)PresentationSource.FromVisual(this.main)).Handle;
					}
				)
			);

		}

		public void GetCaretPosition()
		{
			guiInfo = new Win32Api.GUITHREADINFO();
			guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);

			Win32Api.GetGUIThreadInfo(0,out guiInfo);
		}

		private void EvaluateCaretPosition()
		{
			caretPosition = new System.Drawing.Point();

			GetCaretPosition();

			caretPosition.X = (int)guiInfo.rcCaret.Left + 25;
			caretPosition.Y = (int)guiInfo.rcCaret.Bottom + 25;

			Win32Api.ClientToScreen(guiInfo.hwndCaret,out caretPosition);

			this.textboxX.Dispatcher.Invoke(
				new Action(
					delegate
					{
						textboxX.Text = (caretPosition.X).ToString();
					}
				)
			);

			this.textboxY.Dispatcher.Invoke(
				new Action(
					delegate
					{
						textboxY.Text = (caretPosition.X).ToString();
					}
				)
			);
		}

	}
}
