using System;
using System.Collections.Generic;
using System.Threading;
using WindowCenteringNext.Toolkit;

namespace WindowCenteringNext.Core
{
	// Token: 0x0200000B RID: 11
	internal sealed class WindowListener
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00002DFC File Offset: 0x00000FFC
		internal WindowListener()
		{
			this._Lock = new object();
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600004E RID: 78 RVA: 0x00002E10 File Offset: 0x00001010
		// (remove) Token: 0x0600004F RID: 79 RVA: 0x00002E48 File Offset: 0x00001048
		internal event WindowListener.WindowCallback NewWindow;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000050 RID: 80 RVA: 0x00002E80 File Offset: 0x00001080
		// (remove) Token: 0x06000051 RID: 81 RVA: 0x00002EB8 File Offset: 0x000010B8
		internal event WindowListener.WindowCallback CurrentWindow;

		// Token: 0x06000052 RID: 82 RVA: 0x00002EED File Offset: 0x000010ED
		internal void Start()
		{
			if (this._Thread != null && this._Thread.IsAlive)
			{
				this._Close();
			}
			this._Init();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002F10 File Offset: 0x00001110
		internal void Close()
		{
			if (this._Thread != null && this._Thread.IsAlive)
			{
				this._Close();
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002F30 File Offset: 0x00001130
		internal bool IsAlive()
		{
			object @lock = this._Lock;
			bool flag2;
			lock (@lock)
			{
				flag2 = this._Thread != null && this._Loop;
			}
			return flag2;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F80 File Offset: 0x00001180
		private void _Init()
		{
			this._Loop = true;
			this._Thread = new Thread(new ThreadStart(delegate
			{
				IntPtr intPtr = IntPtr.Zero;
				Queue<IntPtr> queue = new Queue<IntPtr>();
				for (;;)
				{
					object obj = this._Lock;
					lock (obj)
					{
						if (!this._Loop)
						{
							break;
						}
					}
					IntPtr currentWindow = WindowKit.GetCurrentWindow();
					WindowListener.WindowCallback currentWindow2 = this.CurrentWindow;
					if (currentWindow2 != null)
					{
						currentWindow2(currentWindow);
					}
					obj = this._Lock;
					lock (obj)
					{
						if (this._KeepHistory)
						{
							if (!queue.Contains(currentWindow))
							{
								queue.Enqueue(currentWindow);
								WindowListener.WindowCallback newWindow = this.NewWindow;
								if (newWindow != null)
								{
									newWindow(currentWindow);
								}
							}
						}
						else if (!this._KeepHistory && intPtr != currentWindow)
						{
							intPtr = currentWindow;
							WindowListener.WindowCallback newWindow2 = this.NewWindow;
							if (newWindow2 != null)
							{
								newWindow2(currentWindow);
							}
						}
					}
					Thread.Sleep(50);
				}
			}));
			this._Thread.Start();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002FAC File Offset: 0x000011AC
		private void _Close()
		{
			object @lock = this._Lock;
			lock (@lock)
			{
				this._Loop = false;
			}
			while (this._Thread.IsAlive)
			{
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002FFC File Offset: 0x000011FC
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00003040 File Offset: 0x00001240
		internal bool KeepHistory
		{
			get
			{
				object @lock = this._Lock;
				bool keepHistory;
				lock (@lock)
				{
					keepHistory = this._KeepHistory;
				}
				return keepHistory;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._KeepHistory = value;
				}
			}
		}

		// Token: 0x0400003D RID: 61
		internal const int EXECUTION_INTERVAL = 50;

		// Token: 0x0400003E RID: 62
		private bool _Loop;

		// Token: 0x0400003F RID: 63
		private bool _KeepHistory;

		// Token: 0x04000040 RID: 64
		private Thread _Thread;

		// Token: 0x04000041 RID: 65
		private readonly object _Lock;

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x060000AE RID: 174
		internal delegate void WindowCallback(IntPtr Window);
	}
}
