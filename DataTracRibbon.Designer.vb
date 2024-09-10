Partial Class DataTracRibbon
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.DisplayGroup = Me.Factory.CreateRibbonGroup
        Me.OptionsGroup = Me.Factory.CreateRibbonGroup
        Me.ClearDisplayOnExit = Me.Factory.CreateRibbonCheckBox
        Me.RefreshDisplayOnRefreshAll = Me.Factory.CreateRibbonCheckBox
        Me.RefreshDisplayOnFileOpen = Me.Factory.CreateRibbonCheckBox
        Me.refreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Group3 = Me.Factory.CreateRibbonGroup
        Me.WorkbookIsDatatracSourceButton = Me.Factory.CreateRibbonToggleButton
        Me.BuildMessageButton = Me.Factory.CreateRibbonButton
        Me.RefreshDisplayButton = Me.Factory.CreateRibbonSplitButton
        Me.RefreshManuallyButton = Me.Factory.CreateRibbonCheckBox
        Me.Refresh15Mins = Me.Factory.CreateRibbonCheckBox
        Me.Refresh30Mins = Me.Factory.CreateRibbonCheckBox
        Me.Refresh1Hour = Me.Factory.CreateRibbonCheckBox
        Me.Refresh1DayButton = Me.Factory.CreateRibbonCheckBox
        Me.ClearDisplayButton = Me.Factory.CreateRibbonButton
        Me.ResetDisplayButton = Me.Factory.CreateRibbonButton
        Me.ShowPreviewButton = Me.Factory.CreateRibbonButton
        Me.Tab1.SuspendLayout()
        Me.DisplayGroup.SuspendLayout()
        Me.OptionsGroup.SuspendLayout()
        Me.Group3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.Tab1.Groups.Add(Me.Group3)
        Me.Tab1.Groups.Add(Me.DisplayGroup)
        Me.Tab1.Groups.Add(Me.OptionsGroup)
        Me.Tab1.Label = "DataTrac"
        Me.Tab1.Name = "Tab1"
        '
        'DisplayGroup
        '
        Me.DisplayGroup.Items.Add(Me.BuildMessageButton)
        Me.DisplayGroup.Items.Add(Me.RefreshDisplayButton)
        Me.DisplayGroup.Items.Add(Me.ClearDisplayButton)
        Me.DisplayGroup.Items.Add(Me.ResetDisplayButton)
        Me.DisplayGroup.Items.Add(Me.ShowPreviewButton)
        Me.DisplayGroup.Label = "Display"
        Me.DisplayGroup.Name = "DisplayGroup"
        Me.DisplayGroup.Visible = False
        '
        'OptionsGroup
        '
        Me.OptionsGroup.Items.Add(Me.RefreshDisplayOnFileOpen)
        Me.OptionsGroup.Items.Add(Me.ClearDisplayOnExit)
        Me.OptionsGroup.Items.Add(Me.RefreshDisplayOnRefreshAll)
        Me.OptionsGroup.Label = "Options"
        Me.OptionsGroup.Name = "OptionsGroup"
        Me.OptionsGroup.Visible = False
        '
        'ClearDisplayOnExit
        '
        Me.ClearDisplayOnExit.Label = "Clear Displays on Exit"
        Me.ClearDisplayOnExit.Name = "ClearDisplayOnExit"
        Me.ClearDisplayOnExit.ScreenTip = "Clear the display when Excel closes."
        '
        'RefreshDisplayOnRefreshAll
        '
        Me.RefreshDisplayOnRefreshAll.Label = "Refresh Displays on Refresh-All"
        Me.RefreshDisplayOnRefreshAll.Name = "RefreshDisplayOnRefreshAll"
        Me.RefreshDisplayOnRefreshAll.ScreenTip = "Automatically refresh the currently active message whenever the Refresh-All butto" &
    "n is clicked"
        Me.RefreshDisplayOnRefreshAll.Visible = False
        '
        'RefreshDisplayOnFileOpen
        '
        Me.RefreshDisplayOnFileOpen.Label = "Refresh Displays on Open"
        Me.RefreshDisplayOnFileOpen.Name = "RefreshDisplayOnFileOpen"
        '
        'refreshTimer
        '
        '
        'Group3
        '
        Me.Group3.Items.Add(Me.WorkbookIsDatatracSourceButton)
        Me.Group3.Label = "DataTrac"
        Me.Group3.Name = "Group3"
        '
        'WorkbookIsDatatracSourceButton
        '
        Me.WorkbookIsDatatracSourceButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.WorkbookIsDatatracSourceButton.Image = Global.DatatracController_Excel.My.Resources.Resources.check
        Me.WorkbookIsDatatracSourceButton.Label = "Enable DataTrac"
        Me.WorkbookIsDatatracSourceButton.Name = "WorkbookIsDatatracSourceButton"
        Me.WorkbookIsDatatracSourceButton.ShowImage = True
        '
        'BuildMessageButton
        '
        Me.BuildMessageButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.BuildMessageButton.Image = Global.DatatracController_Excel.My.Resources.Resources.table_col_2
        Me.BuildMessageButton.Label = "Displays && Messages"
        Me.BuildMessageButton.Name = "BuildMessageButton"
        Me.BuildMessageButton.ScreenTip = "Show the Message Builder window"
        Me.BuildMessageButton.ShowImage = True
        '
        'RefreshDisplayButton
        '
        Me.RefreshDisplayButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.RefreshDisplayButton.Image = Global.DatatracController_Excel.My.Resources.Resources.send
        Me.RefreshDisplayButton.Items.Add(Me.RefreshManuallyButton)
        Me.RefreshDisplayButton.Items.Add(Me.Refresh15Mins)
        Me.RefreshDisplayButton.Items.Add(Me.Refresh30Mins)
        Me.RefreshDisplayButton.Items.Add(Me.Refresh1Hour)
        Me.RefreshDisplayButton.Items.Add(Me.Refresh1DayButton)
        Me.RefreshDisplayButton.Label = "Send Message"
        Me.RefreshDisplayButton.Name = "RefreshDisplayButton"
        Me.RefreshDisplayButton.ScreenTip = "Refresh the currently displayed message."
        '
        'RefreshManuallyButton
        '
        Me.RefreshManuallyButton.Checked = True
        Me.RefreshManuallyButton.Label = "Manual"
        Me.RefreshManuallyButton.Name = "RefreshManuallyButton"
        '
        'Refresh15Mins
        '
        Me.Refresh15Mins.Label = "Every 15 Mins."
        Me.Refresh15Mins.Name = "Refresh15Mins"
        '
        'Refresh30Mins
        '
        Me.Refresh30Mins.Label = "Every 30 Mins."
        Me.Refresh30Mins.Name = "Refresh30Mins"
        '
        'Refresh1Hour
        '
        Me.Refresh1Hour.Label = "Every Hour"
        Me.Refresh1Hour.Name = "Refresh1Hour"
        '
        'Refresh1DayButton
        '
        Me.Refresh1DayButton.Label = "Every Day"
        Me.Refresh1DayButton.Name = "Refresh1DayButton"
        '
        'ClearDisplayButton
        '
        Me.ClearDisplayButton.Image = Global.DatatracController_Excel.My.Resources.Resources.close
        Me.ClearDisplayButton.Label = "Clear Displays"
        Me.ClearDisplayButton.Name = "ClearDisplayButton"
        Me.ClearDisplayButton.ScreenTip = "Clear all text from the display."
        Me.ClearDisplayButton.ShowImage = True
        '
        'ResetDisplayButton
        '
        Me.ResetDisplayButton.Image = Global.DatatracController_Excel.My.Resources.Resources.reset
        Me.ResetDisplayButton.Label = "Reset Displays"
        Me.ResetDisplayButton.Name = "ResetDisplayButton"
        Me.ResetDisplayButton.ScreenTip = "Reset the display's internal controller"
        Me.ResetDisplayButton.ShowImage = True
        Me.ResetDisplayButton.SuperTip = "Resetting the display is useful if anything unexpected happens with the display i" &
    "tself. This will also display the Baud rate and display address."
        '
        'ShowPreviewButton
        '
        Me.ShowPreviewButton.Image = Global.DatatracController_Excel.My.Resources.Resources.dak_preview
        Me.ShowPreviewButton.Label = "Show Preview"
        Me.ShowPreviewButton.Name = "ShowPreviewButton"
        Me.ShowPreviewButton.ShowImage = True
        '
        'DataTracRibbon
        '
        Me.Name = "DataTracRibbon"
        Me.RibbonType = "Microsoft.Excel.Workbook"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.DisplayGroup.ResumeLayout(False)
        Me.DisplayGroup.PerformLayout()
        Me.OptionsGroup.ResumeLayout(False)
        Me.OptionsGroup.PerformLayout()
        Me.Group3.ResumeLayout(False)
        Me.Group3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents DisplayGroup As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents BuildMessageButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents RefreshDisplayButton As Microsoft.Office.Tools.Ribbon.RibbonSplitButton
    Friend WithEvents RefreshManuallyButton As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents Refresh15Mins As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents Refresh30Mins As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents Refresh1Hour As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents Refresh1DayButton As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents OptionsGroup As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents ClearDisplayOnExit As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents RefreshDisplayOnRefreshAll As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents ClearDisplayButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents ResetDisplayButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents RefreshDisplayOnFileOpen As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents refreshTimer As Timer
    Friend WithEvents ShowPreviewButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Group3 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents WorkbookIsDatatracSourceButton As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property DataTracRibbon() As DataTracRibbon
        Get
            Return Me.GetRibbon(Of DataTracRibbon)()
        End Get
    End Property
End Class
