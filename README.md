# DCMKiler Ver0.1
本工具可以快速检测DCM（黑暗幽灵）木马的工作目录，并尝试删除这些文件。

注意：此专杀工具不能替代防病毒软件。

## 编译环境
`Visual Studio 2008`直接引入编译即可。
程序运行需要`.NET Framework 3.5`运行库，否则会报错。
## 手工杀毒方法

* 清除被挂的钩子:

用 `PC Hunter` 或其他的 ARK 工具，将所有被挂的 DLL 全部卸载 （均没有数字签名)
```
msaodex.dll
QQHelperDll.dll
RtkBdll.dll
```

* 删除木马释放出的所有文件:

| Windows 版本     | 文件                 |
| ---------------- |:--------------------:|
| Windows XP       | %windir%\ntshrui.dll |
| Windows 7        | %windir%\msls32.dll  |
| Windows 8 及以上 | %windir%\AduioSes.dll|

还有：
```
%CommonProgramfiles%\Microsoft Shared\Web Folders\msaodex.dll
%CommonProgramfiles%\Microsoft Shared\TEXTCONV\*elp.dll
%CommonProgramfiles%\Microsoft Shared\Web Folders\klive.exe
%CommonProgramfiles%\Microsoft Shared\Web Folders\rscom.dll
%windir%\Temp\{E53B9A13-F4C6-4d78-9755-65C029E88F02}
QQHelperDll.dll
a360se_.exe
aIexplore.exe
RtkBdll.dll
PInfos.dll
iestorage.dll
111.iesd
SAM.dll
lmha.slld
```

* 修复 LSP 连接

在CMD下执行:

`netsh winsock reset`

* 检查所有杀毒软件的白名单，清除被木马静默加入的部分
* 然后开动你所有的杀软，进行全盘杀毒。

## 协议
GNU General Public License v3.0
