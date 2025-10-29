Option Explicit On
Option Strict On

Public Class Dataform
    '---------------------------------- Program Logic ------------------------------------
    Function GetRandomNumberAround(thisNumber%, Optional within% = 10) As Integer
        Dim result%

        result = GetRandomNumber(within) + GetRandomNumber(within)

        Return result
    End Function

    Function GetRandomNumber(max%) As Integer
        Randomize()

        Return CInt(System.Math.Floor((Rnd() * (max + 1))))
    End Function


    Function GetData() As Integer
        Return 5
    End Function

    Sub GraphData()

        Dim g As Graphics = GraphPictureBox.CreateGraphics
        Dim pen As Pen
        pen.Color = Color.BlanchedAlmond
        Dim scaleX As Single = CSng(GraphPictureBox.Width / 100)
        Dim scaleY As Single = CSng((GraphPictureBox.Height / 100) * -1)

        g.TranslateTransform(0, GraphPictureBox.Height)
        g.ScaleTransform(scaleX, scaleY)



        g.DrawLine(pen, 5, 5, 95, 5)

        g.Dispose()
        pen.Dispose()

    End Sub

    '----------------------------------- Event handlers ----------------------------------
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub GraphButton_Click(sender As Object, e As EventArgs) Handles GraphButton.Click
        For i = 1 To 100
            GetRandomNumberAround(50)
        Next
    End Sub
End Class
