using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowCenteringNext.Toolkit
{
	// Token: 0x02000004 RID: 4
	public static class WindowKit
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002095 File Offset: 0x00000295
		public static void ShowNormal(IntPtr WindowID)
		{
			Interops.ShowWindow(WindowID, 1);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000209F File Offset: 0x0000029F
		public static void ShowMaximized(IntPtr WindowID)
		{
			Interops.ShowWindow(WindowID, 3);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020A9 File Offset: 0x000002A9
		public static void MoveWindow(IntPtr WindowID, int X, int Y, int Width, int Height)
		{
			Interops.MoveWindow(WindowID, X, Y, Width, Height, true);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020B8 File Offset: 0x000002B8
		public static IntPtr GetCurrentWindow()
		{
			return Interops.GetForegroundWindow();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000020C0 File Offset: 0x000002C0
		public static int GetBorderSize(IntPtr WindowID)
		{
			Interops.Rect rect = default(Interops.Rect);
			Interops.Rect rect2 = default(Interops.Rect);
			Interops.GetWindowRect(WindowID, ref rect);
			Interops.GetWindowRect(WindowID, ref rect2);
			return Math.Abs(rect2.Right - rect2.Left - rect.Right - rect.Left);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002110 File Offset: 0x00000310
		public static string GetWindowClass(IntPtr WindowID)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			Interops.GetClassName(WindowID, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000213C File Offset: 0x0000033C
		public static string GetWindowTitle(IntPtr WindowID)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			Interops.GetWindowText(WindowID, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002168 File Offset: 0x00000368
		public static MonitorWorkArea GetWindowWorkArea(IntPtr WindowID)
		{
			IntPtr intPtr = Interops.MonitorFromWindow(WindowID, 2U);
			Interops.MONITORINFO monitorInfo = default(Interops.MONITORINFO);
			monitorInfo.cbSize = Marshal.SizeOf(typeof(Interops.MONITORINFO));
			Interops.GetMonitorInfo(intPtr, ref monitorInfo);
			return new MonitorWorkArea
			{
				X = monitorInfo.rcWork.Left,
				Y = monitorInfo.rcWork.Top,
				Width = monitorInfo.rcWork.Right - monitorInfo.rcWork.Left,
				Height = monitorInfo.rcWork.Bottom - monitorInfo.rcWork.Top
			};
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000220C File Offset: 0x0000040C
		public static MonitorWorkArea GetPrimaryMonitorWorkArea()
		{
			Screen primaryScreen = Screen.PrimaryScreen;
			return new MonitorWorkArea
			{
				X = primaryScreen.WorkingArea.Left,
				Y = primaryScreen.WorkingArea.Top,
				Width = primaryScreen.WorkingArea.Width,
				Height = primaryScreen.WorkingArea.Height
			};
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000227C File Offset: 0x0000047C
		public static WindowBox GetWindowBox(IntPtr WindowID)
		{
			Interops.Rect rect = default(Interops.Rect);
			Interops.GetWindowRect(WindowID, ref rect);
			return new WindowBox(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000022C5 File Offset: 0x000004C5
		public static WindowStyles GetWindowStyle(IntPtr WindowID)
		{
			return (WindowStyles)Interops.GetWindowLong(WindowID, -16);
		}
	}
}
