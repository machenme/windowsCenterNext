using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowCenteringNext.Core;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Drawing;

namespace WindowCenteringNext
{
	// Token: 0x02000011 RID: 17
	public partial class UI : Form
	{
		// Token: 0x06000089 RID: 137 RVA: 0x0000392F File Offset: 0x00001B2F
		internal UI(CenteringHelper Core, Config Cfg)
		{
			this.InitializeComponent();
			this._Core = Core;
			this.Cfg = Cfg;
			this._Init();
			base.Shown += this.UI_Shown;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003964 File Offset: 0x00001B64
		private void UI_Shown(object sender, EventArgs e)
		{
			this.metroToggle1.Checked = this.Cfg.ActiveServices.HasFlag(Services.Automatically);
			this.metroToggle2.Checked = this.Cfg.ActiveServices.HasFlag(Services.OnKeySequence);
			this.metroToggle4.Checked = this.Cfg.CustomWindowWidth;
			this.label15.Text = string.Format("窗口宽度: [{0}%]", this.Cfg.WindowWidth);
			this.label8.Text = string.Format("窗口高度: [{0}%]", this.Cfg.WindowHeight);
			this.metroTrackBar1.Value = this.Cfg.WindowWidth / 2;
			this.metroToggle7.Checked = this.Cfg.CustomWindowHeight;
			this.metroTrackBar3.Value = this.Cfg.WindowHeight / 2;
			this.metroToggle6.Checked = this.Cfg.ForceToResizeWindow;
			this.metroToggle5.Checked = this.Cfg.OnlyNewWindow;
			this.metroToggle9.Checked = this.Cfg.HelpMeDecide;
			this.metroToggle10.Checked = this.Cfg.CenterOnPrimaryScreen;
			this.metroToggle11.Checked = this.Cfg.AutoStart;
			this.metroTrackBar2.Value = (int)((Keys)Enum.Parse(typeof(Keys), this.Cfg.Key));
			this.label21.Text = "按键: [" + this.Cfg.Key.ToString() + "]";
			this.metroTrackBar5.Value = this.Cfg.Times;
			this.label20.Text = string.Format("次数: [{0}]", this.Cfg.Times);
			this.metroTrackBar4.Value = this.Cfg.Timeout / 50;
			this.label6.Text = string.Format("超时: [{0} ms]", this.Cfg.Timeout);
			this.metroComboBox1.SelectedIndex = (int)this.Cfg.Language;
			this.RefreshTexts();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003BA4 File Offset: 0x00001DA4
		private void _Init()
		{
			this.linkLabel1.BackColor = GlobalMetroColor.Color;
			this.linkLabel2.Click += delegate(object Instance, EventArgs Arguments)
			{
				Application.Exit();
			};
			this.linkLabel1.Click += delegate(object Instance, EventArgs Arguments)
			{
				Process.Start("https://kamilszymborski.github.io");
			};
			this.metroToggle1.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				if (this.metroToggle1.Checked)
				{
					this.metroProgressBar5.Visible = true;
				}
				else
				{
					this.metroProgressBar5.Visible = false;
				}
				Services services = Services.None;
				if (this.metroToggle1.Checked)
				{
					services |= Services.Automatically;
				}
				if (this.metroToggle2.Checked)
				{
					services |= Services.OnKeySequence;
				}
				this._Core.ActiveServices = services;
			};
			this.metroToggle2.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				if (this.metroToggle2.Checked)
				{
					this.metroProgressBar1.Visible = true;
				}
				else
				{
					this.metroProgressBar1.Visible = false;
				}
				Services services2 = Services.None;
				if (this.metroToggle1.Checked)
				{
					services2 |= Services.Automatically;
				}
				if (this.metroToggle2.Checked)
				{
					services2 |= Services.OnKeySequence;
				}
				this._Core.ActiveServices = services2;
			};
			this.metroToggle4.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.CustomWindowWidth = this.metroToggle4.Checked;
			};
			this.metroTrackBar1.Maximum = 50;
			this.metroTrackBar1.ValueChanged += delegate(object Instance, EventArgs Arguments)
			{
				if (this.metroTrackBar1.Value * 2 <= 40)
				{
					this.metroTrackBar1.Style = MetroColorStyle.Red;
				}
				else if (this.metroTrackBar1.Value * 2 <= 60)
				{
					this.metroTrackBar1.Style = MetroColorStyle.Yellow;
				}
				else if (this.metroTrackBar1.Value * 2 == 98)
				{
					this.metroTrackBar1.Style = MetroColorStyle.Yellow;
				}
				else if (this.metroTrackBar1.Value * 2 == 100)
				{
					this.metroTrackBar1.Style = MetroColorStyle.Red;
				}
				else
				{
					this.metroTrackBar1.Style = MetroColorStyle.System;
				}
				this.label15.Text = string.Format(Localization.GetText("Window width: ", this._Core.Language) + "[{0}%]", this.metroTrackBar1.Value * 2);
				this._Core.WindowWidth = (uint)(this.metroTrackBar1.Value * 2);
			};
			this.metroToggle7.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.CustomWindowHeight = this.metroToggle7.Checked;
			};
			this.metroTrackBar3.Maximum = 50;
			this.metroTrackBar3.ValueChanged += delegate(object Instance, EventArgs Arguments)
			{
				if (this.metroTrackBar3.Value * 2 <= 40)
				{
					this.metroTrackBar3.Style = MetroColorStyle.Red;
				}
				else if (this.metroTrackBar3.Value * 2 <= 60)
				{
					this.metroTrackBar3.Style = MetroColorStyle.Yellow;
				}
				else if (this.metroTrackBar3.Value * 2 == 98)
				{
					this.metroTrackBar3.Style = MetroColorStyle.Yellow;
				}
				else if (this.metroTrackBar3.Value * 2 == 100)
				{
					this.metroTrackBar3.Style = MetroColorStyle.Red;
				}
				else
				{
					this.metroTrackBar3.Style = MetroColorStyle.System;
				}
				this.label8.Text = string.Format(Localization.GetText("Window height: ", this._Core.Language) + "[{0}%]", this.metroTrackBar3.Value * 2);
				this._Core.WindowHeight = (uint)(this.metroTrackBar3.Value * 2);
			};
			this.metroToggle6.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.ForceToResizeWindow = this.metroToggle6.Checked;
			};
			this.metroToggle5.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.OnlyNewWindow = this.metroToggle5.Checked;
			};
			this.metroToggle10.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.CenterOnPrimaryScreen = this.metroToggle10.Checked;
			};
			this.metroToggle9.CheckedChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.HelpMeDecide = this.metroToggle9.Checked;
			};
			this.metroTrackBar2.Maximum = Enum.GetNames(typeof(Keys)).Count<string>();
			this.metroTrackBar2.ValueChanged += delegate(object Instance, EventArgs Arguments)
			{
				this.label21.Text = string.Format(Localization.GetText("Key: ", this._Core.Language) + "[{0}]", (Keys)this.metroTrackBar2.Value);
				this._Core.SequenceKey = (Keys)this.metroTrackBar2.Value;
			};
			this.metroTrackBar5.Maximum = 5;
			this.metroTrackBar5.ValueChanged += delegate(object Instance, EventArgs Arguments)
			{
				this.label20.Text = string.Format(Localization.GetText("Times: ", this._Core.Language) + "[{0}]", this.metroTrackBar5.Value);
				this._Core.SequenceLength = (uint)this.metroTrackBar5.Value;
			};
			this.metroTrackBar4.Maximum = 40;
			this.metroTrackBar4.Minimum = 2;
			this.metroTrackBar4.ValueChanged += delegate(object Instance, EventArgs Arguments)
			{
				this.label6.Text = string.Format(Localization.GetText("Timeout: ", this._Core.Language) + "[{0} ms]", this.metroTrackBar4.Value * 50);
				this._Core.SequenceTimeout = (uint)(this.metroTrackBar4.Value * 50);
			};
			base.FormClosing += delegate(object Instance, FormClosingEventArgs Arguments)
			{
				if (Arguments.CloseReason == CloseReason.UserClosing)
				{
					Arguments.Cancel = true;
					base.Hide();
					return;
				}
				Arguments.Cancel = false;
				this._Core.Close();
			};
			this.metroComboBox1.SelectedIndexChanged += delegate(object Instance, EventArgs Arguments)
			{
				this._Core.Language = (Localization.Language)this.metroComboBox1.SelectedIndex;
				this.Cfg.Language = this._Core.Language;
				this.RefreshTexts();
			};
				// 开机自启动开关
				this.metroToggle11 = new MetroToggle();
				this.labelAutoStart = new Label();
				Panel panelAutoStart = new Panel();
				TableLayoutPanel tableAutoStart = new TableLayoutPanel();

				tableAutoStart.AutoSize = true;
				tableAutoStart.ColumnCount = 1;
				tableAutoStart.Dock = DockStyle.Top;
				tableAutoStart.RowCount = 2;
				tableAutoStart.Controls.Add(this.metroToggle11, 0, 0);
				tableAutoStart.Controls.Add(panelAutoStart, 0, 1);

				this.metroToggle11.DisplayStatus = true;
				this.metroToggle11.Location = new Point(3, 3);
				this.metroToggle11.Name = "metroToggle11";
				this.metroToggle11.Size = new Size(80, 30);
				this.metroToggle11.Style = MetroColorStyle.System;
				this.metroToggle11.Theme = MetroThemeStyle.Dark;
				this.metroToggle11.UseSelectable = true;

				panelAutoStart.AutoSize = true;
				panelAutoStart.BackColor = Color.White;
				panelAutoStart.Controls.Add(this.labelAutoStart);
				panelAutoStart.Dock = DockStyle.Top;
				panelAutoStart.Location = new Point(3, 19);
				panelAutoStart.Name = "panelAutoStart";
				panelAutoStart.Padding = new Padding(3);
				panelAutoStart.Size = new Size(542, 40);

				this.labelAutoStart.AutoSize = true;
				this.labelAutoStart.Font = new Font("Microsoft YaHei UI", 8.5f, FontStyle.Regular);
				this.labelAutoStart.ForeColor = Color.FromArgb(100, 100, 100);
				this.labelAutoStart.Dock = DockStyle.Fill;
				this.labelAutoStart.Location = new Point(0, 0);
				this.labelAutoStart.Name = "labelAutoStart";
				this.labelAutoStart.Text = Localization.GetText("Start with Windows", this._Core.Language);

				this.metroPanel8.Controls.Add(tableAutoStart);

				this.metroToggle11.CheckedChanged += delegate
				{
					this.Cfg.AutoStart = this.metroToggle11.Checked;
					AutoStart.SetAutoStart(this.metroToggle11.Checked);
				};
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003DC8 File Offset: 0x00001FC8
		private void RefreshTexts()
		{
			Localization.Language lang = this._Core.Language;
			this.Text = Localization.GetText("Window Centering Next", lang);
			this.label1.Text = Localization.GetText("Services", lang);
			this.label9.Text = Localization.GetText("General", lang);
			this.label10.Text = Localization.GetText("Automatically", lang);
			this.label5.Text = Localization.GetText("On Key Sequence", lang);
			this.label30.Text = Localization.GetText("About", lang);
			this.label4.Text = Localization.GetText("On Key Sequence", lang);
			this.label7.Text = Localization.GetText("Automatically", lang);
			this.label2.Text = Localization.GetText("window will be centered automatically", lang);
			this.label3.Text = Localization.GetText("window will be centered on sequence", lang);
			this.label14.Text = Localization.GetText("Only new window", lang);
			this.label12.Text = Localization.GetText("Force to resize non-resizable window", lang);
			this.label19.Text = Localization.GetText("Help me decide which window should be excluded", lang);
			this.label17.Text = Localization.GetText("Very short reaction time", lang);
			this.label32.Text = Localization.GetText("Center on primary screen", lang);
			this.label31.Text = Localization.GetText("turn off to center on current screen", lang);
			this.label15.Text = string.Format(Localization.GetText("Window width: ", lang) + "[{0}%]", this.metroTrackBar1.Value * 2);
			this.label8.Text = string.Format(Localization.GetText("Window height: ", lang) + "[{0}%]", this.metroTrackBar3.Value * 2);
			this.label20.Text = string.Format(Localization.GetText("Times: ", lang) + "[{0}]", this.metroTrackBar5.Value);
			this.label6.Text = string.Format(Localization.GetText("Timeout: ", lang) + "[{0} ms]", this.metroTrackBar4.Value * 50);
			this.label21.Text = Localization.GetText("Key: ", lang) + "[" + ((Keys)this.metroTrackBar2.Value).ToString() + "]";
			this.label27.Text = Localization.GetText("author", lang);
			this.label25.Text = Localization.GetText("license", lang);
			this.label24.Text = Localization.GetText("Freeware", lang);
			this.label22.Text = Localization.GetText("ver.", lang);
			this.label29.Text = Localization.GetText("MouseKeyHook", lang);
			this.linkLabel2.Text = Localization.GetText("Terminate services and Close", lang);
			this.label33.Text = Localization.GetText("Language", lang);
			this.labelAutoStart.Text = Localization.GetText("Start with Windows", lang);
			this.label13.Text = Localization.GetText("recommended", lang);
			this.label18.Text = Localization.GetText("recommended", lang);
			this.label11.Text = Localization.GetText("not recommended", lang);
			this.label16.Text = Localization.GetText("not recommended", lang);
		}

		// Token: 0x04000054 RID: 84
		private readonly Config Cfg;

		// Token: 0x04000055 RID: 85
		private readonly CenteringHelper _Core;

	private MetroToggle metroToggle11;
	private Label labelAutoStart;
	}
}
