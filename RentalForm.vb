'Owen Fujii
'RCET 2268
'Spring 2024
'Car Rental
'https://github.com/Masaharu41/CarRental.git


Option Explicit On
Option Strict On
Option Compare Binary

Imports System.Globalization
Public Class RentalForm

    Dim allStates As New List(Of String)

    Private Sub Loader(sender As Object, e As EventArgs) Handles Me.Load
        CalculateButton.Enabled = False
        NameTextBox.Text = ""
        AddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        BeginOdometerTextBox.Text = ""
        EndOdometerTextBox.Text = ""
        DaysTextBox.Text = ""
        BeginOdometerTextBox.Enabled = False
        EndOdometerTextBox.Enabled = False
        DaysTextBox.Enabled = False
        ReadStates()

    End Sub

    Private Sub NameTextBoxLeave(sender As Object, e As EventArgs) Handles NameTextBox.Leave
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler

    End Sub


    Function StringValidator() As Boolean
        Dim ti As TextInfo = CultureInfo.CurrentCulture.TextInfo
        If String.IsNullOrEmpty(NameTextBox.Text) Or String.IsNullOrEmpty(AddressTextBox.Text) Or
                String.IsNullOrEmpty(CityTextBox.Text) Or
                String.IsNullOrEmpty(StateTextBox.Text) Or
                String.IsNullOrEmpty(ZipCodeTextBox.Text) Then
            Return False

        ElseIf ValidName() = True And ValidState() = True Then
            ti.ToTitleCase(AddressTextBox.Text)
            ti.ToTitleCase(CityTextBox.Text)
            NameTextBox.Text = UCase(NameTextBox.Text)
            Return True
        Else
            Return False
        End If
    End Function

    Function ValidName() As Boolean
        Dim nameIsLetters As Boolean
        nameIsLetters = System.Text.RegularExpressions.Regex.IsMatch(NameTextBox.Text, "^[A-Za-z]+$")
        Return nameIsLetters
    End Function

    Sub ReadStates()
        Dim stateRecord As String
        Dim temp As String
        Try
            FileOpen(1, "States_All.txt", OpenMode.Input)
            Do Until EOF(1)
                Input(1, stateRecord)

                Me.allStates.Add(stateRecord)
            Loop
        Catch ex As Exception

        End Try
        FileClose(1)
    End Sub

    Function ValidState() As Boolean
        For Each record In Me.allStates
            If record = UCase(StateTextBox.Text) Then
                StateTextBox.Text = UCase(StateTextBox.Text)
                Return True
            Else

            End If
        Next
        Return False
    End Function

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
