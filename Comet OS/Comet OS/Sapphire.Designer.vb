<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sapphire
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sapphire))
        Me.closeButton = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.search = New System.Windows.Forms.Button()
        Me.goButton = New System.Windows.Forms.Button()
        Me.goBack = New System.Windows.Forms.Button()
        Me.goForward = New System.Windows.Forms.Button()
        Me.stopLoad = New System.Windows.Forms.Button()
        Me.reload = New System.Windows.Forms.Button()
        Me.delTab = New System.Windows.Forms.Button()
        Me.addTab = New System.Windows.Forms.Button()
        Me.home = New System.Windows.Forms.Button()
        Me.urlBar = New System.Windows.Forms.TextBox()
        Me.resizePanel = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.resizer = New System.Windows.Forms.Timer(Me.components)
        Me.Progress = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'closeButton
        '
        Me.closeButton.AutoSize = True
        Me.closeButton.BackColor = System.Drawing.Color.Transparent
        Me.closeButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.closeButton.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeButton.ForeColor = System.Drawing.Color.Black
        Me.closeButton.Location = New System.Drawing.Point(841, 0)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(18, 19)
        Me.closeButton.TabIndex = 53
        Me.closeButton.Text = "X"
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.Dock = System.Windows.Forms.DockStyle.Left
        Me.title.Font = New System.Drawing.Font("Corbel", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Black
        Me.title.Location = New System.Drawing.Point(0, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(145, 18)
        Me.title.TabIndex = 82
        Me.title.Text = "Sapphire Web Browser"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.search)
        Me.Panel1.Controls.Add(Me.goButton)
        Me.Panel1.Controls.Add(Me.goBack)
        Me.Panel1.Controls.Add(Me.goForward)
        Me.Panel1.Controls.Add(Me.stopLoad)
        Me.Panel1.Controls.Add(Me.reload)
        Me.Panel1.Controls.Add(Me.delTab)
        Me.Panel1.Controls.Add(Me.addTab)
        Me.Panel1.Controls.Add(Me.home)
        Me.Panel1.Controls.Add(Me.urlBar)
        Me.Panel1.Controls.Add(Me.resizePanel)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Location = New System.Drawing.Point(-3, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(862, 599)
        Me.Panel1.TabIndex = 90
        '
        'search
        '
        Me.search.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.search.BackColor = System.Drawing.Color.Transparent
        Me.search.BackgroundImage = Global.Comet_OS.My.Resources.Resources.monotone_cog_settings_gear
        Me.search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.search.FlatAppearance.BorderSize = 0
        Me.search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.search.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.search.Location = New System.Drawing.Point(661, 558)
        Me.search.Name = "search"
        Me.search.Size = New System.Drawing.Size(27, 27)
        Me.search.TabIndex = 120
        Me.search.UseVisualStyleBackColor = False
        '
        'goButton
        '
        Me.goButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goButton.FlatAppearance.BorderSize = 0
        Me.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.goButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.goButton.Location = New System.Drawing.Point(479, 569)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(10, 10)
        Me.goButton.TabIndex = 119
        Me.goButton.Text = "Button1"
        Me.goButton.UseVisualStyleBackColor = True
        '
        'goBack
        '
        Me.goBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goBack.BackColor = System.Drawing.Color.Transparent
        Me.goBack.BackgroundImage = CType(resources.GetObject("goBack.BackgroundImage"), System.Drawing.Image)
        Me.goBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.goBack.FlatAppearance.BorderSize = 0
        Me.goBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.goBack.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.goBack.Location = New System.Drawing.Point(742, 563)
        Me.goBack.Name = "goBack"
        Me.goBack.Size = New System.Drawing.Size(18, 22)
        Me.goBack.TabIndex = 118
        Me.goBack.UseVisualStyleBackColor = False
        '
        'goForward
        '
        Me.goForward.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goForward.BackColor = System.Drawing.Color.Transparent
        Me.goForward.BackgroundImage = CType(resources.GetObject("goForward.BackgroundImage"), System.Drawing.Image)
        Me.goForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.goForward.FlatAppearance.BorderSize = 0
        Me.goForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.goForward.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.goForward.Location = New System.Drawing.Point(766, 563)
        Me.goForward.Name = "goForward"
        Me.goForward.Size = New System.Drawing.Size(18, 22)
        Me.goForward.TabIndex = 117
        Me.goForward.UseVisualStyleBackColor = False
        '
        'stopLoad
        '
        Me.stopLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stopLoad.BackColor = System.Drawing.Color.Transparent
        Me.stopLoad.BackgroundImage = CType(resources.GetObject("stopLoad.BackgroundImage"), System.Drawing.Image)
        Me.stopLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.stopLoad.FlatAppearance.BorderSize = 0
        Me.stopLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stopLoad.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.stopLoad.Location = New System.Drawing.Point(790, 563)
        Me.stopLoad.Name = "stopLoad"
        Me.stopLoad.Size = New System.Drawing.Size(18, 22)
        Me.stopLoad.TabIndex = 116
        Me.stopLoad.UseVisualStyleBackColor = False
        '
        'reload
        '
        Me.reload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reload.BackColor = System.Drawing.Color.Transparent
        Me.reload.BackgroundImage = CType(resources.GetObject("reload.BackgroundImage"), System.Drawing.Image)
        Me.reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.reload.FlatAppearance.BorderSize = 0
        Me.reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reload.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.reload.Location = New System.Drawing.Point(814, 563)
        Me.reload.Name = "reload"
        Me.reload.Size = New System.Drawing.Size(18, 22)
        Me.reload.TabIndex = 115
        Me.reload.UseVisualStyleBackColor = False
        '
        'delTab
        '
        Me.delTab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.delTab.BackColor = System.Drawing.Color.Transparent
        Me.delTab.BackgroundImage = CType(resources.GetObject("delTab.BackgroundImage"), System.Drawing.Image)
        Me.delTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.delTab.FlatAppearance.BorderSize = 0
        Me.delTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.delTab.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.delTab.Location = New System.Drawing.Point(718, 563)
        Me.delTab.Name = "delTab"
        Me.delTab.Size = New System.Drawing.Size(18, 22)
        Me.delTab.TabIndex = 114
        Me.delTab.UseVisualStyleBackColor = False
        '
        'addTab
        '
        Me.addTab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addTab.BackColor = System.Drawing.Color.Transparent
        Me.addTab.BackgroundImage = CType(resources.GetObject("addTab.BackgroundImage"), System.Drawing.Image)
        Me.addTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.addTab.FlatAppearance.BorderSize = 0
        Me.addTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addTab.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.addTab.Location = New System.Drawing.Point(694, 563)
        Me.addTab.Name = "addTab"
        Me.addTab.Size = New System.Drawing.Size(18, 22)
        Me.addTab.TabIndex = 113
        Me.addTab.UseVisualStyleBackColor = False
        '
        'home
        '
        Me.home.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.home.BackColor = System.Drawing.Color.Transparent
        Me.home.BackgroundImage = CType(resources.GetObject("home.BackgroundImage"), System.Drawing.Image)
        Me.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.home.FlatAppearance.BorderSize = 0
        Me.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.home.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.home.Location = New System.Drawing.Point(838, 563)
        Me.home.Name = "home"
        Me.home.Size = New System.Drawing.Size(18, 22)
        Me.home.TabIndex = 112
        Me.home.UseVisualStyleBackColor = False
        '
        'urlBar
        '
        Me.urlBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.urlBar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.urlBar.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlBar.ForeColor = System.Drawing.Color.Black
        Me.urlBar.Location = New System.Drawing.Point(15, 567)
        Me.urlBar.Name = "urlBar"
        Me.urlBar.Size = New System.Drawing.Size(442, 15)
        Me.urlBar.TabIndex = 111
        '
        'resizePanel
        '
        Me.resizePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.resizePanel.BackColor = System.Drawing.Color.Transparent
        Me.resizePanel.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.resizePanel.Location = New System.Drawing.Point(850, 588)
        Me.resizePanel.Name = "resizePanel"
        Me.resizePanel.Size = New System.Drawing.Size(10, 10)
        Me.resizePanel.TabIndex = 110
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Location = New System.Drawing.Point(3, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(857, 549)
        Me.TabControl1.TabIndex = 108
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Comet_OS.My.Resources.Resources.fullscreen_32
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button1.Location = New System.Drawing.Point(817, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 18)
        Me.Button1.TabIndex = 120
        Me.Button1.UseVisualStyleBackColor = False
        '
        'resizer
        '
        Me.resizer.Interval = 1
        '
        'Progress
        '
        Me.Progress.Location = New System.Drawing.Point(151, 1)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(654, 18)
        Me.Progress.TabIndex = 121
        Me.Progress.Visible = False
        '
        'Sapphire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Comet_OS.My.Resources.Resources.gradient4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(859, 621)
        Me.Controls.Add(Me.Progress)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.closeButton)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Sapphire"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents closeButton As System.Windows.Forms.Label
    Friend WithEvents title As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents resizer As System.Windows.Forms.Timer
    Friend WithEvents resizePanel As System.Windows.Forms.Panel
    Friend WithEvents urlBar As System.Windows.Forms.TextBox
    Friend WithEvents home As System.Windows.Forms.Button
    Friend WithEvents delTab As System.Windows.Forms.Button
    Friend WithEvents addTab As System.Windows.Forms.Button
    Friend WithEvents goForward As System.Windows.Forms.Button
    Friend WithEvents stopLoad As System.Windows.Forms.Button
    Friend WithEvents reload As System.Windows.Forms.Button
    Friend WithEvents goBack As System.Windows.Forms.Button
    Friend WithEvents goButton As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents search As System.Windows.Forms.Button
    Friend WithEvents Progress As System.Windows.Forms.ProgressBar
End Class
