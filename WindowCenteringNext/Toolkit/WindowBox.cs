using System;

namespace WindowCenteringNext.Toolkit
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public sealed class WindowBox
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002050 File Offset: 0x00000250
		internal WindowBox(int X, int Y, int Width, int Height)
		{
			this._X = X;
			this._Y = Y;
			this._Width = Width;
			this._Height = Height;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002075 File Offset: 0x00000275
		public int X
		{
			get
			{
				return this._X;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000207D File Offset: 0x0000027D
		public int Y
		{
			get
			{
				return this._Y;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002085 File Offset: 0x00000285
		public int Width
		{
			get
			{
				return this._Width;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000208D File Offset: 0x0000028D
		public int Height
		{
			get
			{
				return this._Height;
			}
		}

		// Token: 0x04000003 RID: 3
		private readonly int _X;

		// Token: 0x04000004 RID: 4
		private readonly int _Y;

		// Token: 0x04000005 RID: 5
		private readonly int _Width;

		// Token: 0x04000006 RID: 6
		private readonly int _Height;
	}
}
