Option Strict Off
Option Explicit On
Module modPNRItinerary

    Public Function myCurr(ByVal StringToParse As String) As Decimal

        Dim i As Integer
        Dim pintPoint As Short
        Dim pintComma As Short

        Do While Not IsNumeric(Right(StringToParse, 1)) And Len(StringToParse) > 0
            StringToParse = Left(StringToParse, Len(StringToParse) - 1)
        Loop
        StringToParse = Trim(StringToParse)
        pintPoint = InStr(StringToParse, My.Application.Culture.NumberFormat.CurrencyGroupSeparator)
        pintComma = InStr(StringToParse, My.Application.Culture.NumberFormat.CurrencyDecimalSeparator)
        If pintPoint > pintComma Then
            If Len(StringToParse) > 2 Then
                If Mid(StringToParse, Len(StringToParse) - 2, 1) = My.Application.Culture.NumberFormat.CurrencyGroupSeparator Then
                    Mid(StringToParse, Len(StringToParse) - 2, 1) = My.Application.Culture.NumberFormat.CurrencyDecimalSeparator
                End If
            End If
        End If

        If IsDBNull(StringToParse) Then
            StringToParse = ""
        End If
        If IsNumeric(StringToParse) Then
            myCurr = CDec(StringToParse)
        Else
            myCurr = 0
            For i = 1 To Len(StringToParse)
                If IsNumeric(Mid(StringToParse, 1, i)) Then
                    myCurr = CDec(Mid(StringToParse, 1, i))
                Else
                    Exit For
                End If
            Next i
        End If

    End Function

    Public ReadOnly Property ConnectionStringPNR() As String
        Get
            ConnectionStringPNR = "Data Source=" & My.Settings.DataSourcePNR & _
                                  ";Initial Catalog=" & My.Settings.DataCatalogPNR & _
                                  ";Persist Security Info=True" & _
                                  ";User ID=" & My.Settings.DataUserNamePNR & _
                                  ";Password=" & My.Settings.DataUserPasswordPNR
        End Get
    End Property

End Module