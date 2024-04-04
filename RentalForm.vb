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

    Private Sub AddressTextBoxLeave(sender As Object, e As EventArgs) Handles AddressTextBox.Leave
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub CityTextBoxLeave(sender As Object, e As EventArgs) Handles CityTextBox.Leave
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub StateTextBoxLeave(sender As Object, e As EventArgs) Handles StateTextBox.Leave
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub ZipTextBoxLeave(sender As Object, e As EventArgs) Handles ZipCodeTextBox.Leave
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

        ElseIf ValidName() = True And ValidState() = True And ValidZip() = True Then
            AddressTextBox.Text = ti.ToTitleCase(AddressTextBox.Text)
            CityTextBox.Text = ti.ToTitleCase(CityTextBox.Text)
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
        Dim ti As TextInfo = CultureInfo.CurrentCulture.TextInfo
        Dim stateIsLetters As Boolean
        stateIsLetters = System.Text.RegularExpressions.Regex.IsMatch(StateTextBox.Text, "^[A-Za-z]+$")
        If stateIsLetters = True Then
            For Each record In Me.allStates
                If record = ti.ToTitleCase(StateTextBox.Text) Then
                    StateTextBox.Text = ti.ToTitleCase(StateTextBox.Text)
                    Return True
                Else

                End If
            Next
        Else
            Return False
        End If
        Return False
    End Function

    Function ValidZip() As Boolean
        Dim zipAsNumber As Integer
        Try
            zipAsNumber = CInt(ZipCodeTextBox.Text)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    'TODO for Calculations
    '[] Daily charge is 15 dollars a day
    '[] Mileage Charge
    ' a. First 200 miles are free
    ' b. all miles between 201 to 500 are 12 cents per mile
    ' c. Miles greater than 500 are charged at 10 cents
    '[] All calculations must use miles
    ' a. Use the radio buttons to determine if the odometer value is in miles or kilometers
    ' b. 1 Km equals .62 Mi
    ' c. If readings are in kilometers convert them to miles for the output display and 
    'when performing calculations
    ' d. Do not make conversions until the calculate button is clicked
    '[] Use the check boxes for AAA Member and Senior Citizen
    ' a. AAA members recieve a 5% discount
    ' b. senior citizens get a 3% discount
    ' c. A person can recieve both discounts
    ' d. Do not take the discount until as calculation has been made




End Class
