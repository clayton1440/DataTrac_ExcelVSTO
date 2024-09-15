Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DisplayInterface
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Displays")
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.AddFieldButton = New System.Windows.Forms.ToolStripButton()
        Me.RemoveFieldButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyFieldButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveMessageButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolButton = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DGVMessageEditor = New System.Windows.Forms.DataGridView()
        Me.MessagePreview = New System.Windows.Forms.PictureBox()
        Me.Node1CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearDisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetDisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditDisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteDisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Node0CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewDisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExpandAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollapseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Node2CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMessageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGVMessageEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MessagePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Node1CM.SuspendLayout()
        Me.Node0CM.SuspendLayout()
        Me.Node2CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Enabled = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddFieldButton, Me.RemoveFieldButton, Me.CopyFieldButton, Me.ToolStripSeparator4, Me.SaveMessageButton, Me.ToolStripSeparator1, Me.HelpToolButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(669, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'AddFieldButton
        '
        Me.AddFieldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddFieldButton.Image = Global.DatatracController_Excel.My.Resources.Resources._new
        Me.AddFieldButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddFieldButton.Name = "AddFieldButton"
        Me.AddFieldButton.Size = New System.Drawing.Size(23, 22)
        Me.AddFieldButton.Text = "Add Field"
        '
        'RemoveFieldButton
        '
        Me.RemoveFieldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RemoveFieldButton.Image = Global.DatatracController_Excel.My.Resources.Resources.trash
        Me.RemoveFieldButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RemoveFieldButton.Name = "RemoveFieldButton"
        Me.RemoveFieldButton.Size = New System.Drawing.Size(23, 22)
        Me.RemoveFieldButton.Text = "Delete Field"
        '
        'CopyFieldButton
        '
        Me.CopyFieldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyFieldButton.Image = Global.DatatracController_Excel.My.Resources.Resources.copy
        Me.CopyFieldButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyFieldButton.Name = "CopyFieldButton"
        Me.CopyFieldButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyFieldButton.Text = "Duplicate Field"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'SaveMessageButton
        '
        Me.SaveMessageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveMessageButton.Image = Global.DatatracController_Excel.My.Resources.Resources.save
        Me.SaveMessageButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveMessageButton.Name = "SaveMessageButton"
        Me.SaveMessageButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveMessageButton.Text = "Save Message"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolButton
        '
        Me.HelpToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolButton.Image = Global.DatatracController_Excel.My.Resources.Resources.help
        Me.HelpToolButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolButton.Name = "HelpToolButton"
        Me.HelpToolButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolButton.Text = "Help"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer2.Panel1MinSize = 100
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Panel2MinSize = 500
        Me.SplitContainer2.Size = New System.Drawing.Size(883, 450)
        Me.SplitContainer2.SplitterDistance = 210
        Me.SplitContainer2.TabIndex = 8
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "DisplaysNode"
        TreeNode1.Text = "Displays"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.Size = New System.Drawing.Size(210, 450)
        Me.TreeView1.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGVMessageEditor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.MessagePreview)
        Me.SplitContainer1.Size = New System.Drawing.Size(669, 450)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.TabIndex = 0
        '
        'DGVMessageEditor
        '
        Me.DGVMessageEditor.AllowUserToAddRows = False
        Me.DGVMessageEditor.AllowUserToDeleteRows = False
        Me.DGVMessageEditor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVMessageEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVMessageEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVMessageEditor.Location = New System.Drawing.Point(0, 25)
        Me.DGVMessageEditor.Name = "DGVMessageEditor"
        Me.DGVMessageEditor.RowHeadersWidth = 32
        Me.DGVMessageEditor.Size = New System.Drawing.Size(669, 275)
        Me.DGVMessageEditor.TabIndex = 4
        '
        'MessagePreview
        '
        Me.MessagePreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessagePreview.Location = New System.Drawing.Point(0, 0)
        Me.MessagePreview.Name = "MessagePreview"
        Me.MessagePreview.Size = New System.Drawing.Size(669, 146)
        Me.MessagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MessagePreview.TabIndex = 0
        Me.MessagePreview.TabStop = False
        '
        'Node1CM
        '
        Me.Node1CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMessageToolStripMenuItem, Me.ToolStripSeparator3, Me.ClearDisplayToolStripMenuItem, Me.ResetDisplayToolStripMenuItem, Me.ToolStripSeparator7, Me.EditDisplayToolStripMenuItem, Me.DeleteDisplayToolStripMenuItem})
        Me.Node1CM.Name = "DisplayNodeCM"
        Me.Node1CM.Size = New System.Drawing.Size(149, 126)
        '
        'AddMessageToolStripMenuItem
        '
        Me.AddMessageToolStripMenuItem.Image = Global.DatatracController_Excel.My.Resources.Resources._new
        Me.AddMessageToolStripMenuItem.Name = "AddMessageToolStripMenuItem"
        Me.AddMessageToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AddMessageToolStripMenuItem.Text = "Add Message"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(145, 6)
        '
        'ClearDisplayToolStripMenuItem
        '
        Me.ClearDisplayToolStripMenuItem.Name = "ClearDisplayToolStripMenuItem"
        Me.ClearDisplayToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ClearDisplayToolStripMenuItem.Text = "Clear Display"
        '
        'ResetDisplayToolStripMenuItem
        '
        Me.ResetDisplayToolStripMenuItem.Name = "ResetDisplayToolStripMenuItem"
        Me.ResetDisplayToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ResetDisplayToolStripMenuItem.Text = "Reset Display"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(145, 6)
        '
        'EditDisplayToolStripMenuItem
        '
        Me.EditDisplayToolStripMenuItem.Name = "EditDisplayToolStripMenuItem"
        Me.EditDisplayToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EditDisplayToolStripMenuItem.Text = "Edit Display"
        '
        'DeleteDisplayToolStripMenuItem
        '
        Me.DeleteDisplayToolStripMenuItem.Name = "DeleteDisplayToolStripMenuItem"
        Me.DeleteDisplayToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteDisplayToolStripMenuItem.Text = "Delete Display"
        '
        'Node0CM
        '
        Me.Node0CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewDisplayToolStripMenuItem, Me.ToolStripSeparator10, Me.ExpandAllToolStripMenuItem, Me.CollapseAllToolStripMenuItem})
        Me.Node0CM.Name = "Node0CM"
        Me.Node0CM.Size = New System.Drawing.Size(140, 76)
        '
        'NewDisplayToolStripMenuItem
        '
        Me.NewDisplayToolStripMenuItem.Image = Global.DatatracController_Excel.My.Resources.Resources._new
        Me.NewDisplayToolStripMenuItem.Name = "NewDisplayToolStripMenuItem"
        Me.NewDisplayToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.NewDisplayToolStripMenuItem.Text = "New Display"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(136, 6)
        '
        'ExpandAllToolStripMenuItem
        '
        Me.ExpandAllToolStripMenuItem.Name = "ExpandAllToolStripMenuItem"
        Me.ExpandAllToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ExpandAllToolStripMenuItem.Text = "Expand All"
        '
        'CollapseAllToolStripMenuItem
        '
        Me.CollapseAllToolStripMenuItem.Name = "CollapseAllToolStripMenuItem"
        Me.CollapseAllToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CollapseAllToolStripMenuItem.Text = "Collapse All"
        '
        'Node2CM
        '
        Me.Node2CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteMessageToolStripMenuItem1})
        Me.Node2CM.Name = "DisplayNodeCM"
        Me.Node2CM.Size = New System.Drawing.Size(157, 26)
        '
        'DeleteMessageToolStripMenuItem1
        '
        Me.DeleteMessageToolStripMenuItem1.Image = Global.DatatracController_Excel.My.Resources.Resources.trash
        Me.DeleteMessageToolStripMenuItem1.Name = "DeleteMessageToolStripMenuItem1"
        Me.DeleteMessageToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.DeleteMessageToolStripMenuItem1.Text = "Delete Message"
        '
        'DisplayInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(883, 450)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Name = "DisplayInterface"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Message Editor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGVMessageEditor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MessagePreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Node1CM.ResumeLayout(False)
        Me.Node0CM.ResumeLayout(False)
        Me.Node2CM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents RemoveFieldButton As ToolStripButton
    Friend WithEvents CopyFieldButton As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents HelpToolButton As ToolStripButton
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MessagePreview As PictureBox
    Friend WithEvents Node1CM As ContextMenuStrip
    Friend WithEvents AddMessageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ClearDisplayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetDisplayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents DeleteDisplayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Node0CM As ContextMenuStrip
    Friend WithEvents NewDisplayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CollapseAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents ExpandAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DGVMessageEditor As DataGridView
    Friend WithEvents AddFieldButton As ToolStripButton
    Friend WithEvents SaveMessageButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Node2CM As ContextMenuStrip
    Friend WithEvents DeleteMessageToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditDisplayToolStripMenuItem As ToolStripMenuItem
End Class
