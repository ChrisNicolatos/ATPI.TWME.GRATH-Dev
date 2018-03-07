Option Strict Off
Option Explicit On
Namespace GDSPax
    Friend Class GDSPaxitem
        Private Structure ClassProps
            Dim ElementNo As Short
            Dim Initial As String
            Dim LastName As String
            Dim PaxID As String
            Dim IDNo As String
            Dim Department As String
            Dim Nationality As String
        End Structure

        Private mudtProps As ClassProps

        Public ReadOnly Property ElementNo() As Short
            Get
                ElementNo = mudtProps.ElementNo
            End Get
        End Property
        Public ReadOnly Property Initial() As String
            Get
                Initial = Trim(mudtProps.Initial)
            End Get
        End Property
        Public ReadOnly Property LastName() As String
            Get
                LastName = Trim(mudtProps.LastName)
            End Get
        End Property
        Public ReadOnly Property PaxID() As String
            Get
                PaxID = Trim(mudtProps.PaxID)
            End Get
        End Property
        Public ReadOnly Property PaxName() As String
            Get
                PaxName = LastName & "/" & Initial
            End Get
        End Property
        Public ReadOnly Property IdNo As String
            Get
                IdNo = mudtProps.IDNo
            End Get
        End Property
        Public ReadOnly Property Department As String
            Get
                Department = mudtProps.Department
            End Get
        End Property
        Public ReadOnly Property Nationality
            Get
                Nationality = mudtProps.Nationality
            End Get
        End Property
        Friend Sub SetValues(ByRef pElementNo As Short, ByRef pInitial As String, ByRef pLastName As String, ByRef pID As String)

            With mudtProps
                .ElementNo = pElementNo
                .Initial = pInitial
                .LastName = pLastName
                .PaxID = pID
                If pID.StartsWith("(") Then
                    Dim pSplit() As String = pID.Replace("(", "").Replace(")", "").Split({","}, StringSplitOptions.RemoveEmptyEntries)
                    If pSplit.GetUpperBound(0) >= 2 Then
                        .Nationality = pSplit(2)
                    End If
                    If pSplit.GetUpperBound(0) >= 1 Then
                        .Department = pSplit(1)
                    End If
                    If pSplit.GetUpperBound(0) >= 0 Then
                        .IDNo = pSplit(0).Replace("ID", "").Trim
                    End If
                End If
            End With

        End Sub
    End Class
    Friend Class GDSPaxColl
        Inherits Collections.Generic.Dictionary(Of String, GDSPaxitem)

        Friend Sub AddItem(ByVal pElementNo As Short, ByVal pInitial As String, ByVal pLastName As String, ByVal pID As String)

            Dim pobjClass As GDSPaxitem

            pobjClass = New GDSPaxitem

            pobjClass.SetValues(pElementNo, pInitial, pLastName, pID)
            MyBase.Add(Format(pElementNo), pobjClass)


        End Sub
    End Class
End Namespace
