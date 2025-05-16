Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form1

	Dim sGhostscriptPath As String = "C:\Program Files\gs\gs9.26\bin\gswin64.exe" 'https://ghostscript.com/download/gsdnld.html
	Dim sTesseractPath As String = "C:\Program Files (x86)\Tesseract-OCR\tesseract.exe"	'https://github.com/UB-Mannheim/tesseract/wiki

	Dim oAppSetting As New AppSetting()
	Dim iFileNumber As Integer = 0

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		oAppSetting.LoadData()

		txtFrom.Text = oAppSetting.GetValue("From")
		txtPassword.Text = oAppSetting.GetValue("Password")

		Dim sResizeResolution As String = oAppSetting.GetValue("ResizeResolution")
        If sResizeResolution <> "" AndAlso IsNumeric(sResizeResolution) Then
            txtResizeResolution.Text = sResizeResolution
        End If

        Dim sFileType As String = oAppSetting.GetValue("FileType")
		If sFileType <> "" Then
			cbFileType.SelectedIndex = sFileType
		End If

		chkResize.Checked = oAppSetting.GetValue("Resize") = "1"
		chkDeleteSourceFiles.Checked = oAppSetting.GetValue("DeleteSourceFiles") = "1"
		chkCreateInParentFolder.Checked = oAppSetting.GetValue("CreateInParentFolder") = "1"
		chkBookmarks.Checked = oAppSetting.GetValue("Bookmarks") = "1"
        chkOCR.Checked = oAppSetting.GetValue("OCR") = "1"
        chkReduce.Checked = oAppSetting.GetValue("Reduce") = "1"

        ChangedOcrCheck()

		txtTesseractPath.Text = oAppSetting.GetValue("TesseractPath")
		If txtTesseractPath.Text = "" And IO.File.Exists(sTesseractPath) Then
			txtTesseractPath.Text = sTesseractPath
		End If

		txtGhostscriptPath.Text = oAppSetting.GetValue("GhostscriptPath")
		If txtGhostscriptPath.Text = "" And IO.File.Exists(sGhostscriptPath) Then
			txtGhostscriptPath.Text = sGhostscriptPath
		End If
	End Sub

	Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		oAppSetting.SetValue("TesseractPath", txtTesseractPath.Text)
		oAppSetting.SetValue("GhostscriptPath", txtGhostscriptPath.Text)

		oAppSetting.SetValue("From", txtFrom.Text)
		oAppSetting.SetValue("Password", txtPassword.Text)
		oAppSetting.SetValue("ResizeResolution", txtResizeResolution.Text)

		oAppSetting.SetValue("FileType", cbFileType.SelectedIndex)

		oAppSetting.SetValue("Resize", IIf(chkResize.Checked, "1", "0"))
		oAppSetting.SetValue("DeleteSourceFiles", IIf(chkDeleteSourceFiles.Checked, "1", "0"))
		oAppSetting.SetValue("CreateInParentFolder", IIf(chkCreateInParentFolder.Checked, "1", "0"))
		oAppSetting.SetValue("Bookmarks", IIf(chkBookmarks.Checked, "1", "0"))
        oAppSetting.SetValue("OCR", IIf(chkOCR.Checked, "1", "0"))
        oAppSetting.SetValue("Reduce", IIf(chkReduce.Checked, "1", "0"))

        oAppSetting.SaveData()
	End Sub

	Private Sub btnFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrom.Click
		fldFrom.SelectedPath = txtFrom.Text
		fldFrom.ShowDialog()
		txtFrom.Text = fldFrom.SelectedPath
	End Sub

	Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

		btnProcess.Enabled = False

		Dim sFromPath As String = txtFrom.Text
		If Not Directory.Exists(sFromPath) Then
			btnProcess.Enabled = True
			MsgBox("Folder does not exist")
			Exit Sub
		End If

		Dim iFileCount As Integer = 0
		CountProcessFiles(sFromPath, iFileCount)
		If iFileCount = 0 Then
			ProgressBar1.Value = 0
			Log("No Files to process")
			Exit Sub
		End If

		iFileNumber = 0
		ProgressBar1.Maximum = iFileCount

		txtOutput.Text = ""
		Log("Starting...")
		ProccessFolder(sFromPath)
		Log("Done!")

		btnProcess.Enabled = True

	End Sub

	Private Function PadExt(ByVal s As String) As String
		s = UCase(s)
		If s.Length > 3 Then
			s = s.Substring(1, 3)
		End If
		Return s
	End Function

	Function GetPageCount(ByVal sFolderPath As String) As Integer
		Dim iRet As Integer = 0
		Dim oFiles As String() = Directory.GetFiles(sFolderPath)

		For i As Integer = 0 To oFiles.Length - 1
			Dim sFromFilePath As String = oFiles(i)
			Dim oFileInfo As New FileInfo(sFromFilePath)
			Dim sFileType As String = cbFileType.SelectedItem
			Dim sExt As String = PadExt(oFileInfo.Extension)

			Select Case sFileType
				Case "All"
					If sExt = "PDF" Then
						iRet += 1
					ElseIf sExt = "JPG" Or sExt = "TIF" Then
						iRet += 1
					End If

				Case "PDF"
					If sExt = "PDF" Then
						iRet += 1
					End If

				Case "JPG", "TIF"
					If sExt = "JPG" Or sExt = "TIF" Then
						iRet += 1
					End If
			End Select
		Next

		Return iRet
	End Function

	Private Sub CountProcessFiles(ByVal sInFolder As String, ByRef iFileCount As Integer)

		Dim sOutFilePath As String = GetOutFilePath(sInFolder)
		TryDelete(sOutFilePath)

		If IO.File.Exists(sOutFilePath) = False Then
			iFileCount += GetPageCount(sInFolder)
		End If

		Dim oFolders As String() = IO.Directory.GetDirectories(sInFolder)
		For Each sFolder As String In oFolders
			CountProcessFiles(sFolder, iFileCount)
		Next
	End Sub

	Private Function GetOutFilePath(ByVal sFolderPath As String) As String
		Dim oFolderInfo As New System.IO.DirectoryInfo(sFolderPath)

		If chkCreateInParentFolder.Checked Then
			Return oFolderInfo.Parent.FullName & "\" & oFolderInfo.Name & ".pdf"
		Else
			Return sFolderPath & "\" & oFolderInfo.Name & ".pdf"
		End If
	End Function

	Private Sub TryDelete(sPath As String)
		Try
			If IO.File.Exists(sPath) Then
				IO.File.Delete(sPath)
			End If
		Catch ex As Exception
			'Ignore
		End Try
	End Sub

	Sub ProccessFolder(ByVal sFolderPath As String)

		Dim bOutputfileAlreadyExists As Boolean = False
		Dim sOutFilePath As String = GetOutFilePath(sFolderPath)

		If IO.File.Exists(sOutFilePath) Then
			Try
				IO.File.Delete(sOutFilePath)
			Catch ex As Exception
				Log("Output file already exists: " & sOutFilePath & " and could not be deleted.")
				bOutputfileAlreadyExists = True
			End Try
		End If

		Dim iPageCount As Integer = GetPageCount(sFolderPath)
		If iPageCount > 0 And bOutputfileAlreadyExists = False Then
			Log("Processing folder: " & sFolderPath & " - " & iPageCount & " files.")

			Dim oOcrTempFiles As New ArrayList()
			Dim oFiles As String() = Directory.GetFiles(sFolderPath)

			Dim oPdfDoc As New iTextSharp.text.Document()
			Dim oPdfWriter As PdfWriter = PdfWriter.GetInstance(oPdfDoc, New FileStream(sOutFilePath, FileMode.Create))
			If txtPassword.Text <> "" Then
				oPdfWriter.SetEncryption(PdfWriter.STRENGTH40BITS, txtPassword.Text, txtPassword.Text, PdfWriter.AllowCopy)
			End If
			oPdfDoc.Open()

			System.Array.Sort(Of String)(oFiles)

			For i As Integer = 0 To oFiles.Length - 1
				Dim sFromFilePath As String = oFiles(i)
				Dim oFileInfo As New FileInfo(sFromFilePath)
				Dim sFileType As String = cbFileType.SelectedItem
				Dim sExt As String = PadExt(oFileInfo.Extension)

				Try
					Dim bAddPdf As Boolean = False
					Dim bAddImage As Boolean = False
					Select Case sFileType
						Case "All"
							If sExt = "PDF" Then
								bAddPdf = True
							ElseIf sExt = "JPG" Or sExt = "TIF" Then
								bAddImage = True
							End If
						Case "PDF"
							If sExt = "PDF" Then
								bAddPdf = True
							End If
						Case "JPG", "TIF"
							If sExt = "JPG" Or sExt = "TIF" Then
								bAddImage = True
							End If
					End Select

					If bAddPdf Or bAddImage Then
						Dim sBookmarkTitle As String = oFileInfo.Name
						Dim sOcrTiffFile As String = ""
						Dim sOcrPdfFile As String = ""
						Dim sError As String = ""

						If chkOCR.Checked Then
							Dim sOcrInputImg As String = sFromFilePath
							Dim sTempPdfFileBase As String = IO.Path.Combine(sFolderPath, Guid.NewGuid().ToString("N"))
							sOcrPdfFile = sTempPdfFileBase & ".pdf"

							If bAddPdf Then
								sOcrTiffFile = System.IO.Path.Combine(sFolderPath, Guid.NewGuid().ToString("N") & ".tiff")
								PdfToTiff(sFromFilePath, sOcrTiffFile)
								If IO.File.Exists(sOcrTiffFile) AndAlso GetFileSize(sOcrTiffFile) > 10 Then
									sOcrInputImg = sOcrTiffFile
								End If
							End If

							sError = RunDosCommandAsynch(sTesseractPath, """" & sOcrInputImg & """ """ & sTempPdfFileBase & """ pdf", 600)	'10 min timeout

							If IO.File.Exists(sOcrPdfFile) AndAlso GetFileSize(sOcrPdfFile) > 10 Then
								sFromFilePath = sOcrPdfFile
								bAddPdf = True
							Else
								Log(sFromFilePath & " could not be OCRed." & sError)
							End If
						End If

						If bAddPdf Then
							AddPdf(sFromFilePath, oPdfDoc, oPdfWriter, sBookmarkTitle)
						ElseIf bAddImage Then
							AddImage(sFromFilePath, oPdfDoc, oPdfWriter, sExt, sBookmarkTitle)
						End If

						iFileNumber += 1
						ProgressBar1.Value = iFileNumber

						If chkOCR.Checked Then
							If sOcrTiffFile <> "" Then oOcrTempFiles.Add(sOcrTiffFile)
							If sOcrPdfFile <> "" Then oOcrTempFiles.Add(sOcrPdfFile)
						End If
					End If

				Catch ex As Exception
					Log(sFromFilePath & vbTab & ex.Message)
				End Try

			Next

			Try
				oPdfDoc.Close()
				oPdfWriter.Close()
			Catch ex As Exception
				Log(ex.Message)
				Try
					IO.File.Delete(sOutFilePath)
				Catch ex2 As Exception
				End Try
			End Try

			If chkOCR.Checked Then
				For Each sDelFile As String In oOcrTempFiles
					TryDelete(sDelFile)
				Next
			End If

			If chkDeleteSourceFiles.Checked Then
				For i As Integer = 0 To oFiles.Length - 1
					Dim sFromFilePath As String = oFiles(i)
					If IO.File.Exists(sFromFilePath) Then
						Try
							IO.File.Delete(sFromFilePath)
						Catch ex As Exception
							Log("Could not delete " & sFromFilePath & ", " & ex.Message)
						End Try
					End If
				Next
			End If

			ProgressBar1.Value = 0
		End If

		Dim oFolders As String() = Directory.GetDirectories(sFolderPath)
		For i As Integer = 0 To oFolders.Length - 1
			Dim sChildFolder As String = oFolders(i)
			Dim iPos As Integer = sChildFolder.LastIndexOf("\")
			Dim sFolderName As String = sChildFolder.Substring(iPos + 1)
			ProccessFolder(sChildFolder)
		Next

	End Sub

	Private Sub Log(ByVal sMsg As String)
		txtOutput.AppendText(sMsg & vbCrLf)
	End Sub

	Sub AddBookmark(ByRef oPdfDoc As iTextSharp.text.Document, ByVal sBookmarkTitle As String)
		If chkBookmarks.Checked = False Then
			Exit Sub
		End If

		Dim oChapter As New iTextSharp.text.Chapter("", 0)
		oChapter.NumberDepth = 0
		oChapter.BookmarkTitle = sBookmarkTitle
		oPdfDoc.Add(oChapter)
	End Sub

	Sub AddPdf(ByVal sInFilePath As String, ByRef oPdfDoc As iTextSharp.text.Document, ByRef oPdfWriter As PdfWriter, ByVal sBookmarkTitle As String)

		AddBookmark(oPdfDoc, sBookmarkTitle)

		Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
		Dim oPdfReader As iTextSharp.text.pdf.PdfReader = New iTextSharp.text.pdf.PdfReader(sInFilePath)
		Dim iNumberOfPages As Integer = oPdfReader.NumberOfPages
		Dim iPage As Integer = 0

		Do While (iPage < iNumberOfPages)
			iPage += 1

			Dim iRotation As Integer = oPdfReader.GetPageRotation(iPage)
			Dim oPdfImportedPage As iTextSharp.text.pdf.PdfImportedPage = oPdfWriter.GetImportedPage(oPdfReader, iPage)

			If chkResize.Checked Then
				If (oPdfImportedPage.Width <= oPdfImportedPage.Height) Then
					oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER)
				Else
					oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate())
				End If

				oPdfDoc.NewPage()

				Dim iWidthFactor As Single = oPdfDoc.PageSize.Width / oPdfReader.GetPageSize(iPage).Width
				Dim iHeightFactor As Single = oPdfDoc.PageSize.Height / oPdfReader.GetPageSize(iPage).Height
				Dim iFactor As Single = Math.Min(iWidthFactor, iHeightFactor)

				Dim iOffsetX As Single = (oPdfDoc.PageSize.Width - (oPdfImportedPage.Width * iFactor)) / 2
				Dim iOffsetY As Single = (oPdfDoc.PageSize.Height - (oPdfImportedPage.Height * iFactor)) / 2

				oDirectContent.AddTemplate(oPdfImportedPage, iFactor, 0, 0, iFactor, iOffsetX, iOffsetY)

			Else
				oPdfDoc.SetPageSize(oPdfReader.GetPageSizeWithRotation(iPage))
				oPdfDoc.NewPage()

				If iRotation = 90 Then
					oDirectContent.AddTemplate(oPdfImportedPage, 0, -1.0F, 1.0F, 0, 0, oPdfReader.GetPageSizeWithRotation(iPage).Height)

				ElseIf iRotation = 270 Then
					oDirectContent.AddTemplate(oPdfImportedPage, 0, 1.0F, -1.0F, 0, oPdfReader.GetPageSizeWithRotation(iPage).Width, 0)

				ElseIf iRotation = 180 Then
					oDirectContent.AddTemplate(oPdfImportedPage, -1.0F, 0, 0, -1.0F, oPdfReader.GetPageSizeWithRotation(iPage).Width, oPdfReader.GetPageSizeWithRotation(iPage).Height)

				Else
					oDirectContent.AddTemplate(oPdfImportedPage, 1.0F, 0, 0, 1.0F, 0, 0)
				End If
			End If
		Loop

	End Sub

	Sub AddImage(ByVal sInFilePath As String, ByRef oPdfDoc As iTextSharp.text.Document, ByRef oPdfWriter As PdfWriter, ByVal sExt As String, sBookmarkTitle As String)

		AddBookmark(oPdfDoc, sBookmarkTitle)

		If chkResize.Checked = False Then
			Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
			Dim oPdfImage As iTextSharp.text.Image
			oPdfImage = iTextSharp.text.Image.GetInstance(sInFilePath)
			oPdfImage.SetAbsolutePosition(1, 1)
			oPdfDoc.SetPageSize(New iTextSharp.text.Rectangle(oPdfImage.Width, oPdfImage.Height))
			oPdfDoc.NewPage()
			oDirectContent.AddImage(oPdfImage)
			Exit Sub
		End If

		Dim oImage As System.Drawing.Image = System.Drawing.Image.FromFile(sInFilePath)

		'Multi-Page Tiff
		If sExt = "TIF" Then
			Dim iPageCount As Integer = oImage.GetFrameCount(Imaging.FrameDimension.Page)
			If iPageCount > 1 Then
				For iPage As Integer = 0 To iPageCount - 1
					oImage.SelectActiveFrame(Imaging.FrameDimension.Page, iPage)
					Dim oMemoryStream As New IO.MemoryStream()
					oImage.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Png)
					Dim oImage2 As System.Drawing.Image = System.Drawing.Image.FromStream(oMemoryStream)
					AddImage2(oImage2, oPdfDoc, oPdfWriter)
					oMemoryStream.Close()
				Next
				Exit Sub
			End If
		End If

		AddImage2(oImage, oPdfDoc, oPdfWriter)
		oImage.Dispose()

	End Sub


	Sub AddImage2(ByRef oImage As System.Drawing.Image, ByRef oPdfDoc As iTextSharp.text.Document, ByRef oPdfWriter As PdfWriter)

		Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
		Dim oPdfImage As iTextSharp.text.Image
		Dim iWidth As Single = oImage.Width
		Dim iHeight As Single = oImage.Height
		Dim iAspectRatio As Double = iWidth / iHeight

		Dim iWidthPage As Single = 0
		Dim iHeightPage As Single = 0

		If iAspectRatio < 1 Then
			'Landscape image
			iWidthPage = iTextSharp.text.PageSize.LETTER.Width
			iHeightPage = iTextSharp.text.PageSize.LETTER.Height
		Else
			iHeightPage = iTextSharp.text.PageSize.LETTER.Width
			iWidthPage = iTextSharp.text.PageSize.LETTER.Height
		End If

		Dim iPageAspectRatio As Double = iWidthPage / iHeightPage

		Dim iWidthGoal As Single = 0
		Dim iHeightGoal As Single = 0
		Dim bFitsWithin As Boolean = False

		If iWidth < iWidthPage And iHeight < iHeightPage Then
			'Image fits within the page
			bFitsWithin = True
			iWidthGoal = iWidth
			iHeightGoal = iHeight

		ElseIf iAspectRatio > iPageAspectRatio Then
			'Width is too big
			iWidthGoal = iWidthPage
			iHeightGoal = iWidthPage * (iHeight / iWidth)

		Else
			'Height is too big
			iWidthGoal = iHeightPage * (iWidth / iHeight)
			iHeightGoal = iHeightPage
		End If

        If bFitsWithin = False AndAlso chkReduce.Checked Then
            oImage = FixedSize(oImage, iWidthGoal, iHeightGoal)
            'oImage.Save("C:\temp\folder1\Lilly_copy.jpg")
        End If

        oPdfImage = iTextSharp.text.Image.GetInstance(oImage, System.Drawing.Imaging.ImageFormat.Png)
		oPdfImage.SetAbsolutePosition(1, 1)

		If iAspectRatio < 1 Then
			'Landscape image
			oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER)
		Else
			oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate())
		End If

		oPdfDoc.NewPage()
		oPdfImage.ScaleAbsolute(iWidthGoal, iHeightGoal)
		oDirectContent.AddImage(oPdfImage)

	End Sub

	Private Function FixedSize(ByVal imgPhoto As System.Drawing.Image, _
	ByVal Width As Integer, ByVal Height As Integer) As System.Drawing.Image

		If txtResizeResolution.Text = "" OrElse IsNumeric(txtResizeResolution.Text) = False Then
			Log("Resize Resolution is not a number.")
			Return imgPhoto
		End If

		Dim iResizeResolution As Double = CDbl(txtResizeResolution.Text) / 100
		Width = Width * iResizeResolution
		Height = Height * iResizeResolution

		Dim sourceWidth As Integer = imgPhoto.Width
		Dim sourceHeight As Integer = imgPhoto.Height
		Dim sourceX As Integer = 0
		Dim sourceY As Integer = 0
		Dim destX As Integer = 0
		Dim destY As Integer = 0

		Dim nPercent As Single = 0
		Dim nPercentW As Single = 0
		Dim nPercentH As Single = 0

		nPercentW = (CSng(Width) / CSng(sourceWidth))
		nPercentH = (CSng(Height) / CSng(sourceHeight))

		If nPercentH < nPercentW Then
			nPercent = nPercentH
			destX = CInt(((Width - (sourceWidth * nPercent)) / 2))
		Else
			nPercent = nPercentW
			destY = CInt(((Height - (sourceHeight * nPercent)) / 2))
		End If

		Dim destWidth As Integer = CInt((sourceWidth * nPercent))
		Dim destHeight As Integer = CInt((sourceHeight * nPercent))

		Dim bmPhoto As New Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
		bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

		Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
		grPhoto.Clear(Color.White)
		grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

		grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), _
		  New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

		grPhoto.Dispose()
		imgPhoto.Dispose()

		Return bmPhoto
	End Function

	Private Sub btnTesseract_Click(sender As Object, e As EventArgs) Handles btnTesseract.Click
		Dim oFileInfo As New FileInfo(txtTesseractPath.Text)
		dOpenFile.InitialDirectory = oFileInfo.DirectoryName
		dOpenFile.FileName = oFileInfo.Name
		dOpenFile.ShowDialog()

		If IO.File.Exists(dOpenFile.FileName) Then
			txtTesseractPath.Text = dOpenFile.FileName
		End If
	End Sub

	Private Sub btnGhostscript_Click(sender As Object, e As EventArgs) Handles btnGhostscript.Click
		Dim oFileInfo As New FileInfo(txtGhostscriptPath.Text)
		dOpenFile.InitialDirectory = oFileInfo.DirectoryName
		dOpenFile.FileName = oFileInfo.Name
		dOpenFile.ShowDialog()

		If IO.File.Exists(dOpenFile.FileName) Then
			txtGhostscriptPath.Text = dOpenFile.FileName
		End If
	End Sub

	Private Sub chkOCR_CheckedChanged(sender As Object, e As EventArgs) Handles chkOCR.CheckedChanged
		ChangedOcrCheck()
	End Sub

	Sub ChangedOcrCheck()
		pnOCR.Visible = chkOCR.Checked

        chkReduce.Visible = chkOCR.Checked = False
        txtResizeResolution.Visible = chkOCR.Checked = False
        lbResizeResolution.Visible = chkOCR.Checked = False
	End Sub

	Sub PdfToTiff(ByVal sInPdf As String, ByVal sOutTiff As String)
		Dim sError As String = ""
		'https://ghostscript.com/doc/9.21/Devices.htm
		RunDosCommand(sGhostscriptPath, "-dNOPAUSE -q -r300 -sDEVICE=tiff24nc -dBATCH -sOutputFile=""" & sOutTiff & """ """ & sInPdf & """ -c quit", sError, 600)
	End Sub

	Sub RunDosCommand(sExeFilePath As String, sArguments As String, ByRef sError As String, ByVal iTimeOutSec As Integer)

		Dim sRet As String = ""
		Dim oProcess As Process = New Process()
		oProcess.StartInfo.UseShellExecute = True
		oProcess.StartInfo.FileName = sExeFilePath
		oProcess.StartInfo.Arguments = sArguments
		oProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
		oProcess.StartInfo.CreateNoWindow = True

		oProcess.Start()
		oProcess.WaitForExit(1000 * iTimeOutSec)
		If oProcess.HasExited = False Then
			oProcess.Kill()
			sError = "Timeout after " + iTimeOutSec + " seconds."
		End If

		If oProcess.ExitCode <> 0 AndAlso String.IsNullOrEmpty(sError) Then
			sError = "ExitCode: " + oProcess.ExitCode
		End If

		oProcess.Close()
	End Sub

	Function RunDosCommandAsynch(sExeFilePath As String, sArguments As String, ByVal iTimeOutSec As Integer) As String

		Dim sError As String = ""
		Dim oProcess As Process = New Process()
		oProcess.StartInfo.UseShellExecute = False
		oProcess.StartInfo.RedirectStandardOutput = True
		oProcess.StartInfo.RedirectStandardError = True
		oProcess.StartInfo.FileName = sExeFilePath
		oProcess.StartInfo.Arguments = sArguments
		oProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
		oProcess.StartInfo.CreateNoWindow = True

		oProcess.Start()
		oProcess.WaitForExit(1000 * iTimeOutSec)
		If oProcess.HasExited = False Then
			oProcess.Kill()
			sError = "Timeout after " + iTimeOutSec + " seconds."
		End If

		If String.IsNullOrEmpty(sError) Then
			sError = oProcess.StandardError.ReadToEnd()
		End If

		'sRet = oProcess.StandardOutput.ReadToEnd()

		If oProcess.ExitCode <> 0 AndAlso String.IsNullOrEmpty(sError) Then
			sError = "ExitCode: " + oProcess.ExitCode
		End If

		oProcess.Close()

		Return sError
	End Function

	Private Function GetFileSize(sPath As String) As Integer
		Dim oFileInfo As New FileInfo(sPath)
		Return oFileInfo.Length
	End Function

	Private Sub lbTesseract_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbTesseract.LinkClicked
		Process.Start("https://github.com/UB-Mannheim/tesseract/wiki")
	End Sub

	Private Sub lbGhostscript_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbGhostscript.LinkClicked
		Process.Start("https://ghostscript.com/download/gsdnld.html")
	End Sub
End Class
