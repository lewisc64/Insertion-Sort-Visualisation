Public Class Insertion

    Private display As VBGame.Display
    Private Bars As Bars
    Private message As String = ""
    Private controlsMessage As String = "Mouse Wheel to adjust speed of visualisation."

    Public Shared fps As Integer = 10
    Public Shared displayMessage As Boolean = False

    Public Sub New(ByRef display As VBGame.Display, ByRef Bars As Bars)
        Me.display = display
        Me.Bars = Bars
    End Sub

    Public Sub NextFrame()

        For Each e As VBGame.MouseEvent In display.getMouseEvents()
            If e.action = VBGame.MouseEvent.actions.scroll Then
                If e.button = VBGame.MouseEvent.buttons.scrollUp Then
                    fps += 1
                Else
                    If fps > 1 Then
                        fps -= 1
                    End If
                End If
            End If
        Next

        display.fill(VBGame.Colors.white)
        Bars.DrawAllBars(display)
        If displayMessage Then
            display.drawText(New Point(10, 10), message, VBGame.Colors.black, New Font("Calibri", 8))
            display.drawText(New Point(10, 20), controlsMessage, VBGame.Colors.black, New Font("Calibri", 8))
        Else
            display.drawText(New Point(10, 10), controlsMessage, VBGame.Colors.black, New Font("Calibri", 8))
        End If
        display.update()
        display.clockTick(fps)
    End Sub

    Public Sub Sort()
        If Bars.bars.Count > 1 Then
            Dim value As Integer = Bars.bars(0).height
            Dim key As Object
            Dim j As Integer
            For i As Integer = 1 To Bars.bars.Count - 1
                key = Bars.bars(i).height
                j = i
                message = "Shifting all columns forward to make space for insertion..."
                While j > 0 AndAlso Bars.bars(j - 1).height > key
                    Bars.bars(j).height = Bars.bars(j - 1).height
                    Bars.bars(j).SetOnGround()
                    Bars.bars(j - 1).height = key
                    Bars.bars(j - 1).SetOnGround()
                    j -= 1
                    NextFrame()
                End While
                Bars.bars(j).height = key
                Bars.bars(j).SetOnGround()
                message = "Successful insertion"
                NextFrame()
            Next
        End If
    End Sub

End Class
