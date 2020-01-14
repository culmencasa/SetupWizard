SetupWizard原理
===============
项目使用NSIS来打包制作一个setuploader.exe. 
启动setuploader.exe会先解压文件到临时文件夹.
然后会检测.net framework是否安装, 未安装则先安装.net framework框架,
如果已安装则继续启动SetupWizard程序.
SetupWizard程序只是一个向导程序, 最终将Release.zip解压到指定的安装目录.

使用NSIS制作打包程序
================
1.需要安装NSIS
2.脚本为final.nsi， 修改NETInstaller和NETVersion, 默认是安装.net framework4.5.1
3.将SetupWizard的bin\Debug下的文件， 放到final.nsi所在目录
4.将要安装的程序打包成Release.zip，放到final.nsi所在目录
5.将.net framework的安装包（DotNet451.msi）放到final.nsi所在目录（名字和脚本里设定的名称一致）
6.右键final.nsi, Compile NSIS Script，生成Setuploader.exe。
7.最后将DotNet451.msi和Setuploader.exe一起发布。

其他
====
1.SetupWizard默认使用.net framework4生成。
可以修改为.net framework 2.0，以适应默认已安装.net2.0的操作系统。
2.目前不能跳过360的安全警告， 除非花钱买证书 。
