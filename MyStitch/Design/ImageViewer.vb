'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Math
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ImageViewer
    Dim myfg As Graphics = Nothing
    Dim myimagefile As Image = Nothing
    Dim myPicturebox As PictureBox
    Dim myHscrollBar As HScrollBar
    Dim myVScrollBar As VScrollBar
    Dim myZoom As TrackBar
    Dim myCaption As Label

    Dim rect As Rectangle
    Dim iZoomLevel As Double = 1.0
    Dim iMaxZoomPct As Integer = 150
    Dim iMinZoomPct As Integer = 10
    Dim iZoomStep As Integer = 5
    Dim iZoomBigStep As Integer = 25
    Dim iZoomPct As Integer = 100
    Dim bZooming As Boolean = False
    Dim bDrawing As Boolean = False
    Dim bResizing As Boolean = False
    Dim myWindowState As FormWindowState
    Dim xPos As Integer = 0
    Dim yPos As Integer = 0
    Dim rotateAngle As Integer = 0


    Public Enum ImagePos
        auto = 0
        below = 1
        right = 2
    End Enum
    Public Sub New(ByRef m_picturebox As PictureBox, _
                   ByRef m_hscrollbar As HScrollBar, ByRef m_vscrollbar As VScrollBar, _
                  ByRef m_zoom As TrackBar, ByRef m_caption As Label)
        myPicturebox = m_picturebox
        myHscrollBar = m_hscrollbar
        myVScrollBar = m_vscrollbar
        rotateAngle = 0
        myZoom = m_zoom
        myCaption = m_caption
    End Sub

    Public Sub DoubleClick(ByVal e As MouseEventArgs)
        '
        ' If double-click on the coupon image increase or decrease the zoom level 0.5
        '
        If e.X >= myPicturebox.Left And e.X < myPicturebox.Left + myPicturebox.Width Then
            If e.Y >= myPicturebox.Top And e.Y < myPicturebox.Top + myPicturebox.Height Then
                xPos = e.X
                yPos = e.Y
                ' Left button - increase the zoom level
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    myZoom.Value = iZoomPct + Math.Min(iZoomBigStep, iMaxZoomPct - iZoomPct)
                    ' Right button - decrease the zoom level
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    myZoom.Value = iZoomPct - Math.Min(iZoomPct - iMinZoomPct, iZoomBigStep)
                End If
            End If
        End If
    End Sub


    Private Sub setScrollBars(ByVal oldpct As Integer, ByVal newpct As Integer)
        bZooming = True
        If myimagefile IsNot Nothing Then
            Dim newHMaximum As Integer = Math.Max((myimagefile.Width * newpct / 100) - myPicturebox.Width, 1)
            Dim newVMaximum As Integer = Math.Max((myimagefile.Height * newpct / 100) - myPicturebox.Height, 1)
            '
            ' don't let the new values drop below 1
            '
            If myHscrollBar.Value <> 1 Then
                If xPos = 0 Then
                    xPos = Int(myHscrollBar.Value * newpct / oldpct)
                Else
                    xPos = ((xPos + myHscrollBar.Value - myPicturebox.Left) * newpct / oldpct) - (xPos - myPicturebox.Left)
                End If
            End If
            If myVScrollBar.Value <> 1 Then
                If yPos = 0 Then
                    yPos = Int(myVScrollBar.Value * newpct / oldpct)
                Else
                    yPos = ((myVScrollBar.Value + yPos - myPicturebox.Top) * newpct / oldpct) - (yPos - myPicturebox.Top)
                End If
            End If

            Dim newHValue As Integer = Math.Max(1, xPos)
            Dim newVValue As Integer = Math.Max(1, yPos)
            myHscrollBar.Maximum = newHMaximum
            myVScrollBar.Maximum = newVMaximum
            myHscrollBar.Value = Math.Min(newHMaximum, newHValue)
            myVScrollBar.Value = Math.Min(newVMaximum, newVValue)
            If myPicturebox.Width > myimagefile.Width * newpct / 100 Then
                myHscrollBar.Visible = False
            Else
                myHscrollBar.Visible = True
            End If
            If myPicturebox.Height > myimagefile.Height * newpct / 100 Then
                myVScrollBar.Visible = False
            Else
                myVScrollBar.Visible = True
            End If
        End If
        bZooming = False
        xPos = 0
        yPos = 0
    End Sub

    Public Sub DrawCoupon()
        bDrawing = True
        If myimagefile IsNot Nothing Then
            ' if the image is smaller than the picture box, clear previous image
            If myPicturebox.Width > myimagefile.Width * iZoomLevel Or myPicturebox.Height > myimagefile.Height * iZoomLevel Then
                myfg.Clear(myPicturebox.BackColor)
            End If

            ' describe area of image to be shown as a rectangle
            ' it is a picture box shaped area of the image
            Dim picx As Single = Math.Max(myHscrollBar.Value / iZoomLevel, 1.0)
            Dim picy As Single = Math.Max(myVScrollBar.Value / iZoomLevel, 1.0)
            Dim picw As Single = myPicturebox.Width / iZoomLevel
            Dim pich As Single = myPicturebox.Height / iZoomLevel
            rect = New Rectangle(picx, picy, picw, pich)

            ' describe destination for image as three corners of a rectangle
            ' this area should be in proportion to the image shape
            ' taking the picturebox size as the maximum
            Dim destWidth As Integer = myPicturebox.Width
            Dim destHeight As Integer = myPicturebox.Height
            Dim a As New Point(myPicturebox.Left, myPicturebox.Top)
            Dim b As New Point(myPicturebox.Left, myPicturebox.Top + destHeight)
            Dim c As New Point(myPicturebox.Left + destWidth, myPicturebox.Top)
            Dim d As New Point(myPicturebox.Left + destWidth, myPicturebox.Top + destHeight)
            Dim corners(2) As Point
            Select Case rotateAngle
                Case 0
                    corners(0) = a
                    corners(2) = b
                    corners(1) = c
                Case 1
                    corners(0) = c
                    corners(2) = a
                    corners(1) = d
                Case 2
                    corners(0) = d
                    corners(2) = c
                    corners(1) = b
                Case 3
                    corners(0) = b
                    corners(2) = d
                    corners(1) = a
            End Select
            Try
                myfg.DrawImage(myimagefile, corners, rect, GraphicsUnit.Pixel)
            Catch ex As Exception
                Throw New ApplicationException("Cannot draw the coupon:" & vbCrLf & ex.Message)
            End Try

        End If
        bDrawing = False
    End Sub



    Public Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then

            xPos = e.X
            yPos = e.Y

        End If
    End Sub

    Public Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If myimagefile IsNot Nothing And e.Button = Windows.Forms.MouseButtons.Left Then

            Dim xshift = myHscrollBar.Value + (xPos - e.X)
            Dim yshift = myVScrollBar.Value + (yPos - e.Y)
            myHscrollBar.Value = Math.Max(1, Math.Min(xshift, myHscrollBar.Maximum))
            myVScrollBar.Value = Math.Max(1, Math.Min(yshift, myVScrollBar.Maximum))
            xPos = e.X
            yPos = e.Y
        End If

    End Sub

    Public Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            xPos = 0
            yPos = 0
        End If

    End Sub

    Public Sub Paint()
        If Not bResizing And Not bDrawing Then
            DrawCoupon()
        End If
    End Sub

    Public Sub resizeStart()
        bResizing = True
    End Sub

    Public Sub resizeGraphics(ByRef newGraphics As Graphics)
        If myimagefile IsNot Nothing Then
            bResizing = True
            '      Debug.Print("V:" & CStr(myvscrollbar.Value) & " H:" & CStr(myhscrollbar.Value))
            setScrollBars(iZoomPct, iZoomPct)
            '  Debug.Print("V:" & CStr(myvscrollbar.Value) & " H:" & CStr(myhscrollbar.Value))
            ' reset the graphics object for the new size form
            myfg = newGraphics
            myfg.Clip = New Region(New Rectangle(myPicturebox.Left, myPicturebox.Top, myPicturebox.Width, myPicturebox.Height))
            DrawCoupon()
            bResizing = False
        End If

    End Sub

    Public Sub hscrollbarValueChanged()
        If Not bZooming Then
            DrawCoupon()
        End If
    End Sub

    Public Sub vscrollbarValueChanged()
        If Not bZooming Then
            DrawCoupon()
        End If
    End Sub

    Public Sub HeightClick()
        If myimagefile IsNot Nothing Then
            Dim z1 As Integer = Int(myPicturebox.Height * 100 / myimagefile.Height) + 2
            Dim z2 As Integer = Math.Min(z1, myZoom.Maximum)
            myZoom.Value = Math.Max(z2, myZoom.Minimum)
        End If
    End Sub

    Public Sub WidthClick(Optional ByVal iPos As Integer = 0)
        '
        ' Adjust size to fit width + 2% then (optionally)
        ' reposition to
        '   0 - centre
        '   1 - top corner
        '   2 - bottom corner
        '   3 - no reposition
        '
        If myimagefile IsNot Nothing Then
            Dim z1 As Integer = Int(myPicturebox.Width * 100 / myimagefile.Width) + 1
            Dim z2 As Integer = Math.Min(z1, myZoom.Maximum)

            Dim newZoomValue As Integer = Math.Max(z2, myZoom.Minimum)
            If newZoomValue <> myZoom.Value Then
                myZoom.Value = Math.Max(z2, myZoom.Minimum)
            Else
                zoomValueChanged()
            End If

            Select Case iPos
                Case 0
                    myHscrollBar.Value = Math.Max(myHscrollBar.Maximum / 2, 1)
                    myVScrollBar.Value = Math.Max(myVScrollBar.Maximum / 2, 1)
                Case 1
                    myHscrollBar.Value = myHscrollBar.Minimum
                    myVScrollBar.Value = myVScrollBar.Minimum
                Case 2
                    myHscrollBar.Value = myHscrollBar.Maximum
                    myVScrollBar.Value = myVScrollBar.Maximum

                Case Else

            End Select
        End If
    End Sub

    Public Sub ZoomInClick()
        If myimagefile IsNot Nothing Then
            Dim inc As Int16 = Math.Min(iZoomStep, iMaxZoomPct - iZoomPct)

            myZoom.Value = iZoomPct + inc
        End If
    End Sub

    Public Sub ZoomOutClick()
        If myimagefile IsNot Nothing Then
            myZoom.Value = iZoomPct - Math.Min(iZoomPct - iMinZoomPct, iZoomStep)
        End If
    End Sub

    Public Sub zoomValueChanged()
        If myimagefile IsNot Nothing Then
            If myZoom.Value >= myZoom.Minimum Then
                Dim iNewZoomPct As Integer = myZoom.Value
                myCaption.Text = CStr(iNewZoomPct) & "%"
                setScrollBars(iZoomPct, iNewZoomPct)
                iZoomLevel = iNewZoomPct / 100
                iZoomPct = iNewZoomPct
                DrawCoupon()
            Else
                myZoom.Value = myZoom.Minimum
            End If
        End If
    End Sub

    Public Sub LoadImage(ByRef newGraphics As Graphics, ByVal oImage As Image)
        myfg = newGraphics
        myfg.Clip = New Region(New Rectangle(myPicturebox.Left, myPicturebox.Top, myPicturebox.Width, myPicturebox.Height))
        Try
            ClearImage()
            myimagefile = oImage
        Catch ex As Exception
            MsgBox("Error opening file - no image available", MsgBoxStyle.Exclamation)
            myimagefile = Nothing
            setScrollBars(iZoomPct, iZoomPct)
            DrawCoupon()
        End Try
    End Sub

    Public Sub LoadImage(ByRef newGraphics As Graphics, ByVal sImagefile As String)
        Dim oImage As Image = Image.FromFile(sImagefile)
        LoadImage(newGraphics, oImage)
    End Sub

    Public Sub pictureboxPaint()
        If Not bResizing And Not bDrawing Then
            DrawCoupon()
            '        Debug.Print("paintbox1 paint")
        End If
    End Sub

    Public Sub CentreClick()
        If myimagefile IsNot Nothing Then
            myHscrollBar.Value = Math.Max(myHscrollBar.Maximum / 2, 1)
            myVScrollBar.Value = Math.Max(myVScrollBar.Maximum / 2, 1)
        End If
    End Sub

    Public Sub RotateClick(Optional ByVal i As Integer = -1)
        If myimagefile IsNot Nothing Then
            If i >= 0 And i <= 3 Then
                rotateAngle = i
            Else
                rotateAngle = rotateAngle + 1
                If rotateAngle >= 4 Then
                    rotateAngle = 0
                End If
            End If

            DrawCoupon()
        End If
    End Sub

    Public Sub ClearImage()
        If myimagefile IsNot Nothing Then
            myimagefile.Dispose()
            myimagefile = Nothing
        End If
        If myfg IsNot Nothing Then
            myfg.Clear(myPicturebox.BackColor)
        End If

    End Sub

End Class
