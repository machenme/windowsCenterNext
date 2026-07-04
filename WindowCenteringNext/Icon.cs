using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WindowCenteringNext.Core;
using Microsoft.Win32;

namespace WindowCenteringNext
{
// Token: 0x0200000D RID: 13
internal sealed class Icon : ApplicationContext
{
	// Token: 0x06000077 RID: 119 RVA: 0x00003272 File Offset: 0x00001472
	internal Icon()
	{
		this._Init();
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00003280 File Offset: 0x00001480
	private void _Init()
	{
		CenteringHelper Core = new CenteringHelper();
		NotifyIcon Icon = new NotifyIcon();
		Config config = null;
		try
		{
			using (FileStream fileStream = File.OpenRead(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindowCenteringNext.ini")))
			{
				config = (Config)new BinaryFormatter().Deserialize(fileStream);
			}
		}
		catch
		{
			config = new Config();
			config.ActiveServices = Services.OnKeySequence | Services.Automatically;
			config.CustomWindowWidth = false;
			config.CustomWindowHeight = false;
			config.WindowWidth = 88;
			config.WindowHeight = 88;
			config.ForceToResizeWindow = false;
			config.OnlyNewWindow = true;
			config.HelpMeDecide = true;
			config.CenterOnPrimaryScreen = true;
			config.Language = Localization.Language.English;
			config.Key = Keys.LShiftKey.ToString();
			config.Times = 3;
			config.Timeout = 1050;
			config.FirstRun = true;
		config.AutoStart = false;
		}
		finally
		{
			Core.ActiveServices = config.ActiveServices;
			Core.CustomWindowWidth = config.CustomWindowWidth;
			Core.CustomWindowHeight = config.CustomWindowHeight;
			Core.WindowWidth = (uint)config.WindowWidth;
			Core.WindowHeight = (uint)config.WindowHeight;
			Core.ForceToResizeWindow = config.ForceToResizeWindow;
			Core.OnlyNewWindow = config.OnlyNewWindow;
			Core.HelpMeDecide = config.HelpMeDecide;
			Core.CenterOnPrimaryScreen = config.CenterOnPrimaryScreen;
			Core.Language = config.Language;
			Core.SequenceKey = (Keys)Enum.Parse(typeof(Keys), config.Key);
			Core.SequenceLength = (uint)config.Times;
			Core.SequenceTimeout = (uint)config.Timeout;
		}
		UI UI = new UI(Core, config);
				Icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
		Icon.MouseClick += delegate(object Instance, MouseEventArgs Arguments)
		{
			if (Arguments.Button != MouseButtons.Left)
			{
				return;
			}
			UI.Show();
			UI.Activate();
		};
		ContextMenuStrip menu = new ContextMenuStrip();
		ToolStripMenuItem exitItem = new ToolStripMenuItem(Localization.GetText("Terminate services and Close", config.Language));
		exitItem.Click += delegate
		{
			Icon.Visible = false;
			Application.Exit();
		};
		menu.Items.Add(exitItem);
		Icon.ContextMenuStrip = menu;
		UI.FormClosed += delegate(object Instance, FormClosedEventArgs Arguments)
		{
			try
			{
				Config config2 = new Config();
				config2.ActiveServices = Core.ActiveServices;
				config2.CustomWindowWidth = Core.CustomWindowWidth;
				config2.CustomWindowHeight = Core.CustomWindowHeight;
				config2.WindowWidth = (int)Core.WindowWidth;
				config2.WindowHeight = (int)Core.WindowHeight;
				config2.ForceToResizeWindow = Core.ForceToResizeWindow;
				config2.OnlyNewWindow = Core.OnlyNewWindow;
				config2.HelpMeDecide = Core.HelpMeDecide;
				config2.CenterOnPrimaryScreen = Core.CenterOnPrimaryScreen;
				config2.Language = Core.Language;
				config2.Key = Core.SequenceKey.ToString();
				config2.Times = (int)Core.SequenceLength;
				config2.Timeout = (int)Core.SequenceTimeout;
				config2.FirstRun = false;
		config2.AutoStart = config.AutoStart;
				using (FileStream fileStream2 = File.Open(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindowCenteringNext.ini"), FileMode.Create))
				{
					new BinaryFormatter().Serialize(fileStream2, config2);
				}
			}
			catch
			{
			}
			Icon.Visible = false;
			Application.Exit();
		};
		Icon.Visible = true;
		AutoStart.SetAutoStart(config.AutoStart);
		if (config.FirstRun)
		{
			config.FirstRun = false;
			Icon.ShowBalloonTip(5000, "First Run", string.Format("Press {0} x [{1}] to center a window", config.Times, config.Key), ToolTipIcon.None);
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00003534 File Offset: 0x00001734
	private void RepaintIcon(Bitmap image)
	{
		Color color;
		try
		{
			if (!((string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion").GetValue("ProductName")).Contains("Windows 10"))
			{
				return;
			}
			string text = "ImmersiveApplicationBackground";
			uint immersiveUserColorSetPreference = Icon.GetImmersiveUserColorSetPreference(false, false);
			uint immersiveColorTypeFromName = Icon.GetImmersiveColorTypeFromName(text);
			int immersiveColorFromColorSetEx = (int)Icon.GetImmersiveColorFromColorSetEx(immersiveUserColorSetPreference, immersiveColorTypeFromName, false, 0U);
			byte[] array = new byte[]
			{
				(byte)((uint)(-16777216 & immersiveColorFromColorSetEx) >> 24),
				(byte)((16711680 & immersiveColorFromColorSetEx) >> 16),
				(byte)((65280 & immersiveColorFromColorSetEx) >> 8),
				(byte)(255 & immersiveColorFromColorSetEx)
			};
			int num = ((int)array[3] << 16) | ((int)array[2] << 8) | (int)array[1];
			color = Color.FromArgb((num >> 16) & 255, (num >> 8) & 255, num & 255);
		}
		catch
		{
			return;
		}
		if (color.R < 60 && color.G < 60 && color.B < 60)
		{
			color = Color.White;
		}
		else
		{
			color = Color.Black;
		}
		for (int i = 0; i < image.Height; i++)
		{
			for (int j = 0; j < image.Width; j++)
			{
				if (image.GetPixel(j, i).A == 255)
				{
					image.SetPixel(j, i, color);
					if (j > 0) { image.SetPixel(j - 1, i, color); }
				}
			}
		}
	}

	// Token: 0x0600007A RID: 122
	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "#94")]
	private static extern int GetImmersiveColorSetCount();

	// Token: 0x0600007B RID: 123
	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "#95")]
	private static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);

	// Token: 0x0600007C RID: 124
	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "#96")]
	private static extern uint GetImmersiveColorTypeFromName(string name);

	// Token: 0x0600007D RID: 125
	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "#98")]
	private static extern uint GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

	// Token: 0x0600007E RID: 126
	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "#100")]
	private static extern IntPtr GetImmersiveColorNamedTypeByIndex(uint dwIndex);
}
}
