'Owen Fujii
'RCET 2268
'Spring 2024
'Car Rental
'https://github.com/Masaharu41/CarRental.git


Option Explicit On
Option Strict On
Option Compare Binary

Imports System.Globalization
Imports System.Runtime.InteropServices
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
            NameTextBox.Text = ti.ToTitleCase(NameTextBox.Text)
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
    '[*] Daily charge is 15 dollars a day
    '[*] Mileage Charge
    ' a. First 200 miles are free
    ' b. all miles between 201 to 500 are 12 cents per mile
    ' c. Miles greater than 500 are charged at 10 cents
    '[8] All calculations must use miles
    ' a. Use the radio buttons to determine if the odometer value is in miles or kilometers
    ' b. 1 Km equals .62 Mi
    ' c. If readings are in kilometers convert them to miles for the output display and 
    '    when performing calculations
    ' d. Do not make conversions until the calculate button is clicked
    '[] Use the check boxes for AAA Member and Senior Citizen
    ' a. AAA members recieve a 5% discount
    ' b. senior citizens get a 3% discount
    ' c. A person can recieve both discounts
    ' d. Do not take the discount until as calculation has been made

    'run full spec test when the code is done

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        If AAAcheckbox.Checked = True Or Seniorcheckbox.Checked = True Then
            GimmeMyDiscount()
        Else
            TotalCostCalculate()
        End If
    End Sub
    Function TotalCostCalculate() As Double
        Dim milesBegin As Integer
        Dim milesEnd As Integer
        Dim mileageCost As Double
        Dim dayCost As Double
        Dim totalCost As Double = 0
        If ValidTrip() = True Then
            If KilometersradioButton.Checked = True Then
                milesBegin = KmtoMile(BeginOdometerTextBox.Text)
                milesEnd = KmtoMile(EndOdometerTextBox.Text)
                mileageCost = MileageCalculator(milesBegin, milesEnd)
                MileageChargeTextBox.Text = FormatCurrency(mileageCost)
                dayCost = CDbl(DaysTextBox.Text) * 15
                DayChargeTextBox.Text = FormatCurrency(dayCost)
                totalCost = dayCost + mileageCost
                TotalChargeTextBox.Text = FormatCurrency(totalCost)
            Else
                milesBegin = CInt(BeginOdometerTextBox.Text)
                milesEnd = CInt(EndOdometerTextBox.Text)
                mileageCost = MileageCalculator(milesBegin, milesEnd)
                MileageChargeTextBox.Text = FormatCurrency(mileageCost)
                dayCost = CDbl(DaysTextBox.Text) * 15
                DayChargeTextBox.Text = FormatCurrency(dayCost)
                totalCost = dayCost + mileageCost
                TotalChargeTextBox.Text = FormatCurrency(totalCost)
            End If
        Else
            MsgBox("Sorry but your trip information is invalid")
        End If
        Return totalCost
    End Function
    Function ValidTrip() As Boolean
        Dim startInt As Integer
        Dim endInt As Integer
        Dim dayInt As Integer
        If String.IsNullOrEmpty(BeginOdometerTextBox.Text) Or
                String.IsNullOrEmpty(EndOdometerTextBox.Text) Or
                String.IsNullOrEmpty(DaysTextBox.Text) Then
            Return False
        Else
            Try
                startInt = CInt(BeginOdometerTextBox.Text)
            Catch ex As Exception
                Return False
            End Try
            Try
                endInt = CInt(EndOdometerTextBox.Text)
            Catch ex As Exception
                Return False
            End Try
            Try
                dayInt = CInt(DaysTextBox.Text)
            Catch ex As Exception
                Return False
            End Try
            If startInt < endInt Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function KmtoMile(rangekm As String) As Integer
        Dim rangeInMiles As Integer
        rangeInMiles = CInt(CDbl(rangekm) * 0.62)
        Return rangeInMiles
    End Function

    Function MileageCalculator(startTrip As Integer, endTrip As Integer) As Double
        Dim mileageDiff As Integer
        Dim totalCost As Double
        TotalMilesTextBox.Text = CStr(endTrip - startTrip) & "mi"
        mileageDiff = endTrip - startTrip - 200
        If mileageDiff < 0 = True Then
            Return 0
        ElseIf 0 < mileageDiff = True And mileageDiff < 300 = True Then
            totalCost = Math.Round(CDbl(mileageDiff * 0.12), 2)
            Return totalCost
        Else
            totalCost = Math.Round(CDbl(mileageDiff * 0.1), 2)
            Return totalCost
        End If
    End Function

    Sub GimmeMyDiscount()
        Dim currentCost As Double
        Dim discountedCost As Double
        Dim costDiff As Double
        currentCost = TotalCostCalculate()
        If AAAcheckbox.Checked = True And Seniorcheckbox.Checked = True Then
            discountedCost = currentCost * 0.93
            costDiff = Math.Round(currentCost - discountedCost, 2)
            TotalDiscountTextBox.Text = FormatCurrency(costDiff)
            TotalChargeTextBox.Text = FormatCurrency(discountedCost)
        ElseIf Seniorcheckbox.Checked = True Then
            discountedCost = currentCost * 0.97
            costDiff = Math.Round(currentCost - discountedCost, 2)
            TotalDiscountTextBox.Text = FormatCurrency(costDiff)
            TotalChargeTextBox.Text = FormatCurrency(discountedCost)
        ElseIf AAAcheckbox.Checked = True Then
            discountedCost = currentCost * 0.95
            costDiff = Math.Round(currentCost - discountedCost, 2)
            TotalDiscountTextBox.Text = FormatCurrency(costDiff)
            TotalChargeTextBox.Text = FormatCurrency(discountedCost)
        End If
    End Sub
End Class
