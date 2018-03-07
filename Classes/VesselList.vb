Namespace VesselList

    Public Class Item

        Private Const TEXTREG As String = " REG "
        Private Structure ClassProps
            Dim Name As String
            Dim Flag As String
        End Structure
        Private mudtProps As ClassProps
        Public Overrides Function ToString() As String
            With mudtProps
                Return .Name + IIf(.Flag = "", "", TEXTREG & .Flag)
            End With
        End Function

        Public ReadOnly Property Name() As String
            Get
                Name = mudtProps.Name
            End Get
        End Property

        Public ReadOnly Property Flag() As String
            Get
                Flag = mudtProps.Flag
            End Get
        End Property

        Friend Sub SetValues(ByVal pName As String, ByVal pFlag As String)
            With mudtProps
                If pName.ToUpper.Contains(TEXTREG) Then
                    If pFlag.Trim = "" Then
                        pFlag = pName.Substring(pName.ToUpper.IndexOf(TEXTREG) + 6).Trim
                        pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TEXTREG)).Trim
                    Else
                        pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TEXTREG)).Trim
                    End If
                End If
                .Name = pName.Trim
                .Flag = pFlag.Trim
            End With
        End Sub

    End Class

    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of String, Item)
        Private mlngEntityID As Long

        Public Sub Load(ByVal pEntityID As Long)
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As Item

            mlngEntityID = pEntityID

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = " SELECT DISTINCT " & _
                               " RTRIM(LTRIM(Name)) AS Name " & _
                               " ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag " & _
                               " FROM [TravelForceCosmos].[dbo].[TFEntityDepartments] " & _
                               " WHERE InUse = 1 " & _
                               " AND RTRIM(LTRIM(Name)) <> '' AND EntityID = " & mlngEntityID & " " & _
                               " ORDER BY Name "
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pobjClass = New Item
                    pobjClass.SetValues(.Item("Name"), .Item("Flag"))
                    If pobjClass.ToString <> "" And Not MyBase.ContainsKey(pobjClass.ToString) Then
                        MyBase.Add(pobjClass.ToString, pobjClass)
                    End If
                Loop
                .Close()
            End With
            pobjConn.Close()
        End Sub
    End Class
End Namespace
