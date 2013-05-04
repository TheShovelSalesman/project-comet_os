<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.username = New System.Windows.Forms.TextBox()
        Me.password = New System.Windows.Forms.TextBox()
        Me.login = New System.Windows.Forms.Button()
        Me.create = New System.Windows.Forms.Button()
        Me.shutdown = New System.Windows.Forms.Button()
        Me.FadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.FadeOut = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'username
        '
        Me.username.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.username.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.ForeColor = System.Drawing.Color.Black
        Me.username.Location = New System.Drawing.Point(592, 345)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(183, 15)
        Me.username.TabIndex = 33
        '
        'password
        '
        Me.password.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.password.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.ForeColor = System.Drawing.Color.Black
        Me.password.Location = New System.Drawing.Point(592, 380)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9642)
        Me.password.Size = New System.Drawing.Size(183, 15)
        Me.password.TabIndex = 34
        '
        'login
        '
        Me.login.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.login.BackColor = System.Drawing.Color.Transparent
        Me.login.FlatAppearance.BorderSize = 0
        Me.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.login.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login.ForeColor = System.Drawing.Color.Black
        Me.login.Location = New System.Drawing.Point(592, 401)
        Me.login.Name = "login"
        Me.login.Size = New System.Drawing.Size(50, 23)
        Me.login.TabIndex = 37
        Me.login.Text = "Login"
        Me.login.UseVisualStyleBackColor = False
        '
        'create
        '
        Me.create.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.create.BackColor = System.Drawing.Color.Transparent
        Me.create.FlatAppearance.BorderSize = 0
        Me.create.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.create.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.create.ForeColor = System.Drawing.Color.Black
        Me.create.Location = New System.Drawing.Point(648, 401)
        Me.create.Name = "create"
        Me.create.Size = New System.Drawing.Size(51, 23)
        Me.create.TabIndex = 38
        Me.create.Text = "Create"
        Me.create.UseVisualStyleBackColor = False
        '
        'shutdown
        '
        Me.shutdown.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.shutdown.BackColor = System.Drawing.Color.Transparent
        Me.shutdown.FlatAppearance.BorderSize = 0
        Me.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.shutdown.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shutdown.ForeColor = System.Drawing.Color.Black
        Me.shutdown.Location = New System.Drawing.Point(705, 401)
        Me.shutdown.Name = "shutdown"
        Me.shutdown.Size = New System.Drawing.Size(70, 23)
        Me.shutdown.TabIndex = 39
        Me.shutdown.Text = "Shutdown"
        Me.shutdown.UseVisualStyleBackColor = False
        '
        'FadeIn
        '
        '
        'FadeOut
        '
        '
        'LoginForm
        '
        Me.AcceptButton = Me.login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Comet_OS.My.Resources.Resources.Dark_Gradient_Wallpaper_1920x1200
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.shutdown)
        Me.Controls.Add(Me.create)
        Me.Controls.Add(Me.login)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.username)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents username As System.Windows.Forms.TextBox
    Friend WithEvents password As System.Windows.Forms.TextBox
    Friend WithEvents login As System.Windows.Forms.Button
    Friend WithEvents create As System.Windows.Forms.Button
    Friend WithEvents shutdown As System.Windows.Forms.Button
    Friend WithEvents FadeIn As System.Windows.Forms.Timer
    Friend WithEvents FadeOut As System.Windows.Forms.Timer

End Class
