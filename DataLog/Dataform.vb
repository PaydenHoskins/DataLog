Option Explicit On
Option Strict On

Public Class Dataform
    Dim DataBuffer As New Queue(Of Integer)
    '---------------------------------- Program Logic ------------------------------------
    Function GetRandomNumberAround(thisNumber%, Optional within% = 10) As Integer
        Dim result%
        result = thisNumber - within
        result += GetRandomNumber(within) + GetRandomNumber(within)
        Return result
    End Function

    Function GetRandomNumber(max%) As Integer
        Randomize()

        Return CInt(System.Math.Floor((Rnd() * (max + 1))))
    End Function

    Sub GetData()
        Dim random%
        Dim _last%
        If Me.DataBuffer.Count > 0 Then
            _last = Me.DataBuffer.Last
        Else
            _last = GetRandomNumberAround(50, 50)
        End If

        If DataBuffer.Count >= 100 Then
            Me.DataBuffer.Dequeue()
        End If
        random = GetRandomNumberAround(_last, 5)
        Me.DataBuffer.Enqueue(random)
        LogData(random)
    End Sub

    Sub LogData(currentSample%)
        Dim filePath$ = $"data_{DateTime.Now.ToString("yyMMddhh")}.log"
        FileOpen(1, filePath, OpenMode.Append)
        Write(1, "$$")
        Write(1, DateTime.Now)
        Write(1, DateTime.Now.Millisecond)
        Write(1, currentSample)
        WriteLine(1)
        FileClose(1)
    End Sub

    Sub GraphData()
        Dim g As Graphics = GraphPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Lime)
        Dim eraser As New Pen(GraphPictureBox.BackColor)
        Dim scaleX! = CSng(GraphPictureBox.Width / 100)
        Dim scaleY! = CSng((GraphPictureBox.Height / 100) * -1)

        'g.Clear(Color.Black)
        g.TranslateTransform(0, GraphPictureBox.Height) 'move origin to bottom left
        g.ScaleTransform(scaleX, scaleY) 'scale to 100 x 100 units
        pen.Width = 0.25 'fix pen so it is not too thick

        Dim oldY% = 0 ' GetRandomNumberAround(50, 50)
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
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub GraphButton_Click(sender As Object, e As EventArgs) Handles GraphButton.Click
        If GraphTimer.Enabled = True Then
            GraphTimer.Enabled = False
        ElseIf GraphTimer.Enabled = False Then
            GraphTimer.Enabled = True
        End If
    End Sub

    Private Sub GraphTimer_Tick(sender As Object, e As EventArgs) Handles GraphTimer.Tick
        GetData()
        GraphData()
    End Sub
End Class
