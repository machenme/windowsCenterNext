using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WindowCenteringNext
{
	// Token: 0x0200000F RID: 15
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "18.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Images
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00002926 File Offset: 0x00000B26
		internal Images()
		{
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000038BC File Offset: 0x00001ABC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Images.resourceMan == null)
				{
					Images.resourceMan = new ResourceManager("WindowCenteringNext.Images", typeof(Images).Assembly);
				}
				return Images.resourceMan;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000038E8 File Offset: 0x00001AE8
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000038EF File Offset: 0x00001AEF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Images.resourceCulture;
			}
			set
			{
				Images.resourceCulture = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000086 RID: 134 RVA: 0x000038F7 File Offset: 0x00001AF7
		internal static Bitmap Icon
		{
			get
			{
				return (Bitmap)Images.ResourceManager.GetObject("Icon", Images.resourceCulture);
			}
		}

		// Token: 0x04000052 RID: 82
		private static ResourceManager resourceMan;

		// Token: 0x04000053 RID: 83
		private static CultureInfo resourceCulture;
	}
}
