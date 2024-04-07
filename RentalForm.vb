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
    Dim summaryData As New List(Of String)

    Private Sub Loader(sender As Object, e As EventArgs) Handles Me.Load
        'Adds presets for when the project is loaded
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
        SummaryButton.Enabled = False
        ReadStates()

    End Sub

    Private Sub NameTextBoxLeave(sender As Object, e As EventArgs) Handles NameTextBox.Leave
        'Handles when the Name Box is left and validates if the trip data can be enabled
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub AddressTextBoxLeave(sender As Object, e As EventArgs) Handles AddressTextBox.Leave
        'Handles when the Address Box is left and validates if the trip data can be enabled
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub CityTextBoxLeave(sender As Object, e As EventArgs) Handles CityTextBox.Leave
        'Handles when the City Box is left and validates if the trip data can be enabled
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub StateTextBoxLeave(sender As Object, e As EventArgs) Handles StateTextBox.Leave
        'Handles when the State Box is left and validates if the trip data can be enabled
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub

    Private Sub ZipTextBoxLeave(sender As Object, e As EventArgs) Handles ZipCodeTextBox.Leave
        'Handles when the Zip Code Box is left and validates if the trip data can be enabled
        Dim enabler As Boolean
        enabler = StringValidator()
        CalculateButton.Enabled = enabler
        BeginOdometerTextBox.Enabled = enabler
        EndOdometerTextBox.Enabled = enabler
        DaysTextBox.Enabled = enabler
    End Sub


    Function StringValidator() As Boolean
        'Validates all the strings for the customer's data and reformats letter strings to title case
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
        'validates that the customer's name is only letters
        Dim nameIsLetters As Boolean
        nameIsLetters = System.Text.RegularExpressions.Regex.IsMatch(NameTextBox.Text, "^[A-Za-z]+$")
        Return nameIsLetters
    End Function

    Sub ReadStates()
        'Reads all the states from the file in the debug folder
        Dim stateRecord As String
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
        'Reads in the list of all 50 United States and compares to the customers input
        'this ensures customer may only put in a valid state
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
        'Validates that the zipcode is both an integer and only 5 numbers long
        Dim zipAsNumber As Integer
        Try
            zipAsNumber = CInt(ZipCodeTextBox.Text)
        Catch ex As Exception
            Return False
        End Try
        If Len(ZipCodeTextBox.Text) = 5 Then
            Return True
        Else
            MsgBox("Zip can only be 5 digits")
            Return False
        End If
    End Function

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click
        'Exits the form
        Me.Close()
    End Sub

    'TODO for Calculations
    '[*] Daily charge is 15 dollars a day
    '[*] Mileage Charge
    ' a. First 200 miles are free
    ' b. all miles between 201 to 500 are 12 cents per mile
    ' c. Miles greater than 500 are charged at 10 cents
    '[*] All calculations must use miles
    ' a. Use the radio buttons to determine if the odometer value is in miles or kilometers
    ' b. 1 Km equals .62 Mi
    ' c. If readings are in kilometers convert them to miles for the output display and 
    '    when performing calculations
    ' d. Do not make conversions until the calculate button is clicked
    '[*] Use the check boxes for AAA Member and Senior Citizen
    ' a. AAA members recieve a 5% discount
    ' b. senior citizens get a 3% discount
    ' c. A person can recieve both discounts
    ' d. Do not take the discount until as calculation has been made

    'run full spec test when the code is done

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        'Once the Calulate Button is pressed it diverts to the logic required to calculate the customers request.
        If AAAcheckbox.Checked = True Or Seniorcheckbox.Checked = True Then
            GimmeMyDiscount()
        Else
            TotalCostCalculate()
        End If

    End Sub
    Function TotalCostCalculate() As Double
        'Completes all calculations nessesary for the output and all money based outputs are deemed currency
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
            SummaryButton.Enabled = True
            BuildCustomerArray()
            SummaryRecords(False)
        Else
            MsgBox("Sorry but your trip information is invalid")
        End If
        Return totalCost
    End Function
    Function ValidTrip() As Boolean
        'This function determines if the customer's trip data is valid
        'Blanks are not accepted and the beginning odometer cannot be greater than the end odometer
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
            If startInt < 0 Then
                Return False
            ElseIf endInt < 0 Then
                Return False
            ElseIf startInt < endInt Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function KmtoMile(rangekm As String) As Integer
        'This converts the KM value of an odometer to Miles when the Check box is in KM
        Dim rangeInMiles As Integer
        rangeInMiles = CInt(CDbl(rangekm) * 0.62)
        Return rangeInMiles
    End Function

    Function MileageCalculator(startTrip As Integer, endTrip As Integer) As Double
        'This calculates the mileage cost based upon the rates specified in the TODO
        '200 is always subtracted to give the first 200 miles to the customer free every time.
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
        'Generates a discount to the original cost based upon the qualifications of the customer
        'Both can be selected and the two rates are added before calculation.
        Dim currentCost As Double
        Dim discountedCost As Double
        Dim costDiff As Double
        currentCost = TotalCostCalculate()
        If currentCost <= 0 Then

        ElseIf AAAcheckbox.Checked = True And Seniorcheckbox.Checked = True Then
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

    Function BuildCustomerArray() As Integer
        'Builds a list of the known Customers and compares to the current customer data
        'This ensures that the customer count does not represent repeating customers
        'The For loop compares all data saved and compares all customer data fields.
        Dim currentCustomer As String
        Dim knownCustomer() As String
        Dim newCustomer As Boolean = True
        currentCustomer = ($"{NameTextBox.Text},{AddressTextBox.Text},{CityTextBox.Text},{StateTextBox.Text},{ZipCodeTextBox.Text},")

        If summaryData IsNot Nothing And summaryData.Count = 0 Then
            summaryData.Add(currentCustomer)
            newCustomer = True
        Else
            For i = 0 To summaryData.Count - 1
                knownCustomer = Split(summaryData(i), ",")

                ' Next
                If knownCustomer(0) = CStr(NameTextBox.Text) And
                    knownCustomer(1) = CStr(AddressTextBox.Text) And
                    knownCustomer(2) = CStr(CityTextBox.Text) And
                    knownCustomer(3) = CStr(StateTextBox.Text) And
                    knownCustomer(4) = CStr(ZipCodeTextBox.Text) Then
                    newCustomer = False
                    Exit For
                Else

                End If
            Next

        End If
        If newCustomer = False Then

        Else
            summaryData.Add(currentCustomer)
        End If
        Return summaryData.Count - 1
    End Function

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        SummaryRecords(True)
        '  MsgBox($"{BuildCustomerArray()}")
    End Sub

    Sub SummaryRecords(display As Boolean)
        Static milesDriven As Integer
        Static totalCharges As Double
        milesDriven = CInt(BeginOdometerTextBox.Text) - CInt(EndOdometerTextBox.Text) + milesDriven
        totalCharges = TotalCostCalculate() + totalCharges
        If display = True Then
            MsgBox($"Total Customers:    {BuildCustomerArray()}
Total Miles Driven:    {milesDriven} mi
Total Charges:         {FormatCurrency(totalCharges)}")
        Else

        End If
    End Sub

End Class
