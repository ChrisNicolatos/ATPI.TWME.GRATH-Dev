Option Strict Off
Option Explicit On
Public Class GreekToLatin

    Private Const Greek As String = "αβγδεζηθικλμνξοπρστυφχψωάέήίόύώϊϋΐΰΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩΆΈΉΊΌΎΏΪΫ"
    Private Const GreekAccents As String = "άέήίόύώϊϋΐΰΆΈΉΊΌΎΏΪΫ"
    Private Const Latin As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Private Const GreekForY As String = "βγδζλμνραεηιουωάέήίόύώϊϋΐΰΒΓΔΖΛΜΝΡΑΕΗΙΟΥΩΆΈΉΊΌΎΏΪΫ"

    Public Function Convert(ByVal Source As String) As String

        ' Aντιστοιχία γραμμάτων Ελληνικής και Λατινικής γραφής
        '
        ' Ελλ - Λατ
        ' =========
        '
        ' Α --> Α
        ' Β --> V
        ' Γ --> G
        ' Δ --> D
        ' Ε --> E
        ' Ζ --> Z
        ' Η --> I
        ' Θ --> TH
        ' Ι --> I
        ' K --> K
        ' Λ --> L
        ' Μ --> M
        ' Ν --> N
        ' Ξ --> X
        ' Ο --> O
        ' Π --> P
        ' Ρ --> R
        ' Σ --> S
        ' Τ --> Τ
        ' Υ --> Y
        ' Φ --> F
        ' Χ --> CH
        ' Ψ --> PS
        ' Ω --> O
        '
        ' Δίφθογγοι
        ' ------------
        ' Ελλ -Λατ
        ' =======
        '
        ' AI --> AI
        ' AY --> AV (*), AF (**)
        ' OI --> OI
        ' OY --> OU
        ' EI --> EI
        ' EY --> EV (*), EF (**)
        '
        ' Διπλά
        ' -------
        ' Ελλ -Λατ
        ' =======
        '
        ' ΜΠ --> B (στην αρχή ή στο τέλος)
        ' ΜΠ --> MP (ενδιάμεσα)
        ' ΝΤ --> NT
        ' ΤΣ --> TS
        ' ΤZ --> TZ
        ' ΓΓ --> NG
        ' ΓΚ --> GK
        ' ΗΥ --> IY (*), IF (**)
        '
        ' (*) πριν από Β, Γ, Δ, Ζ, Λ, Μ, Ν, Ρ και τα φωνήεντα
        ' (**) πριν από Θ, Κ, Ξ, Π, Σ, Τ, Φ, Χ, Ψ και στο τέλος λέξης.
        '

        Dim pstrResult As String = Source.ToUpper.Trim

        If pstrResult.Contains("ΜΠ") Then
            pstrResult = ReplaceMP(pstrResult)
        End If

        If pstrResult.Contains("ΑΥ") Or pstrResult.Contains("ΑΎ") Then
            pstrResult = ReplacexY(pstrResult, "Α", "A")
        End If
        If pstrResult.Contains("ΕΥ") Or pstrResult.Contains("ΕΎ") Then
            pstrResult = ReplacexY(pstrResult, "Ε", "E")
        End If
        If pstrResult.Contains("ΗΥ") Or pstrResult.Contains("ΗΎ") Then
            pstrResult = ReplacexY(pstrResult, "Η", "I")
        End If

        pstrResult = pstrResult.Replace("ΓΚ", "GK")
        pstrResult = pstrResult.Replace("ΓΓ", "NG")

        pstrResult = pstrResult.Replace("ΟΥ", "OU")
        pstrResult = pstrResult.Replace("ΟΎ", "OU")

        pstrResult = pstrResult.Replace("Θ", "TH")
        pstrResult = pstrResult.Replace("Χ", "CH")
        pstrResult = pstrResult.Replace("Ψ", "PS")

        pstrResult = pstrResult.Replace("Α", "A")
        pstrResult = pstrResult.Replace("Β", "V")
        pstrResult = pstrResult.Replace("Γ", "G")
        pstrResult = pstrResult.Replace("Δ", "D")
        pstrResult = pstrResult.Replace("Ε", "E")
        pstrResult = pstrResult.Replace("Ζ", "Z")
        pstrResult = pstrResult.Replace("Η", "Ι")
        pstrResult = pstrResult.Replace("Ι", "I")
        pstrResult = pstrResult.Replace("Κ", "K")
        pstrResult = pstrResult.Replace("Λ", "L")
        pstrResult = pstrResult.Replace("Μ", "M")
        pstrResult = pstrResult.Replace("Ν", "N")
        pstrResult = pstrResult.Replace("Ξ", "X")
        pstrResult = pstrResult.Replace("Ο", "O")
        pstrResult = pstrResult.Replace("Π", "P")
        pstrResult = pstrResult.Replace("Ρ", "R")
        pstrResult = pstrResult.Replace("Σ", "S")
        pstrResult = pstrResult.Replace("Τ", "T")
        pstrResult = pstrResult.Replace("Υ", "Y")
        pstrResult = pstrResult.Replace("Φ", "F")
        pstrResult = pstrResult.Replace("Ω", "O")
        pstrResult = pstrResult.Replace("Ά", "A")
        pstrResult = pstrResult.Replace("Έ", "E")
        pstrResult = pstrResult.Replace("Ή", "I")
        pstrResult = pstrResult.Replace("Ί", "I")
        pstrResult = pstrResult.Replace("Ό", "O")
        pstrResult = pstrResult.Replace("Ύ", "Y")
        pstrResult = pstrResult.Replace("Ώ", "O")
        pstrResult = pstrResult.Replace("Ϊ", "I")
        pstrResult = pstrResult.Replace("Ϋ", "U")

        Convert = pstrResult

    End Function

    Private Function ReplaceMP(ByVal Text As String) As String

        Dim pstrResult As String
        Dim i As Integer

        Dim pstrFound As String
        Dim pstrNew(1) As String

        pstrResult = Text

        pstrFound = "ΜΠ"
        pstrNew(0) = "B"
        pstrNew(1) = "MP"


        If pstrResult.StartsWith(pstrFound) Then
            pstrResult = pstrNew(0) & pstrResult.Substring(2)
        End If

        If pstrResult.LastIndexOf(pstrFound) = pstrResult.Length - 2 Then
            pstrResult = pstrResult.Substring(0, pstrResult.Length - 2) & pstrNew(0)
        End If

        i = pstrResult.IndexOf(pstrFound)
        Do While i >= 0
            If Greek.IndexOf(pstrResult.Substring(i - 1, 1)) > 0 And Greek.IndexOf(pstrResult.Substring(i + 1, 1)) > 0 Then
                pstrResult = pstrResult.Remove(i, 2)
                pstrResult = pstrResult.Insert(i, pstrNew(1))
            Else
                pstrResult = pstrResult.Remove(i, 2)
                pstrResult = pstrResult.Insert(i, pstrNew(0))
            End If
            i = pstrResult.IndexOf(pstrFound)
        Loop

        ReplaceMP = pstrResult

    End Function

    Function ReplacexY(ByVal Text As String, ByVal Diph As String, ByVal DiphLat As String)

        ' AY --> AV (*), AF (**)
        ' EY --> EV (*), EF (**)
        ' ΗΥ --> IY (*), IF (**)
        '
        ' (*) πριν από Β, Γ, Δ, Ζ, Λ, Μ, Ν, Ρ και τα φωνήεντα
        ' (**) πριν από Θ, Κ, Ξ, Π, Σ, Τ, Φ, Χ, Ψ και στο τέλος λέξης.
        '
        Dim pstrResult As String
        Dim i As Integer

        Dim pstrFound(1) As String
        Dim pstrNew(1) As String

        pstrResult = Text

        pstrFound(0) = Diph & "Υ"
        pstrFound(1) = Diph & "Ύ"
        pstrNew(0) = DiphLat & "V"
        pstrNew(1) = DiphLat & "F"

        For i = 0 To 1
            If pstrResult.LastIndexOf(pstrFound(i)) = pstrResult.Length - 2 Then
                pstrResult = pstrResult.Substring(0, pstrResult.Length - 2) & pstrNew(1)
                Exit For
            End If
        Next i

        For j = 0 To 1
            i = pstrResult.IndexOf(pstrFound(j))
            Do While i > 0
                If GreekForY.IndexOf(pstrResult.Substring(i + 2, 1)) > 0 Then
                    pstrResult = pstrResult.Remove(i, 2)
                    pstrResult = pstrResult.Insert(i, pstrNew(0))
                Else
                    pstrResult = pstrResult.Remove(i, 2)
                    pstrResult = pstrResult.Insert(i, pstrNew(1))
                End If
                i = pstrResult.IndexOf(pstrFound(j))
            Loop
        Next j

        ReplacexY = pstrResult

    End Function

End Class
