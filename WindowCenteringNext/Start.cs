using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowCenteringNext
{
	// Token: 0x02000010 RID: 16
	internal static class Start
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00003912 File Offset: 0x00001B12
		[STAThread]
		private static void Main()
		{
			Start.SetProcessDPIAware();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Icon());
		}

		// Token: 0x06000088 RID: 136
		[DllImport("user32.dll")]
		internal static extern bool SetProcessDPIAware();
	}
}
