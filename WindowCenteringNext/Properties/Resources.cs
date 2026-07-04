using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WindowCenteringNext.Properties
{
	// Token: 0x02000012 RID: 18
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "18.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00002926 File Offset: 0x00000B26
		internal Resources()
		{
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00009127 File Offset: 0x00007327
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("WindowCenteringNext.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00009153 File Offset: 0x00007353
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x0000915A File Offset: 0x0000735A
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x040000B7 RID: 183
		private static ResourceManager resourceMan;

		// Token: 0x040000B8 RID: 184
		private static CultureInfo resourceCulture;
	}
}
