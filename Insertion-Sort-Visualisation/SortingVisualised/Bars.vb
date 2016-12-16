Public Class Bars

    Public bars As New List(Of Bar)
    Public barWidth As Integer = 10


    Public Sub New(display As VBGame.Display)

        For x As Integer = 0 To display.width - barWidth Step barWidth
            bars.Add(New Bar(x, 0, barWidth, barWidth, display.height))
        Next

    End Sub

    Public Sub DrawAllBars(display As VBGame.Display)
        For Each Bar As Bar In bars
            Bar.draw(display)
        Next
    End Sub

End Class

Public Class Bar
    Inherits VBGame.Sprite

    Private Shared random As New Random
    Private maxHeight As Integer
    Public visible As Boolean = True

    Public Sub New(x As Integer, y As Integer, width As Integer, minHeight As Integer, maxHeight As Integer)

        Me.x = x
        Me.y = y
        Me.width = width
        Me.height = random.Next(minHeight, maxHeight + 1)
        Me.maxHeight = maxHeight
        SetOnGround()

    End Sub

    Public Overrides Sub draw(display As VBGame.Display)
        display.drawRect(getRect(), VBGame.Colors.blue)
        display.drawRect(getRect(), VBGame.Colors.black, False)
    End Sub

    Public Sub SetOnGround()
        If visible Then
            Me.y = maxHeight - Me.height
        End If
    End Sub

End Class