using System;
using WindowCenteringNext.Core;

namespace WindowCenteringNext
{
	// Token: 0x0200000C RID: 12
	[Serializable]
	internal sealed class Config
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00003184 File Offset: 0x00001384
		// (set) Token: 0x0600005B RID: 91 RVA: 0x0000318C File Offset: 0x0000138C
		internal Services ActiveServices { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003195 File Offset: 0x00001395
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000319D File Offset: 0x0000139D
		internal bool CustomWindowWidth { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000031A6 File Offset: 0x000013A6
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000031AE File Offset: 0x000013AE
		internal bool CustomWindowHeight { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000031B7 File Offset: 0x000013B7
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000031BF File Offset: 0x000013BF
		internal int WindowWidth { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000031C8 File Offset: 0x000013C8
		// (set) Token: 0x06000063 RID: 99 RVA: 0x000031D0 File Offset: 0x000013D0
		internal int WindowHeight { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000031D9 File Offset: 0x000013D9
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000031E1 File Offset: 0x000013E1
		internal bool ForceToResizeWindow { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000031EA File Offset: 0x000013EA
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000031F2 File Offset: 0x000013F2
		internal bool HelpMeDecide { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000031FB File Offset: 0x000013FB
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00003203 File Offset: 0x00001403
		internal bool OnlyNewWindow { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000320C File Offset: 0x0000140C
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00003214 File Offset: 0x00001414
		internal string Key { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000321D File Offset: 0x0000141D
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00003225 File Offset: 0x00001425
		internal int Times { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000322E File Offset: 0x0000142E
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00003236 File Offset: 0x00001436
		internal int Timeout { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000070 RID: 112 RVA: 0x0000323F File Offset: 0x0000143F
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00003247 File Offset: 0x00001447
		internal bool FirstRun { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00003250 File Offset: 0x00001450
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00003258 File Offset: 0x00001458
		internal bool CenterOnPrimaryScreen { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003261 File Offset: 0x00001461
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00003269 File Offset: 0x00001469
		internal Localization.Language Language { get; set; }

		internal bool AutoStart { get; set; }
	}
}
