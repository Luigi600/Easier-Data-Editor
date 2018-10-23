'------------------------------------------'
'---------Created by Lui's Studio----------'
'-------(http://www.lui-studio.net/)-------'
'------------------------------------------'
'-------------Author: Luigi600-------------'
'------------------------------------------'

'<project>Easier Data-Editor (STM93 Version)</project>
'<author>Luigi600</author>
'<summary> Foretaste of Easier LF-Editor (just beta version; easter-egg) </summary>

Public Class AutoBdy
    Public Shared Function createBody(ByVal img As Bitmap) As Rectangle
        Return getBody(img)
    End Function

    Private Shared Function getMainRect(ByVal img As Bitmap, Optional ByVal searchRect As Rectangle = Nothing) As Rectangle
        If IsNothing(searchRect) Then
            searchRect = New Rectangle(0, 0, img.Width, img.Height)
        ElseIf searchRect.IsEmpty Then
            searchRect = New Rectangle(0, 0, img.Width, img.Height)
        End If

        If searchRect.X < 0 Then searchRect.X = 0
        If searchRect.Y < 0 Then searchRect.Y = 0
        If searchRect.Width > img.Width Then searchRect.Width = img.Width
        If searchRect.Width > img.Height Then searchRect.Width = img.Height

        Dim mainRect As New Rectangle(-1, -1, -1, -1)
        For i As Integer = searchRect.X To (searchRect.X + searchRect.Width - 1)
            Dim breakFor As Boolean = False
            For j As Integer = searchRect.Y To (searchRect.Y + searchRect.Height - 1)
                Dim col As Color = img.GetPixel(i, j)
                If col.A > 0 Then
                    mainRect.X = i
                    breakFor = True
                    Exit For
                End If
            Next
            If breakFor Then
                Exit For
            End If
        Next

        For i As Integer = (searchRect.X + searchRect.Width - 1) To searchRect.X Step -1
            Dim breakFor As Boolean = False
            For j As Integer = searchRect.Y To (searchRect.Y + searchRect.Height - 1)
                Dim col As Color = img.GetPixel(i, j)
                If col.A > 0 Then
                    mainRect.Width = i - mainRect.X
                    breakFor = True
                    Exit For
                End If
            Next
            If breakFor Then
                Exit For
            End If
        Next


        '##############
        'y and height
        For i As Integer = searchRect.Y To (searchRect.Y + searchRect.Height - 1)
            Dim breakFor As Boolean = False
            For j As Integer = searchRect.X To (searchRect.X + searchRect.Width - 1)
                Dim col As Color = img.GetPixel(j, i)
                If col.A > 0 Then
                    mainRect.Y = i
                    breakFor = True
                    Exit For
                End If
            Next
            If breakFor Then
                Exit For
            End If
        Next


        For i As Integer = (searchRect.Y + searchRect.Height - 1) To searchRect.Y Step -1
            Dim breakFor As Boolean = False
            For j As Integer = searchRect.X To (searchRect.X + searchRect.Width - 1)
                Dim col As Color = img.GetPixel(j, i)
                If col.A > 0 Then
                    mainRect.Height = i - mainRect.Y
                    breakFor = True
                    Exit For
                End If
            Next
            If breakFor Then
                Exit For
            End If
        Next

        If mainRect.X < 0 And mainRect.Y < 0 And mainRect.Width < 0 And mainRect.Height < 0 Then
            Return New Rectangle
        Else
            If mainRect.X < 0 Then
                mainRect.X = 0
            End If
            If mainRect.Y < 0 Then
                mainRect.Y = 0
            End If
            If mainRect.Width < 0 Then
                mainRect.Width = searchRect.Width
            End If
            If mainRect.Height < 0 Then
                mainRect.Height = searchRect.Height
            End If
        End If

        Return mainRect
    End Function

    Private Shared Function getBody(ByVal img As Bitmap) As Rectangle
        Dim mainRect As Rectangle = getMainRect(img)


        '####################
        'finds colors/col | colors/row
        '####################
        Dim countOfColorsX As New List(Of Integer)
        Dim countOfColorsY As New List(Of Integer)
        Dim maxColorsX As Integer = 0
        Dim maxColorsY As Integer = 0


        Dim x As Integer = 0
        Dim y As Integer = 0
        Do While (x * y) < ((mainRect.Width - 1) * (mainRect.Height - 1)) 'because we starts with 0
            If x >= mainRect.Width - 1 Then
                y += 1
                x = 0
            End If

            If x = 0 Then
                countOfColorsY.Add(0)
            End If
            If y = 0 Then
                countOfColorsX.Add(0)
            End If

            Dim col As Color = img.GetPixel(mainRect.X + x, mainRect.Y + y)
            If col.A > 0 Then
                countOfColorsX(x) += 1
                countOfColorsY(y) += 1
            End If

            x += 1
        Loop
        countOfColorsY.RemoveAt(countOfColorsY.Count - 1)


        '####################
        'finds max X and Y colors
        '####################
        For Each maxX As Integer In countOfColorsX
            If maxX > maxColorsX Then
                maxColorsX = maxX
            End If
        Next
        For Each maxY As Integer In countOfColorsY
            If maxY > maxColorsY Then
                maxColorsY = maxY
            End If
        Next


        If maxColorsX > 0 Then
            Dim maxValue As Integer = (maxColorsX / 6) '(maxColorsX / 2)
            For i As Integer = 0 To CInt(mainRect.Width / 2)
                If countOfColorsX(i) > maxValue Then
                    For j As Integer = 0 To i - 1
                        countOfColorsX.RemoveAt(0)
                    Next
                    mainRect.X += i
                    mainRect.Width -= i
                    Exit For
                End If
            Next


            For i As Integer = mainRect.Width - 2 To CInt(mainRect.Width / 2) Step -1
                If countOfColorsX(i) > maxValue Then
                    mainRect.Width = i
                    Exit For
                End If
            Next
        End If


        If maxColorsY > 0 Then
            Dim maxValue As Integer = (maxColorsY / 3) ' (maxColorsY / 2)
            For i As Integer = 0 To CInt(mainRect.Height / 2)
                If countOfColorsY(i) > maxValue Then
                    For j As Integer = 0 To i - 1
                        countOfColorsY.RemoveAt(0)
                    Next
                    mainRect.Y += i
                    mainRect.Height -= i
                    Exit For
                End If
            Next


            For i As Integer = mainRect.Height - 2 To CInt(mainRect.Height / 2) Step -1
                If countOfColorsY(i) > maxValue Then
                    mainRect.Height = i
                    Exit For
                End If
            Next
        End If

        Return mainRect
    End Function
End Class
