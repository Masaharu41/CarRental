<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Summary_Form
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
        Me.TotalCustomersLabel = New System.Windows.Forms.Label()
        Me.TotalMilesLabel = New System.Windows.Forms.Label()
        Me.TotalChargesLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TotalCustomersLabel
        '
        Me.TotalCustomersLabel.AutoSize = True
        Me.TotalCustomersLabel.Location = New System.Drawing.Point(122, 90)
        Me.TotalCustomersLabel.Name = "TotalCustomersLabel"
        Me.TotalCustomersLabel.Size = New System.Drawing.Size(175, 25)
        Me.TotalCustomersLabel.TabIndex = 0
        Me.TotalCustomersLabel.Text = "Total Customers:"
        '
        'TotalMilesLabel
        '
        Me.TotalMilesLabel.AutoSize = True
        Me.TotalMilesLabel.Location = New System.Drawing.Point(122, 129)
        Me.TotalMilesLabel.Name = "TotalMilesLabel"
        Me.TotalMilesLabel.Size = New System.Drawing.Size(191, 25)
        Me.TotalMilesLabel.TabIndex = 1
        Me.TotalMilesLabel.Text = "Total Miles Driven:"
        '
        'TotalChargesLabel
        '
        Me.TotalChargesLabel.AutoSize = True
        Me.TotalChargesLabel.Location = New System.Drawing.Point(122, 171)
        Me.TotalChargesLabel.Name = "TotalChargesLabel"
        Me.TotalChargesLabel.Size = New System.Drawing.Size(153, 25)
        Me.TotalChargesLabel.TabIndex = 2
        Me.TotalChargesLabel.Text = "Total Charges:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(406, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(406, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(406, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 25)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Label6"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(411, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 37)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Summary_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 335)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TotalChargesLabel)
        Me.Controls.Add(Me.TotalMilesLabel)
        Me.Controls.Add(Me.TotalCustomersLabel)
        Me.Name = "Summary_Form"
        Me.Text = "Summary_Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TotalCustomersLabel As Label
    Friend WithEvents TotalMilesLabel As Label
    Friend WithEvents TotalChargesLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
End Class
