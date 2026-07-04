using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowCenteringNext.Toolkit
{
	// Token: 0x02000002 RID: 2
	internal static class Interops
	{
		// Token: 0x06000001 RID: 1
		[DllImport("user32.dll")]
		internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		// Token: 0x06000002 RID: 2
		[DllImport("user32.dll")]
		internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		// Token: 0x06000003 RID: 3
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

		// Token: 0x06000004 RID: 4
		[DllImport("user32.dll")]
		internal static extern bool GetWindowRect(IntPtr hWnd, ref Interops.Rect rect);

		// Token: 0x06000005 RID: 5
		[DllImport("user32.dll")]
		internal static extern bool GetClientRect(IntPtr hWnd, out Interops.Rect lpRect);

		// Token: 0x06000006 RID: 6
		[DllImport("user32.dll")]
		internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000007 RID: 7
		[DllImport("user32.dll")]
		internal static extern IntPtr GetForegroundWindow();

		// Token: 0x06000008 RID: 8
		[DllImport("user32.dll")]
		internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		// Token: 0x06000009 RID: 9
		[DllImport("user32.dll")]
		internal static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

		// Token: 0x0600000A RID: 10
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool GetMonitorInfo(IntPtr hMonitor, ref Interops.MONITORINFO lpmi);

		// Token: 0x0600000B RID: 11
		[DllImport("user32.dll")]
		internal static extern IntPtr GetDesktopWindow();

		// Token: 0x04000001 RID: 1
		internal const uint MONITOR_DEFAULTTONEAREST = 2U;

		// Token: 0x04000002 RID: 2
		internal const uint MONITOR_DEFAULTTOPRIMARY = 1U;

		// Token: 0x02000014 RID: 20
		internal struct Rect
		{
			// Token: 0x040000BA RID: 186
			public int Left;

			// Token: 0x040000BB RID: 187
			public int Top;

			// Token: 0x040000BC RID: 188
			public int Right;

			// Token: 0x040000BD RID: 189
			public int Bottom;
		}

		// Token: 0x02000015 RID: 21
		internal struct MONITORINFO
		{
			// Token: 0x040000BE RID: 190
			public int cbSize;

			// Token: 0x040000BF RID: 191
			public Interops.Rect rcMonitor;

			// Token: 0x040000C0 RID: 192
			public Interops.Rect rcWork;

			// Token: 0x040000C1 RID: 193
			public uint dwFlags;
		}
	}
}
