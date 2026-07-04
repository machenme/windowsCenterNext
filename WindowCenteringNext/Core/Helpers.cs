using System;

namespace WindowCenteringNext.Core
{
	// Token: 0x02000008 RID: 8
	internal class Helpers
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00002918 File Offset: 0x00000B18
		internal static int PercentOf(int ScreenSize, int Percent)
		{
			return (int)((float)ScreenSize * ((float)Percent / 100f));
		}
	}
}
