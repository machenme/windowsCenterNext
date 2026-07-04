; Inno Setup script for Window Centering Next
; Download Inno Setup 6.x from: https://jrsoftware.org/isdl.php

#define MyAppName "Window Centering Next"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "KamilSzymborski"
#define MyAppURL "https://kamilszymborski.github.io"
#define MyAppExeName "WindowCenteringNext.exe"

[Setup]
AppId={{B710C43E-446D-4B4C-9CE8-0F9FDED11D55}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppSupportURL={#MyAppURL}
DefaultDirName={userpf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=..\installer
OutputBaseFilename=WindowCenteringNext-Setup-{#MyAppVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=lowest
UninstallDisplayIcon={app}\{#MyAppExeName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "chinesesimplified"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin\Release\*.config"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function IsDotNet48Installed: Boolean;
var
  Release: Cardinal;
begin
  Result := RegQueryDWordValue(
    HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full',
    'Release', Release) and (Release >= 528040);
end;

function InitializeSetup: Boolean;
begin
  if not IsDotNet48Installed then
  begin
    MsgBox('.NET Framework 4.8 is required.' + #13#10 +
           'Please install it from Microsoft and run this setup again.',
           mbCriticalError, MB_OK);
    Result := False;
  end
  else
    Result := True;
end;
