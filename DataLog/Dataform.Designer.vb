<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dataform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GraphPictureBox = New System.Windows.Forms.PictureBox()
        Me.ButtonGroupBox = New System.Windows.Forms.GroupBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.TimerControlButton = New System.Windows.Forms.Button()
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.FilePathToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SamplingToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GraphTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TimeComboBox = New System.Windows.Forms.ComboBox()
        Me.TimeFactorComboBox = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.SampleGroupBox = New System.Windows.Forms.GroupBox()
        Me.AllRadioButton = New System.Windows.Forms.RadioButton()
        Me.Sample30RadioButton = New System.Windows.Forms.RadioButton()
        Me.Sample100RadioButton = New System.Windows.Forms.RadioButton()
        CType(Me.GraphPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ButtonGroupBox.SuspendLayout()
        Me.TopMenuStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SampleGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GraphPictureBox
        '
        Me.GraphPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GraphPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GraphPictureBox.Location = New System.Drawing.Point(12, 27)
        Me.GraphPictureBox.Name = "GraphPictureBox"
        Me.GraphPictureBox.Size = New System.Drawing.Size(776, 316)
        Me.GraphPictureBox.TabIndex = 0
        Me.GraphPictureBox.TabStop = False
        '
        'ButtonGroupBox
        '
        Me.ButtonGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGroupBox.Controls.Add(Me.ExitButton)
        Me.ButtonGroupBox.Controls.Add(Me.TimerControlButton)
        Me.ButtonGroupBox.Location = New System.Drawing.Point(575, 349)
        Me.ButtonGroupBox.Name = "ButtonGroupBox"
        Me.ButtonGroupBox.Size = New System.Drawing.Size(225, 76)
        Me.ButtonGroupBox.TabIndex = 1
        Me.ButtonGroupBox.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(116, 19)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(104, 44)
        Me.ExitButton.TabIndex = 2
        Me.ExitButton.Text = "&Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'TimerControlButton
        '
        Me.TimerControlButton.Location = New System.Drawing.Point(6, 19)
        Me.TimerControlButton.Name = "TimerControlButton"
        Me.TimerControlButton.Size = New System.Drawing.Size(104, 44)
        Me.TimerControlButton.TabIndex = 0
        Me.TimerControlButton.Text = "Start"
        Me.TimerControlButton.UseVisualStyleBackColor = True
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripComboBox1})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(800, 27)
        Me.TopMenuStrip.TabIndex = 2
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ReloadToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 23)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ReloadToolStripMenuItem.Text = "&Reload"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilePathToolStripStatusLabel, Me.SamplingToolStripStatusLabel, Me.StatusToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'FilePathToolStripStatusLabel
        '
        Me.FilePathToolStripStatusLabel.Name = "FilePathToolStripStatusLabel"
        Me.FilePathToolStripStatusLabel.Size = New System.Drawing.Size(448, 17)
        Me.FilePathToolStripStatusLabel.Text = "FilePath:                                                                        " &
    "                                                            "
        '
        'SamplingToolStripStatusLabel
        '
        Me.SamplingToolStripStatusLabel.Name = "SamplingToolStripStatusLabel"
        Me.SamplingToolStripStatusLabel.Size = New System.Drawing.Size(83, 17)
        Me.SamplingToolStripStatusLabel.Text = "SamplingRate:"
        '
        'StatusToolStripStatusLabel
        '
        Me.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel"
        Me.StatusToolStripStatusLabel.Size = New System.Drawing.Size(90, 17)
        Me.StatusToolStripStatusLabel.Text = "ComportStatus:"
        '
        'GraphTimer
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TimeComboBox
        '
        Me.TimeComboBox.FormattingEnabled = True
        Me.TimeComboBox.Location = New System.Drawing.Point(12, 368)
        Me.TimeComboBox.Name = "TimeComboBox"
        Me.TimeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.TimeComboBox.TabIndex = 4
        '
        'TimeFactorComboBox
        '
        Me.TimeFactorComboBox.FormattingEnabled = True
        Me.TimeFactorComboBox.Location = New System.Drawing.Point(139, 368)
        Me.TimeFactorComboBox.Name = "TimeFactorComboBox"
        Me.TimeFactorComboBox.Size = New System.Drawing.Size(36, 21)
        Me.TimeFactorComboBox.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.ExitToolStripMenuItem, Me.GraphToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(107, 70)
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'GraphToolStripMenuItem
        '
        Me.GraphToolStripMenuItem.Name = "GraphToolStripMenuItem"
        Me.GraphToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.GraphToolStripMenuItem.Text = "&Graph"
        '
        'SampleGroupBox
        '
        Me.SampleGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SampleGroupBox.Controls.Add(Me.Sample100RadioButton)
        Me.SampleGroupBox.Controls.Add(Me.AllRadioButton)
        Me.SampleGroupBox.Controls.Add(Me.Sample30RadioButton)
        Me.SampleGroupBox.Location = New System.Drawing.Point(350, 349)
        Me.SampleGroupBox.Name = "SampleGroupBox"
        Me.SampleGroupBox.Size = New System.Drawing.Size(225, 76)
        Me.SampleGroupBox.TabIndex = 6
        Me.SampleGroupBox.TabStop = False
        '
        'AllRadioButton
        '
        Me.AllRadioButton.AutoSize = True
        Me.AllRadioButton.Location = New System.Drawing.Point(11, 40)
        Me.AllRadioButton.Name = "AllRadioButton"
        Me.AllRadioButton.Size = New System.Drawing.Size(79, 17)
        Me.AllRadioButton.TabIndex = 1
        Me.AllRadioButton.TabStop = True
        Me.AllRadioButton.Text = "All Samples"
        Me.AllRadioButton.UseVisualStyleBackColor = True
        '
        'Sample30RadioButton
        '
        Me.Sample30RadioButton.AutoSize = True
        Me.Sample30RadioButton.Location = New System.Drawing.Point(11, 17)
        Me.Sample30RadioButton.Name = "Sample30RadioButton"
        Me.Sample30RadioButton.Size = New System.Drawing.Size(80, 17)
        Me.Sample30RadioButton.TabIndex = 0
        Me.Sample30RadioButton.TabStop = True
        Me.Sample30RadioButton.Text = "30 Samples"
        Me.Sample30RadioButton.UseVisualStyleBackColor = True
        '
        'Sample100RadioButton
        '
        Me.Sample100RadioButton.AutoSize = True
        Me.Sample100RadioButton.Location = New System.Drawing.Point(105, 40)
        Me.Sample100RadioButton.Name = "Sample100RadioButton"
        Me.Sample100RadioButton.Size = New System.Drawing.Size(86, 17)
        Me.Sample100RadioButton.TabIndex = 2
        Me.Sample100RadioButton.TabStop = True
        Me.Sample100RadioButton.Text = "100 Samples"
        Me.Sample100RadioButton.UseVisualStyleBackColor = True
        '
        'Dataform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SampleGroupBox)
        Me.Controls.Add(Me.TimeFactorComboBox)
        Me.Controls.Add(Me.TimeComboBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ButtonGroupBox)
        Me.Controls.Add(Me.GraphPictureBox)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "Dataform"
        Me.Text = "Form1"
        CType(Me.GraphPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ButtonGroupBox.ResumeLayout(False)
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SampleGroupBox.ResumeLayout(False)
        Me.SampleGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GraphPictureBox As PictureBox
    Friend WithEvents ButtonGroupBox As GroupBox
    Friend WithEvents ExitButton As Button
    Friend WithEvents TimerControlButton As Button
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents FilePathToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents GraphTimer As Timer
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimeComboBox As ComboBox
    Friend WithEvents TimeFactorComboBox As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GraphToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SamplingToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents StatusToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents ReloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SampleGroupBox As GroupBox
    Friend WithEvents AllRadioButton As RadioButton
    Friend WithEvents Sample30RadioButton As RadioButton
    Friend WithEvents Sample100RadioButton As RadioButton
End Class
