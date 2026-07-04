using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace WindowCenteringNext.Core
{
	// Token: 0x02000009 RID: 9
	internal sealed class KeySquenceListener
	{
		// Token: 0x0600003D RID: 61 RVA: 0x0000292E File Offset: 0x00000B2E
		internal KeySquenceListener()
		{
			this._Lock = new object();
			this._FirstInit = true;
			this._PressedKeys = new Queue<Keys>();
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600003E RID: 62 RVA: 0x00002954 File Offset: 0x00000B54
		// (remove) Token: 0x0600003F RID: 63 RVA: 0x0000298C File Offset: 0x00000B8C
		internal event KeySquenceListener.Callback SequenceReleased;

		// Token: 0x06000040 RID: 64 RVA: 0x000029C1 File Offset: 0x00000BC1
		internal void Start()
		{
			if (this._Thread != null && this._Thread.IsAlive)
			{
				this._Close();
			}
			this._Init();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000029E4 File Offset: 0x00000BE4
		internal void Close()
		{
			if (this._Thread != null && this._Thread.IsAlive)
			{
				this._Close();
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002A04 File Offset: 0x00000C04
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

		// Token: 0x06000043 RID: 67 RVA: 0x00002A54 File Offset: 0x00000C54
		private void _Init()
		{
			object @lock = this._Lock;
			lock (@lock)
			{
				if (this._FirstInit)
				{
					Hook.GlobalEvents().KeyUp += delegate(object Instance, KeyEventArgs Arguments)
					{
						object lock2 = this._Lock;
						lock (lock2)
						{
							if (Arguments.KeyCode == this._SequenceKey)
							{
								this._PressedKeys.Enqueue(Arguments.KeyCode);
							}
						}
					};
					this._FirstInit = false;
				}
			}
			this._Thread = new Thread(new ThreadStart(delegate
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				for (;;)
				{
					object lock3 = this._Lock;
					lock (lock3)
					{
						if (!this._Loop)
						{
							break;
						}
						if (stopwatch.Elapsed.TotalMilliseconds >= (double)this._SequenceTimeout || this._PressedKeys.Count == 0)
						{
							stopwatch.Restart();
							this._PressedKeys.Clear();
						}
						else if (this._PressedKeys.Count == this._SequenceLength)
						{
							KeySquenceListener.Callback sequenceReleased = this.SequenceReleased;
							if (sequenceReleased != null)
							{
								sequenceReleased();
							}
							stopwatch.Restart();
							this._PressedKeys.Clear();
						}
					}
					Thread.Sleep(30);
				}
			}));
			this._Loop = true;
			this._PressedKeys.Clear();
			this._Thread.Start();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002AE8 File Offset: 0x00000CE8
		private void _Close()
		{
			Hook.GlobalEvents().Dispose();
			object @lock = this._Lock;
			lock (@lock)
			{
				this._Loop = false;
			}
			while (this._Thread.IsAlive)
			{
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002B40 File Offset: 0x00000D40
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002B84 File Offset: 0x00000D84
		internal Keys SequenceKey
		{
			get
			{
				object @lock = this._Lock;
				Keys sequenceKey;
				lock (@lock)
				{
					sequenceKey = this._SequenceKey;
				}
				return sequenceKey;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._SequenceKey = value;
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002BC8 File Offset: 0x00000DC8
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002C0C File Offset: 0x00000E0C
		internal uint SequenceTimeout
		{
			get
			{
				object @lock = this._Lock;
				uint sequenceTimeout;
				lock (@lock)
				{
					sequenceTimeout = (uint)this._SequenceTimeout;
				}
				return sequenceTimeout;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._SequenceTimeout = (int)value;
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002C50 File Offset: 0x00000E50
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002C94 File Offset: 0x00000E94
		internal uint SequenceLength
		{
			get
			{
				object @lock = this._Lock;
				uint sequenceLength;
				lock (@lock)
				{
					sequenceLength = (uint)this._SequenceLength;
				}
				return sequenceLength;
			}
			set
			{
				object @lock = this._Lock;
				lock (@lock)
				{
					this._SequenceLength = (int)value;
				}
			}
		}

		// Token: 0x0400002E RID: 46
		internal const int EXECUTION_INTERVAL = 30;

		// Token: 0x0400002F RID: 47
		private bool _Loop;

		// Token: 0x04000030 RID: 48
		private bool _FirstInit;

		// Token: 0x04000031 RID: 49
		private int _SequenceTimeout;

		// Token: 0x04000032 RID: 50
		private int _SequenceLength;

		// Token: 0x04000033 RID: 51
		private Keys _SequenceKey;

		// Token: 0x04000034 RID: 52
		private Thread _Thread;

		// Token: 0x04000035 RID: 53
		private readonly object _Lock;

		// Token: 0x04000036 RID: 54
		private readonly Queue<Keys> _PressedKeys;

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x060000AA RID: 170
		internal delegate void Callback();
	}
}
