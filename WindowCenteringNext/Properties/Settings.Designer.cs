using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace WindowCenteringNext.Properties
{
	// Token: 0x02000013 RID: 19
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "18.6.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00009162 File Offset: 0x00007362
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000B9 RID: 185
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
