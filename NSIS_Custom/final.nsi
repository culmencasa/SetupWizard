#====================== 头信息==============================
!define PRODUCT_NAME           		"MyProgram - Wizard"
!define PRODUCT_VERSION        		"1.0.0.0"
!define PRODUCT_PUBLISHER      		"Some Company"
!define PRODUCT_LEGAL          		"Copyright (C) SomeCompany 2019"
!define INSTALL_OUTPUT_NAME    		"Setuploader.exe"
!define NETVersion "4.5.1"
!define NETInstaller "DotNet451.exe"
!define INSTALL_ICO 			"logo.ico"
!define $INSTDIR  "$TEMP\wbInstTmpDir"
!define OutFileSignCertificate     "ycwh.pfx"
!define OutFileSignPassword      "A4301"

#xxxx.pfx证书需要购买, 这里只是签名
#!define OutFileSignSHA1 ".\SignTool sign /f .\${OutFileSignCertificate} /p ${OutFileSignPassword} /fd sha1   /t  http://timestamp.comodoca.com /v"

#!define OutFileSignSHA256 ".\SignTool sign /f .\${OutFileSignCertificate} /p ${OutFileSignPassword} /fd sha256 /tr http://timestamp.comodoca.com?td=sha256 /td sha256 /as /v"

#==================== NSIS属性 ================================
;语言支持
Unicode true

#加载语言包
LoadLanguageFile "${NSISDIR}\Contrib\Language files\SimpChinese.nlf"

#请求管理员权限
RequestExecutionLevel admin

Name "${PRODUCT_NAME} "

;输出程序名
OutFile ".\${INSTALL_OUTPUT_NAME}" 

;输出目录
InstallDir "$TEMP\wbInstTmpDir"

# 安装和卸载程序图标
;Icon              "${INSTALL_ICO}"
;UninstallIcon     "${INSTALL_ICO}"

;静默安装
SilentInstall silent  

#======================== 文件 ====================================
Section FilePreparing 

DetailPrint "1"

SectionEnd


# ========================检测.NET环境====================================
Function .onInit	

;解压临时文件
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer 
  File "SetupWizard.exe"
  File "SetupWizard.exe.config"
  File "Windows.Forms.dll"
  File "Windows.Utils.UI.dll"
  File "WindowsUtils.dll"
  File "license.rtf"
  File "release.zip"
  File "Ionic.Zip.dll"
  File "SetupWizard.Model.dll"
  File "Uninstaller.exe"


 

;检测是否安装.net4.5
Call CheckForDotVersion45Up
Pop $0

;输出值
DetailPrint $0

;比较版本号
IntCmp $0 451 EqualCase LessCase MoreCase

;已安装同版本
EqualCase:
  ;DetailPrint "$$0 == 4.5.1"
  Goto Done

;小于需求版本
LessCase:
  DetailPrint "$$0 < 4.5.1"
  MessageBox MB_OK "程序运行环境 .NET Framework ${NETVersion} 尚未安装，接下来将安装该组件。" 
  ExecWait "${NETInstaller} /norestart /ChainingPackage FullX64Bootstrapper "
  Goto Done
  Return

;大于需求版本
MoreCase:
  DetailPrint "$$0 > 4.5"
  Goto Done

;结束
Done:
  ExecWait "$INSTDIR\SetupWizard.exe"
  RMDir /r "$INSTDIR"
  SetAutoClose true
  Quit 
 

FunctionEnd


;点击完成
Function .onInstSuccess 

FunctionEnd

;脚本完成后执行安装包的数字签名
#!finalize '${OutFileSignSHA1} "%1"'
#!finalize '${OutFileSignSHA256} "%1"'


;检测.net版本
Function CheckForDotVersion45Up

  ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" Release

  IntCmp $0 393295 is46 isbelow46 is46

  isbelow46:
  IntCmp $0 379893 is452 isbelow452 is452

  isbelow452:
  IntCmp $0 378675 is451 isbelow451 is451

  isbelow451:
  IntCmp $0 378389 is45 isbelow45 is45

  isbelow45:
  Push 0
  Return

  is46:
  Push 460
  Return

  is452:
  Push 452
  Return

  is451:
  Push 451
  Return

  is45:
  Push 450
  Return

FunctionEnd
