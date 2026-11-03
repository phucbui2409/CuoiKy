@echo off
chcp 65001 > nul
echo =========================================================================
echo   TIẾN TRÌNH BIÊN DỊCH VÀ ĐÓNG GÓI BỘ CÀI ĐẶT SETUP WIZARD
echo   Dự án: Quản Lý Bán Hàng Online (.NET Framework 4.8)
echo =========================================================================
echo.

:: 1. Xác định đường dẫn Inno Setup Compiler (ISCC.exe)
set ISCC_PATH="%LOCALAPPDATA%\Programs\Inno Setup 6\ISCC.exe"
if not exist %ISCC_PATH% (
    set ISCC_PATH="C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
)
if not exist %ISCC_PATH% (
    set ISCC_PATH="C:\Program Files\Inno Setup 6\ISCC.exe"
)

if not exist %ISCC_PATH% (
    echo [LỖI] Không tìm thấy trình biên dịch Inno Setup (ISCC.exe).
    echo Vui lòng cài đặt Inno Setup 6 từ https://jrsoftware.org/isdl.php
    pause
    exit /b 1
)

:: 2. Biên dịch bộ cài đặt
echo Đang tiến hành đóng gói bộ cài đặt Setup_QuanLyBanHangOnline_v1.0.exe...
%ISCC_PATH% "Setup_QuanLyBanHangOnline.iss"

if %ERRORLEVEL% EQU 0 (
    echo.
    echo =========================================================================
    echo [THÀNH CÔNG] Đã tạo file cài đặt hoàn chỉnh tại:
    echo   Installer\Output\Setup_QuanLyBanHangOnline_v1.0.exe
    echo =========================================================================
) else (
    echo.
    echo [THẤT BẠI] Quá trình đóng gói gặp lỗi. Vui lòng kiểm tra lại.
)

echo.
pause
