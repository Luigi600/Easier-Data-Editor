Imports System.Text.RegularExpressions

Public Class TextFrameOffsets
    Inherits Offset

    Private m_name As String = ""
    Public Property Name As String
        Get
            Return m_name
        End Get
        Set(value As String)
            If Not IsNothing(value) Then
                m_name = value
            End If
        End Set
    End Property

    Public ReadOnly BPoint As Offset = Nothing
    Public ReadOnly WPoint As Offset = Nothing
    Public ReadOnly CPoint As Offset = Nothing
    Public ReadOnly OPoint As Offset = Nothing

    Public ReadOnly Bodies As New List(Of OffsetRect)
    Public ReadOnly Itrs As New List(Of OffsetRect)

    Public Sub New(ByVal offset As Integer, ByVal frame As String)
        Me.Offset = offset
        Me.EndOffset = offset + frame.Length

        Me.Name = GetRegexValue(frame, "(?<=\<frame\>\s*\d+\s+)[A-Za-z_\-0-9]+", , "")

        Dim bodies As MatchCollection = Regex.Matches(frame, PATTERN_BDY, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        For Each mtc As Match In bodies
            Me.Bodies.Add(New OffsetRect(offset, mtc.Index, mtc.Length, frame))
        Next

        Dim itrs As MatchCollection = Regex.Matches(frame, PATTERN_ITR, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        For Each mtc As Match In itrs
            Me.Itrs.Add(New OffsetRect(offset, mtc.Index, mtc.Length, frame))
        Next

        Dim bpoint As Match = Regex.Match(frame, PATTERN_BPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If bpoint.Success Then
            Me.BPoint = New Offset(offset, bpoint.Index, bpoint.Length, frame)
        End If
        Dim wpoint As Match = Regex.Match(frame, PATTERN_WPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If wpoint.Success Then
            Me.WPoint = New Offset(offset, wpoint.Index, wpoint.Length, frame)
        End If
        Dim cpoint As Match = Regex.Match(frame, PATTERN_CPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If cpoint.Success Then
            Me.CPoint = New Offset(offset, cpoint.Index, cpoint.Length, frame)
        End If
        Dim opoint As Match = Regex.Match(frame, PATTERN_OPOINT, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        If opoint.Success Then
            Me.OPoint = New Offset(offset, opoint.Index, opoint.Length, frame)
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return Offset & " - " & EndOffset & " (" & Name & ")"
    End Function
End Class