using System;
using System.Collections.Generic;

namespace WindowCenteringNext
{
	// Token: 0x0200000E RID: 14
	public static class Localization
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000036A4 File Offset: 0x000018A4
		static Localization()
		{
			Localization.Add("Window Centering Next", "窗口居中助手");
			Localization.Add("Services", "服务");
			Localization.Add("General", "常规设置");
			Localization.Add("Automatically", "自动居中");
			Localization.Add("On Key Sequence", "快捷键居中");
			Localization.Add("About", "关于");
			Localization.Add("window will be centered automatically", "窗口将自动居中");
			Localization.Add("window will be centered on sequence", "按键序列触发时窗口将居中");
			Localization.Add("Only new window", "仅新窗口");
			Localization.Add("Force to resize non-resizable window", "强制调整不可缩放窗口");
			Localization.Add("Help me decide which window should be excluded", "智能判断应排除的窗口");
			Localization.Add("Very short reaction time", "极短响应时间");
			Localization.Add("Center on primary screen", "在主显示器居中");
			Localization.Add("turn off to center on current screen", "关闭开关则在窗口当前所在屏幕居中");
			Localization.Add("recommended", "推荐");
			Localization.Add("not recommended", "不推荐");
			Localization.Add("Window width: ", "窗口宽度: ");
			Localization.Add("Window height: ", "窗口高度: ");
			Localization.Add("Timeout: ", "超时: ");
			Localization.Add("Times: ", "次数: ");
			Localization.Add("Key: ", "按键: ");
			Localization.Add("ver.", "版本");
			Localization.Add("author", "作者");
			Localization.Add("license", "许可");
			Localization.Add("Freeware", "免费软件");
			Localization.Add("MouseKeyHook", "鼠标键盘钩子");
			Localization.Add("Terminate services and Close", "终止服务并关闭");
			Localization.Add("Language", "语言");
		Localization.Add("Start with Windows", "开机自启动");
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003869 File Offset: 0x00001A69
		private static void Add(string en, string zh)
		{
			Localization.EnglishDict[en] = en;
			Localization.ChineseDict[en] = zh;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003883 File Offset: 0x00001A83
		internal static string GetText(string key, Localization.Language language)
		{
			if (language == Localization.Language.简体中文 && Localization.ChineseDict.ContainsKey(key))
			{
				return Localization.ChineseDict[key];
			}
			if (!Localization.EnglishDict.ContainsKey(key))
			{
				return key;
			}
			return Localization.EnglishDict[key];
		}

		// Token: 0x04000050 RID: 80
		private static readonly Dictionary<string, string> EnglishDict = new Dictionary<string, string>();

		// Token: 0x04000051 RID: 81
		private static readonly Dictionary<string, string> ChineseDict = new Dictionary<string, string>();

		// Token: 0x0200001A RID: 26
		public enum Language
		{
			// Token: 0x040000C8 RID: 200
			English,
			// Token: 0x040000C9 RID: 201
			简体中文
		}
	}
}
