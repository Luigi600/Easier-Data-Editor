Imports System.Windows
Imports ICSharpCode

Public Interface ITextEditor
    Property Path As String
    Property ID As Integer
    Delegate Sub CustomEvent(sender As Object, e As class_customEventArgs)
    Function GetAvalonEditor() As AvalonEdit.TextEditor
    Event SaveStateChanged As CustomEvent
    Event TextChanged As EventHandler
    Event DropEventOfEditor As CustomEvent
    Event CurrentFrameViewerChanger As EventHandler
    Property Viewer As ui_frameViewer
    Property IsSave As Boolean
    'Property ErrorList As List(Of ErrorItem)
    Property ErrorSearcher As ErrorSearcher

    Sub SetErrorList(Optional ByVal checkVis As Boolean = True)
    Sub SetUnusedFramesList(Optional ByVal checkVis As Boolean = True)
    Sub SetFolding()

    Sub Expand(Optional ByVal expand As Boolean = False)
    Sub Collapse(Optional ByVal expand As Boolean = False)

    Sub PasteCool()

    Function getDockContent() As WeifenLuo.WinFormsUI.Docking.DockContent

    Sub Save(Optional ByVal saveAs As Boolean = False)
    Function CloseDocument() As Boolean
End Interface
