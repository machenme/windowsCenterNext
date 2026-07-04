using System;
using System.Windows.Forms;
using WindowCenteringNext.Toolkit;
using WindowCenteringNext;

namespace WindowCenteringNext.Core
{
	// Token: 0x02000007 RID: 7
	public class CenteringHelper
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000022CF File Offset: 0x000004CF
		public CenteringHelper()
		{
			this._WindowListener = new WindowListener();
			this._KeySequenceListener = new KeySquenceListener();
			this._Lock = new object();
			this._Init();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000022FE File Offset: 0x000004FE
		public void Close()
		{
			this._Close();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002306 File Offset: 0x00000506
		private void _Close()
		{
			if (this._WindowListener.IsAlive())
			{
				this._WindowListener.Close();
			}
			if (this._KeySequenceListener.IsAlive())
			{
				this._KeySequenceListener.Close();
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002338 File Offset: 0x00000538
		private void _Init()
		{
			Action<IntPtr> CenterWindow = delegate(IntPtr WindowID)
			{
				WindowStyles windowStyle = WindowKit.GetWindowStyle(WindowID);
				if (this._CustomWindowWidth && this._CustomWindowHeight && windowStyle.HasFlag(WindowStyles.MAXIMIZE))
				{
					WindowKit.ShowNormal(WindowID);
				}
				WindowBox windowBox = WindowKit.GetWindowBox(WindowID);
				MonitorWorkArea workArea = (this._CenterOnPrimaryScreen ? WindowKit.GetPrimaryMonitorWorkArea() : WindowKit.GetWindowWorkArea(WindowID));
				WindowKit.GetBorderSize(WindowID);
				int width = workArea.Width;
				int height = workArea.Height;
				int num = windowBox.Width;
				int num2 = windowBox.Height;
				bool flag = windowStyle.HasFlag(WindowStyles.THICKFRAME) && windowStyle.HasFlag(WindowStyles.TABSTOP) && !windowStyle.HasFlag(WindowStyles.MAXIMIZE);
				if (this._CustomWindowWidth && flag)
				{
					num = Helpers.PercentOf(width, (int)this._WindowWidth);
				}
				if (this._CustomWindowWidth && !flag && this._ForceToResizeWindow)
				{
					num = Helpers.PercentOf(width, (int)this._WindowWidth);
				}
				if (this._CustomWindowHeight && flag)
				{
					num2 = Helpers.PercentOf(height, (int)this._WindowHeight);
				}
				if (this._CustomWindowHeight && !flag && this._ForceToResizeWindow)
				{
					num2 = Helpers.PercentOf(height, (int)this._WindowHeight);
				}
				int num3 = workArea.X + width / 2 - num / 2;
				int num4 = workArea.Y + height / 2 - num2 / 2;
				WindowKit.MoveWindow(WindowID, num3, num4, num, num2);
			};
			this._WindowListener.NewWindow += delegate(IntPtr WindowID)
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					string windowClass = WindowKit.GetWindowClass(WindowID);
					if (!windowClass.Contains("CoreWindow") && !windowClass.Contains("WorkerW") && !windowClass.Contains("Flyout") && !windowClass.Contains("DV2ControlHost") && !windowClass.Contains("NotifyIcon") && !windowClass.Contains("NativeHWNDHost") && !windowClass.Contains("Popup") && !windowClass.Contains("Progman"))
					{
						if (this._HelpMeDecide)
						{
							WindowStyles windowStyle2 = WindowKit.GetWindowStyle(WindowID);
							if (windowStyle2.HasFlag(WindowStyles.MAXIMIZE))
							{
								return;
							}
							if (windowStyle2.HasFlag((WindowStyles)2147483648U) && (!windowStyle2.HasFlag(WindowStyles.SYSMENU) || !windowStyle2.HasFlag(WindowStyles.BORDER)))
							{
								return;
							}
						}
						CenterWindow(WindowID);
					}
				}
			};
			this._KeySequenceListener.SequenceReleased += delegate
			{
				object lock2 = this._Lock;
				lock (lock2)
				{
					CenterWindow(WindowKit.GetCurrentWindow());
				}
			};
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002394 File Offset: 0x00000594
		private void _Init(Services Services)
		{
			if (Services.HasFlag(Services.OnKeySequence) && !this._KeySequenceListener.IsAlive())
			{
				this._KeySequenceListener.Start();
			}
			if (!Services.HasFlag(Services.OnKeySequence) && this._KeySequenceListener.IsAlive())
			{
				this._KeySequenceListener.Close();
			}
			if (Services.HasFlag(Services.Automatically) && !this._WindowListener.IsAlive())
			{
				this._WindowListener.Start();
			}
			if (!Services.HasFlag(Services.Automatically) && this._WindowListener.IsAlive())
			{
				this._WindowListener.Close();
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002450 File Offset: 0x00000650
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002494 File Offset: 0x00000694
		public uint WindowWidth
		{
			get
			{
				object @lock = this._Lock;
				uint windowWidth;
				lock (@lock)
				{
					windowWidth = this._WindowWidth;
				}
				return windowWidth;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._WindowWidth = value;
				}
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000024D8 File Offset: 0x000006D8
		// (set) Token: 0x06000024 RID: 36 RVA: 0x0000251C File Offset: 0x0000071C
		public uint WindowHeight
		{
			get
			{
				object @lock = this._Lock;
				uint windowHeight;
				lock (@lock)
				{
					windowHeight = this._WindowHeight;
				}
				return windowHeight;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._WindowHeight = value;
				}
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002560 File Offset: 0x00000760
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000025A4 File Offset: 0x000007A4
		public bool HelpMeDecide
		{
			get
			{
				object @lock = this._Lock;
				bool helpMeDecide;
				lock (@lock)
				{
					helpMeDecide = this._HelpMeDecide;
				}
				return helpMeDecide;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._HelpMeDecide = value;
				}
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000025E8 File Offset: 0x000007E8
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000025F5 File Offset: 0x000007F5
		public bool OnlyNewWindow
		{
			get
			{
				return this._WindowListener.KeepHistory;
			}
			set
			{
				this._WindowListener.KeepHistory = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002604 File Offset: 0x00000804
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002648 File Offset: 0x00000848
		public bool CustomWindowWidth
		{
			get
			{
				object @lock = this._Lock;
				bool customWindowWidth;
				lock (@lock)
				{
					customWindowWidth = this._CustomWindowWidth;
				}
				return customWindowWidth;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._CustomWindowWidth = value;
				}
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000268C File Offset: 0x0000088C
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000026D0 File Offset: 0x000008D0
		public bool CustomWindowHeight
		{
			get
			{
				object @lock = this._Lock;
				bool customWindowHeight;
				lock (@lock)
				{
					customWindowHeight = this._CustomWindowHeight;
				}
				return customWindowHeight;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._CustomWindowHeight = value;
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002714 File Offset: 0x00000914
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002758 File Offset: 0x00000958
		public bool ForceToResizeWindow
		{
			get
			{
				object @lock = this._Lock;
				bool forceToResizeWindow;
				lock (@lock)
				{
					forceToResizeWindow = this._ForceToResizeWindow;
				}
				return forceToResizeWindow;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._ForceToResizeWindow = value;
				}
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000279C File Offset: 0x0000099C
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000027A9 File Offset: 0x000009A9
		public Keys SequenceKey
		{
			get
			{
				return this._KeySequenceListener.SequenceKey;
			}
			set
			{
				this._KeySequenceListener.SequenceKey = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000027B7 File Offset: 0x000009B7
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000027C4 File Offset: 0x000009C4
		public uint SequenceLength
		{
			get
			{
				return this._KeySequenceListener.SequenceLength;
			}
			set
			{
				this._KeySequenceListener.SequenceLength = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000027D2 File Offset: 0x000009D2
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000027DF File Offset: 0x000009DF
		public uint SequenceTimeout
		{
			get
			{
				return this._KeySequenceListener.SequenceTimeout;
			}
			set
			{
				this._KeySequenceListener.SequenceTimeout = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000027F0 File Offset: 0x000009F0
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00002834 File Offset: 0x00000A34
		public bool CenterOnPrimaryScreen
		{
			get
			{
				object @lock = this._Lock;
				bool centerOnPrimaryScreen;
				lock (@lock)
				{
					centerOnPrimaryScreen = this._CenterOnPrimaryScreen;
				}
				return centerOnPrimaryScreen;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._CenterOnPrimaryScreen = value;
				}
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002878 File Offset: 0x00000A78
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000028BC File Offset: 0x00000ABC
		public Localization.Language Language
		{
			get
			{
				object @lock = this._Lock;
				Localization.Language language;
				lock (@lock)
				{
					language = this._Language;
				}
				return language;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._Language = value;
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002900 File Offset: 0x00000B00
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002908 File Offset: 0x00000B08
		public Services ActiveServices
		{
			get
			{
				return this._ActiveServices;
			}
			set
			{
				this._ActiveServices = value;
				this._Init(value);
			}
		}

		// Token: 0x0400001F RID: 31
		internal const int SHORT_EXECUTION_INTERVAL = 30;

		// Token: 0x04000020 RID: 32
		internal const int STANDARD_EXECUTION_INTERVAL = 300;

		// Token: 0x04000021 RID: 33
		private bool _HelpMeDecide;

		// Token: 0x04000022 RID: 34
		private uint _WindowWidth;

		// Token: 0x04000023 RID: 35
		private uint _WindowHeight;

		// Token: 0x04000024 RID: 36
		private bool _CustomWindowWidth;

		// Token: 0x04000025 RID: 37
		private bool _CustomWindowHeight;

		// Token: 0x04000026 RID: 38
		private bool _ForceToResizeWindow;

		// Token: 0x04000027 RID: 39
		private Services _ActiveServices;

		// Token: 0x04000028 RID: 40
		private readonly object _Lock;

		// Token: 0x04000029 RID: 41
		private readonly WindowListener _WindowListener;

		// Token: 0x0400002A RID: 42
		private readonly KeySquenceListener _KeySequenceListener;

		// Token: 0x0400002B RID: 43
		private bool _CenterOnPrimaryScreen;

		// Token: 0x0400002C RID: 44
		private Localization.Language _Language;
	}
}
