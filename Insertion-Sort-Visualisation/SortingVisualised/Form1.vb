Imports System.Threading

Public Class Form1

    Public display As VBGame.Display
    Public thread As New Thread(AddressOf sortloop)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display = New VBGame.Display(Me, New Size(800, 600), "Sorting Visualised", True)
        thread.Start()
    End Sub

    Public Sub sortloop()

        While True

            Dim Bars As Bars = New Bars(display)
            Dim insertion As New Insertion(display, Bars)

            insertion.Sort()
            display.clockTick(0.5)
        End While

    End Sub

End Class
