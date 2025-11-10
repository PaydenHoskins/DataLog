'Payden Hoskins
'RCET3371
'FALL2025
'https://github.com/PaydenHoskins/DataLog.git

Option Explicit On
Option Strict On
Imports System.IO.Ports
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Public Class Dataform
    Dim DataBuffer As New Queue(Of Integer)
    '---------------------------------- Program Logic ------------------------------------
    Sub Connect()
        SerialPort.Close()
        SerialPort.BaudRate = 9600
        SerialPort.Parity = Parity.None
        SerialPort.StopBits = StopBits.One
        SerialPort.DataBits = 8
        Try
            If ToolStripComboBox1.SelectedIndex = -1 Then
                MsgBox("Select a valid COM port", MsgBoxStyle.Critical)
            ElseIf ToolStripComboBox1.SelectedItem.ToString <> Nothing Then
                SerialPort.PortName = ToolStripComboBox1.SelectedItem.ToString
                SerialPort.Open()
            ElseIf ToolStripComboBox1.SelectedItem.ToString Is Nothing Then
                MsgBox("Select a valid COM port", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Select a valid COM port", MsgBoxStyle.Critical)
        End Try

    End Sub

    Sub GetData()
        Dim data(0) As Byte 'put bytes into array
        Dim writeData(0) As Byte 'put bytes into array
        Dim wait%
        Dim aWhile1$ = "0"
        Dim aWhile$ = "0"
        Dim Value(3) As Integer
        Dim newY%

        'y position
        data(0) = &H51 'actual data as byte
        SerialPort.Write(data, 0, 1)

        Do Until aWhile IsNot "0" Or aWhile1 IsNot "0"
            Dim ADC(SerialPort.BytesToRead) As Byte
            Try
                SerialPort.Read(ADC, 0, SerialPort.BytesToRead)
                aWhile = CStr(ADC(1))
                aWhile1 = CStr(ADC(0))
                Value(0) = ADC(0)
                Value(1) = ADC(1)
            Catch ex As Exception

            End Try
            wait += 1
            If wait = 1000 Then
                newY = CInt(0)
                Exit Do
            End If
        Loop

        Try
            newY = CInt((100 / 1023) * ((Value(0) * 4) + (Value(1) / 64)))
            Me.Text = $"{newY}"
        Catch ex As Exception
            MsgBox("Bad Data.")
        End Try
        aWhile = "0"
        aWhile1 = "0"

        If DataBuffer.Count >= 100 Then
            Me.DataBuffer.Dequeue()
        End If
        Me.DataBuffer.Enqueue(newY)
        LogData(newY)
    End Sub

    Sub LogData(currentSample%)
        Dim filePath$ = $"data_{DateTime.Now.ToString("yyMMddhh")}.log"
        FileOpen(1, filePath, OpenMode.Append)
        Write(1, "$$")
        Write(1, DateTime.Now)
        Write(1, DateTime.Now.Millisecond)
        WriteLine(1, currentSample)
        FileClose(1)
    End Sub

    Sub LoadData()
        Dim choice As DialogResult
        Dim fileNumber% = FreeFile()
        Dim currentRecord$
        Dim temp() As String
        Dim fileName$
        OpenFileDialog1.Filter = "log file (*.log)|*.log"

        choice = OpenFileDialog1.ShowDialog()
        If choice = DialogResult.OK Then
            Try
                fileName = OpenFileDialog1.FileName
                FileOpen(fileNumber, fileName, OpenMode.Input)
                Me.DataBuffer.Clear()
                Do Until EOF(fileNumber)
                    currentRecord = LineInput(fileNumber)
                    temp = Split(currentRecord, ",")
                    If Sample30RadioButton.Checked = True Then
                        If DataBuffer.Count >= 30 Then
                            Me.DataBuffer.Dequeue()
                        End If
                        Me.DataBuffer.Enqueue(CInt(temp(temp.GetUpperBound(0))))

                    ElseIf Sample100RadioButton.Checked = True Then
                        If DataBuffer.Count >= 100 Then
                            Me.DataBuffer.Dequeue()
                        End If
                        Me.DataBuffer.Enqueue(CInt(temp(temp.GetUpperBound(0))))

                    ElseIf AllRadioButton.Checked = True Then
                        Me.DataBuffer.Enqueue(CInt(temp(temp.GetUpperBound(0))))
                    End If
                Loop
                FilePathToolStripStatusLabel.Text = $"FilePath:{fileName}"
                FileClose(fileNumber)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

        End If

    End Sub

    Sub GraphData()
        Dim g As Graphics = GraphPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Lime)
        Dim eraser As New Pen(GraphPictureBox.BackColor)
        Dim scaleX!
        Dim scaleY! = CSng((GraphPictureBox.Height / 100) * -1)
        If Sample30RadioButton.Checked = True Then
            scaleX! = CSng(GraphPictureBox.Width / 30)
        ElseIf Sample100RadioButton.Checked = True Then
            scaleX! = CSng(GraphPictureBox.Width / 100)
        ElseIf AllRadioButton.Checked = True Then
            scaleX! = CSng((GraphPictureBox.Width) / Me.DataBuffer.Count)
        End If

        g.TranslateTransform(0, GraphPictureBox.Height)
        g.ScaleTransform(scaleX, scaleY)
        pen.Width = 0.25

        Dim oldY% = 0
        Dim x = -1
        For Each y In Me.DataBuffer.Reverse
            x += 1
            g.DrawLine(eraser, x, 0, x, 100)
            g.DrawLine(pen, x - 1, oldY, x, y)
            oldY = y
        Next

        g.Dispose()
        pen.Dispose()
    End Sub

    '----------------------------------- Event handlers ----------------------------------
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GraphTimer_Tick(sender As Object, e As EventArgs) Handles GraphTimer.Tick

        Try
            GetData()
            GraphData()
        Catch ex As Exception
            GraphTimer.Enabled = False
            StartToolStripMenuItem.Text = "Start"
            TimerControlButton.Text = "Start"
            MsgBox("Error occured, check Comport for secure connection and restart sampling timer!")
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        GraphTimer.Enabled = False
        StartToolStripMenuItem.Text = "Start"
        TimerControlButton.Text = "Start"
        LoadData()
        GraphData()
    End Sub

    Private Sub Dataform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For port = 0 To SerialPort.GetPortNames.Length - 1
            ToolStripComboBox1.Items.Add(SerialPort.GetPortNames()(port))
        Next
        Try
            ToolStripComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("No Comport Detected, plug in a device and press the reload button.")
            ToolStripComboBox1.SelectedIndex = -1
        End Try
        TimeFactorComboBox.Items.Add("M")
        TimeFactorComboBox.Items.Add("S")
        TimeFactorComboBox.Items.Add("Ms")
        TimeFactorComboBox.SelectedItem = ("Ms")
        TimeComboBox.Items.Clear()
        Select Case TimeFactorComboBox.SelectedItem.ToString
            Case ("M")
                TimeComboBox.Items.Add("10")
                TimeComboBox.Items.Add("5")
                TimeComboBox.Items.Add("1")
            Case ("S")
                TimeComboBox.Items.Add("30")
                TimeComboBox.Items.Add("10")
                TimeComboBox.Items.Add("5")
                TimeComboBox.Items.Add("1")
            Case ("Ms")
                TimeComboBox.Items.Add("500")
                TimeComboBox.Items.Add("200")
                TimeComboBox.Items.Add("100")
        End Select
        TimeComboBox.SelectedIndex = 2
        Connect()
        Try
            SamplingToolStripStatusLabel.Text = $"SamplingRate:{TimeComboBox.SelectedItem.ToString}{TimeFactorComboBox.SelectedItem.ToString}"
        Catch ex As Exception
        End Try
        If ToolStripComboBox1.SelectedIndex = -1 Then

        Else
            StatusToolStripStatusLabel.Text = $"ComportStatus:{ToolStripComboBox1.SelectedItem.ToString}"
        End If
        Sample30RadioButton.Checked = False
        AllRadioButton.Checked = True
    End Sub

    Private Sub TimeFactorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeFactorComboBox.SelectedIndexChanged
        TimeComboBox.Items.Clear()
        Select Case TimeFactorComboBox.SelectedItem.ToString
            Case ("M")
                TimeComboBox.Items.Add("10")
                TimeComboBox.Items.Add("5")
                TimeComboBox.Items.Add("1")
            Case ("S")
                TimeComboBox.Items.Add("30")
                TimeComboBox.Items.Add("10")
                TimeComboBox.Items.Add("5")
                TimeComboBox.Items.Add("1")
            Case ("Ms")
                TimeComboBox.Items.Add("500")
                TimeComboBox.Items.Add("200")
                TimeComboBox.Items.Add("100")
        End Select
    End Sub

    Private Sub TimeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeComboBox.SelectedIndexChanged
        Select Case TimeFactorComboBox.SelectedItem.ToString
            Case ("M")
                Select Case TimeComboBox.SelectedItem.ToString
                    Case ("10")
                        GraphTimer.Interval = 600000
                    Case ("5")
                        GraphTimer.Interval = 300000
                    Case ("1")
                        GraphTimer.Interval = 60000
                End Select
            Case ("S")
                Select Case TimeComboBox.SelectedItem.ToString
                    Case ("30")
                        GraphTimer.Interval = 30000
                    Case ("10")
                        GraphTimer.Interval = 10000
                    Case ("5")
                        GraphTimer.Interval = 5000
                    Case ("1")
                        GraphTimer.Interval = 1000
                End Select
            Case ("Ms")
                Select Case TimeComboBox.SelectedItem.ToString
                    Case ("500")
                        GraphTimer.Interval = 500
                    Case ("200")
                        GraphTimer.Interval = 200
                    Case ("100")
                        GraphTimer.Interval = 100
                End Select
        End Select
        SamplingToolStripStatusLabel.Text = $"SamplingRate:{TimeComboBox.SelectedItem.ToString}{TimeFactorComboBox.SelectedItem.ToString}"
    End Sub

    Private Sub TimerControlButton_Click(sender As Object, e As EventArgs) Handles TimerControlButton.Click, StartToolStripMenuItem.Click
        If GraphTimer.Enabled = True Then
            StartToolStripMenuItem.Text = "Start"
            TimerControlButton.Text = "Start"
            GraphTimer.Enabled = False
        ElseIf GraphTimer.Enabled = False Then
            StartToolStripMenuItem.Text = "Stop"
            TimerControlButton.Text = "Stop"
            GraphTimer.Enabled = True
        End If
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        StatusToolStripStatusLabel.Text = $"ComportStatus:{ToolStripComboBox1.SelectedItem.ToString}"
        Connect()
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        For port = 0 To SerialPort.GetPortNames.Length - 1
            ToolStripComboBox1.Items.Add(SerialPort.GetPortNames()(port))
        Next
        Try
            ToolStripComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("No Comport Detected, plug in a device and press the reload button.")
            ToolStripComboBox1.SelectedIndex = -1
        End Try
    End Sub
End Class
