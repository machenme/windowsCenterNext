using Microsoft.Win32;

namespace WindowCenteringNext
{
	internal static class AutoStart
	{
		private const string AppName = "WindowCenteringNext";
		private const string RunKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

		internal static void SetAutoStart(bool enable)
		{
			try
			{
				using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath, true))
				{
					if (key == null) return;

					if (enable)
					{
						string appPath = System.Windows.Forms.Application.ExecutablePath;
						key.SetValue(AppName, $"\"{appPath}\"");
					}
					else
					{
						if (key.GetValue(AppName) != null)
							key.DeleteValue(AppName);
					}
				}
			}
			catch
			{
				// 静默失败，不弹窗干扰用户
			}
		}

		internal static bool IsAutoStartEnabled()
		{
			try
			{
				using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath, false))
				{
					return key?.GetValue(AppName) != null;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
