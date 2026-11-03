; =========================================================================
; KỊCH BẢN ĐÓNG GÓI BỘ CÀI ĐẶT INNO SETUP (SETUP WIZARD)
; DỰ ÁN: QUẢN LÝ BÁN HÀNG ONLINE (.NET FRAMEWORK 4.8)
; =========================================================================

#define MyAppName "Quản Lý Bán Hàng Online"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Đồ Án Lập Trình Windows"
#define MyAppURL "https://shoponline.vn"
#define MyAppExeName "QuanLyBanHangOnline.WinForms.exe"

[Setup]
; Thông tin nhận diện ứng dụng (GUID duy nhất)
AppId={{8B1F54E2-5B4B-4E7B-9E3E-7288A58D91D9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

; Thư mục cài đặt mặc định
DefaultDirName={autopf}\QuanLyBanHangOnline
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=License.txt
OutputDir=Output
OutputBaseFilename=Setup_QuanLyBanHangOnline_v1.0
SetupIconFile=app.ico

; Chuẩn nén tối ưu dung lượng
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern

; Thông tin gỡ cài đặt trong Control Panel / Windows Settings
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName=Gỡ cài đặt {#MyAppName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Tạo biểu tượng lối tắt trên Màn hình nền (Desktop Shortcut)"; GroupDescription: "Tùy chọn bổ sung:"

[Files]
; 1. Tệp thực thi chính và cấu hình App.config
Source: "..\QuanLyBanHangOnline.WinForms\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\QuanLyBanHangOnline.WinForms\bin\Debug\{#MyAppExeName}.config"; DestDir: "{app}"; Flags: ignoreversion

; 2. Toàn bộ thư viện DLL phụ thuộc (.NET Framework, ReportViewer, SqlServerTypes)
Source: "..\QuanLyBanHangOnline.WinForms\bin\Debug\*.dll"; DestDir: "{app}"; Flags: ignoreversion

; 3. Thư mục Báo cáo Microsoft ReportViewer (.RDLC)
Source: "..\QuanLyBanHangOnline.WinForms\bin\Debug\Reports\*"; DestDir: "{app}\Reports"; Flags: ignoreversion recursesubdirs createallsubdirs

; 4. Thư viện SqlServerTypes (Native Binaries cho ReportViewer)
Source: "..\QuanLyBanHangOnline.WinForms\bin\Debug\SqlServerTypes\*"; DestDir: "{app}\SqlServerTypes"; Flags: ignoreversion recursesubdirs createallsubdirs

; 5. Kịch bản Cơ Sở Dữ Liệu SQL Server (.sql) để tự động khởi tạo khi chạy lần đầu
Source: "..\Database\*"; DestDir: "{app}\Database"; Flags: ignoreversion recursesubdirs createallsubdirs

; 6. Biểu tượng và tệp hướng dẫn
Source: "app.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "License.txt"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
; Phím tắt Start Menu
Name: "{autoprograms}\{#MyAppName}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app.ico"
Name: "{autoprograms}\{#MyAppName}\⚙️ Cấu hình kết nối SQL (App.config)"; Filename: "{app}\{#MyAppExeName}"; Parameters: "--config"; IconFilename: "{app}\app.ico"
Name: "{autoprograms}\{#MyAppName}\📁 Thư mục kịch bản CSDL (Database)"; Filename: "{app}\Database"
Name: "{autoprograms}\{#MyAppName}\🗑️ Gỡ cài đặt {#MyAppName}"; Filename: "{uninstallexe}"

; Phím tắt Desktop
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\app.ico"

[Run]
; Tùy chọn chạy ứng dụng ngay sau khi cài đặt xong
Filename: "{app}\{#MyAppExeName}"; Description: "Khởi chạy {#MyAppName} ngay bây giờ"; Flags: nowait postinstall skipifsilent

[Code]
// =========================================================================
// KIỂM TRA THƯ VIỆN PHỤ THUỘC TRƯỚC KHI CÀI ĐẶT (.NET FRAMEWORK, SQL SERVER)
// =========================================================================

// 1. Kiểm tra Microsoft .NET Framework 4.8 qua Registry
function IsDotNet48Installed(): Boolean;
var
  Release: Cardinal;
begin
  Result := False;
  // Key Release >= 528040 tương ứng với .NET Framework 4.8
  if RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', Release) then
  begin
    Result := (Release >= 528040);
  end;
end;

// 2. Kiểm tra Hệ Quản Trị CSDL SQL Server hoặc SQL Server LocalDB
function IsSqlServerOrLocalDbInstalled(): Boolean;
var
  Names: TArrayOfString;
begin
  Result := False;
  // Kiểm tra LocalDB
  if RegGetSubkeyNames(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions', Names) then
  begin
    if GetArrayLength(Names) > 0 then
      Result := True;
  end;
  // Kiểm tra các bản cài SQL Server tiêu chuẩn / Express
  if not Result then
  begin
    if RegGetSubkeyNames(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', Names) then
    begin
      if GetArrayLength(Names) > 0 then
        Result := True;
    end;
  end;
end;

function InitializeSetup(): Boolean;
var
  Msg: String;
  ErrCode: Integer;
begin
  Result := True;

  // Kiểm tra .NET Framework 4.8
  if not IsDotNet48Installed() then
  begin
    Msg := 'CẢNH BÁO THƯ VIỆN PHỤ THUỘC:' + #13#10 + #13#10 +
           'Hệ thống phát hiện máy tính chưa cài đặt Microsoft .NET Framework 4.8.' + #13#10 +
           'Ứng dụng Quản Lý Bán Hàng Online yêu cầu .NET Framework 4.8 để có thể hoạt động ổn định.' + #13#10 + #13#10 +
           'Bạn có muốn mở trang web chính thức của Microsoft để tải .NET Framework 4.8 ngay không?';
    if MsgBox(Msg, mbConfirmation, MB_YESNO) = IDYES then
    begin
      ShellExec('open', 'https://dotnet.microsoft.com/download/dotnet-framework/net48', '', '', SW_SHOWNORMAL, ewNoWait, ErrCode);
    end;
  end;

  // Kiểm tra SQL Server / LocalDB
  if not IsSqlServerOrLocalDbInstalled() then
  begin
    Msg := 'THÔNG BÁO VỀ CƠ SỞ DỮ LIỆU SQL SERVER:' + #13#10 + #13#10 +
           '• Bộ cài đặt đã đính kèm sẵn toàn bộ File Kịch Bản CSDL (QuanLyBanHangOnline.sql).' + #13#10 +
           '• Ứng dụng tích hợp sẵn cơ chế "Auto-Database Initializer" tự động khởi tạo CSDL khi mở lần đầu.' + #13#10 +
           '• Nếu máy demo chưa cài SQL Server, ứng dụng sẽ tự động kích hoạt Chế Độ Dự Phòng Ngoại Tuyến (Offline Fallback) giúp quá trình thuyết trình không bị gián đoạn.' + #13#10 + #13#10 +
           'Bấm OK để tiếp tục quá trình cài đặt.';
    MsgBox(Msg, mbInformation, MB_OK);
  end;
end;
