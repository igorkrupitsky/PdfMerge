<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.fldFrom = New System.Windows.Forms.FolderBrowserDialog()
        Me.fldTo = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnFrom = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFileType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.chkResize = New System.Windows.Forms.CheckBox()
        Me.chkDeleteSourceFiles = New System.Windows.Forms.CheckBox()
        Me.chkCreateInParentFolder = New System.Windows.Forms.CheckBox()
        Me.lbResizeResolution = New System.Windows.Forms.Label()
        Me.txtResizeResolution = New System.Windows.Forms.TextBox()
        Me.chkBookmarks = New System.Windows.Forms.CheckBox()
        Me.chkOCR = New System.Windows.Forms.CheckBox()
        Me.pnOCR = New System.Windows.Forms.Panel()
        Me.lbGhostscript = New System.Windows.Forms.LinkLabel()
        Me.lbTesseract = New System.Windows.Forms.LinkLabel()
        Me.btnGhostscript = New System.Windows.Forms.Button()
        Me.btnTesseract = New System.Windows.Forms.Button()
        Me.txtGhostscriptPath = New System.Windows.Forms.TextBox()
        Me.txtTesseractPath = New System.Windows.Forms.TextBox()
        Me.dOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.chkReduce = New System.Windows.Forms.CheckBox()
        Me.pnOCR.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcess
        '
        Me.btnProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcess.Location = New System.Drawing.Point(117, 228)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(419, 23)
        Me.btnProcess.TabIndex = 0
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'txtFrom
        '
        Me.txtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFrom.Location = New System.Drawing.Point(117, 20)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(385, 20)
        Me.txtFrom.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 423)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(524, 17)
        Me.ProgressBar1.TabIndex = 5
        '
        'btnFrom
        '
        Me.btnFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFrom.Location = New System.Drawing.Point(508, 16)
        Me.btnFrom.Name = "btnFrom"
        Me.btnFrom.Size = New System.Drawing.Size(28, 23)
        Me.btnFrom.TabIndex = 6
        Me.btnFrom.Text = "..."
        Me.btnFrom.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Password (optional)"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(116, 81)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(386, 20)
        Me.txtPassword.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Folder"
        '
        'cbFileType
        '
        Me.cbFileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFileType.FormattingEnabled = True
        Me.cbFileType.Items.AddRange(New Object() {"All", "PDF", "JPG", "TIF"})
        Me.cbFileType.Location = New System.Drawing.Point(117, 51)
        Me.cbFileType.Name = "cbFileType"
        Me.cbFileType.Size = New System.Drawing.Size(385, 21)
        Me.cbFileType.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "File Type"
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.Location = New System.Drawing.Point(12, 257)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(523, 160)
        Me.txtOutput.TabIndex = 12
        '
        'chkResize
        '
        Me.chkResize.AutoSize = True
        Me.chkResize.Checked = True
        Me.chkResize.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResize.Location = New System.Drawing.Point(117, 107)
        Me.chkResize.Name = "chkResize"
        Me.chkResize.Size = New System.Drawing.Size(58, 17)
        Me.chkResize.TabIndex = 13
        Me.chkResize.Text = "Resize"
        Me.chkResize.UseVisualStyleBackColor = True
        '
        'chkDeleteSourceFiles
        '
        Me.chkDeleteSourceFiles.AutoSize = True
        Me.chkDeleteSourceFiles.Location = New System.Drawing.Point(303, 107)
        Me.chkDeleteSourceFiles.Name = "chkDeleteSourceFiles"
        Me.chkDeleteSourceFiles.Size = New System.Drawing.Size(118, 17)
        Me.chkDeleteSourceFiles.TabIndex = 14
        Me.chkDeleteSourceFiles.Text = "Delete Source Files"
        Me.chkDeleteSourceFiles.UseVisualStyleBackColor = True
        '
        'chkCreateInParentFolder
        '
        Me.chkCreateInParentFolder.AutoSize = True
        Me.chkCreateInParentFolder.Location = New System.Drawing.Point(303, 131)
        Me.chkCreateInParentFolder.Name = "chkCreateInParentFolder"
        Me.chkCreateInParentFolder.Size = New System.Drawing.Size(134, 17)
        Me.chkCreateInParentFolder.TabIndex = 15
        Me.chkCreateInParentFolder.Text = "Create in Parent Folder"
        Me.chkCreateInParentFolder.UseVisualStyleBackColor = True
        '
        'lbResizeResolution
        '
        Me.lbResizeResolution.AutoSize = True
        Me.lbResizeResolution.Location = New System.Drawing.Point(189, 132)
        Me.lbResizeResolution.Name = "lbResizeResolution"
        Me.lbResizeResolution.Size = New System.Drawing.Size(56, 13)
        Me.lbResizeResolution.TabIndex = 16
        Me.lbResizeResolution.Text = "Reduce %"
        '
        'txtResizeResolution
        '
        Me.txtResizeResolution.Location = New System.Drawing.Point(251, 130)
        Me.txtResizeResolution.Name = "txtResizeResolution"
        Me.txtResizeResolution.Size = New System.Drawing.Size(36, 20)
        Me.txtResizeResolution.TabIndex = 17
        Me.txtResizeResolution.Text = "160"
        '
        'chkBookmarks
        '
        Me.chkBookmarks.AutoSize = True
        Me.chkBookmarks.Checked = True
        Me.chkBookmarks.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBookmarks.Location = New System.Drawing.Point(444, 107)
        Me.chkBookmarks.Name = "chkBookmarks"
        Me.chkBookmarks.Size = New System.Drawing.Size(101, 17)
        Me.chkBookmarks.TabIndex = 18
        Me.chkBookmarks.Text = "Add Bookmarks"
        Me.chkBookmarks.UseVisualStyleBackColor = True
        '
        'chkOCR
        '
        Me.chkOCR.AutoSize = True
        Me.chkOCR.Location = New System.Drawing.Point(444, 131)
        Me.chkOCR.Name = "chkOCR"
        Me.chkOCR.Size = New System.Drawing.Size(49, 17)
        Me.chkOCR.TabIndex = 19
        Me.chkOCR.Text = "OCR"
        Me.chkOCR.UseVisualStyleBackColor = True
        '
        'pnOCR
        '
        Me.pnOCR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnOCR.Controls.Add(Me.lbGhostscript)
        Me.pnOCR.Controls.Add(Me.lbTesseract)
        Me.pnOCR.Controls.Add(Me.btnGhostscript)
        Me.pnOCR.Controls.Add(Me.btnTesseract)
        Me.pnOCR.Controls.Add(Me.txtGhostscriptPath)
        Me.pnOCR.Controls.Add(Me.txtTesseractPath)
        Me.pnOCR.Location = New System.Drawing.Point(4, 151)
        Me.pnOCR.Name = "pnOCR"
        Me.pnOCR.Size = New System.Drawing.Size(548, 60)
        Me.pnOCR.TabIndex = 20
        '
        'lbGhostscript
        '
        Me.lbGhostscript.AutoSize = True
        Me.lbGhostscript.Location = New System.Drawing.Point(8, 40)
        Me.lbGhostscript.Name = "lbGhostscript"
        Me.lbGhostscript.Size = New System.Drawing.Size(80, 13)
        Me.lbGhostscript.TabIndex = 31
        Me.lbGhostscript.TabStop = True
        Me.lbGhostscript.Text = "Ghostscript exe"
        '
        'lbTesseract
        '
        Me.lbTesseract.AutoSize = True
        Me.lbTesseract.Location = New System.Drawing.Point(8, 11)
        Me.lbTesseract.Name = "lbTesseract"
        Me.lbTesseract.Size = New System.Drawing.Size(74, 13)
        Me.lbTesseract.TabIndex = 30
        Me.lbTesseract.TabStop = True
        Me.lbTesseract.Text = "Tesseract exe"
        '
        'btnGhostscript
        '
        Me.btnGhostscript.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGhostscript.Location = New System.Drawing.Point(504, 37)
        Me.btnGhostscript.Name = "btnGhostscript"
        Me.btnGhostscript.Size = New System.Drawing.Size(28, 23)
        Me.btnGhostscript.TabIndex = 27
        Me.btnGhostscript.Text = "..."
        Me.btnGhostscript.UseVisualStyleBackColor = True
        '
        'btnTesseract
        '
        Me.btnTesseract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTesseract.Location = New System.Drawing.Point(504, 5)
        Me.btnTesseract.Name = "btnTesseract"
        Me.btnTesseract.Size = New System.Drawing.Size(28, 23)
        Me.btnTesseract.TabIndex = 21
        Me.btnTesseract.Text = "..."
        Me.btnTesseract.UseVisualStyleBackColor = True
        '
        'txtGhostscriptPath
        '
        Me.txtGhostscriptPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGhostscriptPath.Location = New System.Drawing.Point(113, 37)
        Me.txtGhostscriptPath.Name = "txtGhostscriptPath"
        Me.txtGhostscriptPath.Size = New System.Drawing.Size(385, 20)
        Me.txtGhostscriptPath.TabIndex = 29
        '
        'txtTesseractPath
        '
        Me.txtTesseractPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTesseractPath.Location = New System.Drawing.Point(113, 8)
        Me.txtTesseractPath.Name = "txtTesseractPath"
        Me.txtTesseractPath.Size = New System.Drawing.Size(385, 20)
        Me.txtTesseractPath.TabIndex = 27
        '
        'dOpenFile
        '
        Me.dOpenFile.FileName = "OpenFileDialog1"
        '
        'chkReduce
        '
        Me.chkReduce.AutoSize = True
        Me.chkReduce.Checked = True
        Me.chkReduce.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReduce.Location = New System.Drawing.Point(223, 107)
        Me.chkReduce.Name = "chkReduce"
        Me.chkReduce.Size = New System.Drawing.Size(64, 17)
        Me.chkReduce.TabIndex = 21
        Me.chkReduce.Text = "Reduce"
        Me.chkReduce.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 450)
        Me.Controls.Add(Me.chkReduce)
        Me.Controls.Add(Me.pnOCR)
        Me.Controls.Add(Me.chkOCR)
        Me.Controls.Add(Me.chkBookmarks)
        Me.Controls.Add(Me.txtResizeResolution)
        Me.Controls.Add(Me.lbResizeResolution)
        Me.Controls.Add(Me.chkCreateInParentFolder)
        Me.Controls.Add(Me.chkDeleteSourceFiles)
        Me.Controls.Add(Me.chkResize)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbFileType)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnFrom)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.btnProcess)
        Me.Name = "Form1"
        Me.Text = "Merge PDF"
        Me.pnOCR.ResumeLayout(False)
        Me.pnOCR.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcess As System.Windows.Forms.Button
	Friend WithEvents txtFrom As System.Windows.Forms.TextBox
	Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
	Friend WithEvents fldFrom As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents fldTo As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents btnFrom As System.Windows.Forms.Button
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents txtPassword As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents cbFileType As System.Windows.Forms.ComboBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtOutput As System.Windows.Forms.TextBox
	Friend WithEvents chkResize As System.Windows.Forms.CheckBox
	Friend WithEvents chkDeleteSourceFiles As System.Windows.Forms.CheckBox
	Friend WithEvents chkCreateInParentFolder As System.Windows.Forms.CheckBox
	Friend WithEvents lbResizeResolution As System.Windows.Forms.Label
	Friend WithEvents txtResizeResolution As System.Windows.Forms.TextBox
	Friend WithEvents chkBookmarks As System.Windows.Forms.CheckBox
	Friend WithEvents chkOCR As System.Windows.Forms.CheckBox
	Friend WithEvents pnOCR As System.Windows.Forms.Panel
	Friend WithEvents btnGhostscript As System.Windows.Forms.Button
	Friend WithEvents btnTesseract As System.Windows.Forms.Button
	Friend WithEvents txtGhostscriptPath As System.Windows.Forms.TextBox
	Friend WithEvents txtTesseractPath As System.Windows.Forms.TextBox
	Friend WithEvents dOpenFile As System.Windows.Forms.OpenFileDialog
	Friend WithEvents lbGhostscript As System.Windows.Forms.LinkLabel
	Friend WithEvents lbTesseract As System.Windows.Forms.LinkLabel
    Friend WithEvents chkReduce As CheckBox
End Class
