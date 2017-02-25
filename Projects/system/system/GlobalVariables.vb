Imports System.Data.OleDb
Imports System.ComponentModel
Public Module GlobalVariables
    
    Public getUser As String
    Public getFirstName As String
    Public getLastName As String
    Public totalmoskwh As Integer
    Public sampleID As String
    Public cnn As OleDbConnection = New OleDbConnection
    Public serviceInfo As ArrayList = New ArrayList(100)
    Public averageKWH As ArrayList = New ArrayList(50)
    Public sample2 As String = ""
    Public FirstMonth As Boolean
    Public SecMonth As Boolean
End Module
