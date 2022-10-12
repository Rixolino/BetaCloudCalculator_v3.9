Imports System
Imports System.Globalization
Imports System.Runtime.Serialization.Formatters

Public Class Programer
    Public Function ConvertFromBinary(ByVal input As String) As Integer
        Dim ret As Integer = 0
        Dim splitInput As Char() = input.ToCharArray
        Dim modifier As Integer = 1
        For i As Integer = splitInput.Length - 1 To 0 Step -1
            Dim thisChar As Integer = Val(splitInput(i))
            If thisChar = 1 Then
                ret += thisChar * modifier
            End If
            modifier *= 2
        Next

        Return ret
    End Function
    Public Shared Function DecimalToBinary(dec As Integer) As String
        If dec < 1 Then Return "0"

        Dim binStr As String = String.Empty

        While dec > 0
            binStr = binStr.Insert(0, (dec Mod 2).ToString())
            dec = Int(dec / 2)
        End While

        Return binStr
    End Function
    Public Sub New()
        InitializeComponent()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.ResizeRedraw, True)

    End Sub

    Private Const cGrip As Integer = 16
    Private Const cCaption As Integer = 32

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H84 Then
            Dim pos As Point = New Point(m.LParam.ToInt32())
            pos = Me.PointToClient(pos)

            If pos.Y < cCaption Then
                m.Result = CType(2, IntPtr)
                Return
            End If

            If pos.X >= Me.ClientSize.Width - cGrip AndAlso pos.Y >= Me.ClientSize.Height - cGrip Then
                m.Result = CType(17, IntPtr)
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub NormalActualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalActualToolStripMenuItem.Click
        Normal.Show()
        Me.Close()
    End Sub

    Private Sub ScientificToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScientificToolStripMenuItem.Click
        Scientific.Show()
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub Closea_Click(sender As Object, e As EventArgs) Handles Closea.Click
        Application.Exit()
    End Sub

    Private Sub Minimizea_Click(sender As Object, e As EventArgs) Handles Minimizea.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If (toBBinary.Checked = True) Then
            TextBox2.Text = DecimalToBinary(TextBox1.Text)

        Else
            If (toDDecimal.Checked = True) Then
                TextBox2.Text = ConvertFromBinary(TextBox1.Text)
            End If
        End If
    End Sub
    Private Sub Butt1_Click(sender As Object, e As EventArgs) Handles Butt1.Click
        TextBox1.Text = TextBox1.Text & “1”
    End Sub

    Private Sub Butt0_Click(sender As Object, e As EventArgs) Handles Butt0.Click
        TextBox1.Text = TextBox1.Text & “0”
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        toBBinary.Checked = False
        toDDecimal.Checked = False
        Butt0.Enabled = False
        Butt1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button14.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles toDDecimal.CheckedChanged
        Butt0.Enabled = True
        Butt1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button14.Enabled = True
        toBBinary.Checked = False
        Label3.Text = "BIN"
        Label2.Text = "DEX"
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Programer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles toBBinary.CheckedChanged
        Butt0.Enabled = True
        Butt1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button14.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        toDDecimal.Checked = False
        Label3.Text = "DEX"
        Label2.Text = "BIN"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = TextBox1.Text & “3”
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = TextBox1.Text & “4”
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = TextBox1.Text & “5”
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text = TextBox1.Text & “6”
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text = TextBox1.Text & “7”
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text = TextBox1.Text & “8”
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text = TextBox1.Text & “9”
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = TextBox1.Text & “2”
    End Sub
End Class