Option Strict Off
Option Explicit On
Namespace Vessels

    Public Class Item
        Private Structure ClassProps
            Dim Name As String
            Dim Flag As String
        End Structure
        Private mudtProps As ClassProps
        Public Overrides Function ToString() As String
            With mudtProps
                Return .Name + IIf(.Flag = "", "", MySettings.GDSValue("TextREG") & .Flag)
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
                If pName.ToUpper.Contains(MySettings.GDSValue("TextREG")) Then
                    If pFlag.Trim = "" Then
                        pFlag = pName.Substring(pName.ToUpper.IndexOf(MySettings.GDSValue("TextREG")) + 6).Trim
                        pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(MySettings.GDSValue("TextREG"))).Trim
                    Else
                        pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(MySettings.GDSValue("TextREG"))).Trim
                    End If
                End If
                .Name = pName.Trim
                .Flag = pFlag.Trim
            End With
        End Sub

        Public Function Load(ByVal pCustCode As String, ByVal pVesselName As String) As Boolean
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = PrepareVesselSelectCommand(pCustCode, pVesselName)
                pobjReader = .ExecuteReader
            End With

            Load = False
            With pobjReader
                If .Read Then
                    SetValues(.Item("Name"), .Item("Flag"))
                    Load = True
                End If
                .Close()
            End With
            pobjConn.Close()
        End Function
        Private Function PrepareVesselSelectCommand(ByVal pCustCode As String, ByVal pVesselName As String)
            Select Case MySettings.PCCBackOffice
                Case 1
                    PrepareVesselSelectCommand = " SELECT DISTINCT " &
                                               " RTRIM(LTRIM(TFEntityDepartments.Name)) AS Name " &
                                               " ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag " &
                                               " FROM [TravelForceCosmos].[dbo].[TFEntityDepartments] " &
                                               " 		LEFT OUTER JOIN TravelForceCosmos.dbo.TFEntities  " &
                                               " 			ON TravelForceCosmos.dbo.TFEntityDepartments.EntityID = TravelForceCosmos.dbo.TFEntities.Id " &
                                               " WHERE InUse = 1  " &
                                               " AND (TravelForceCosmos.dbo.TFEntityDepartments.Name = '" & pVesselName & "') " &
                                               " AND (TravelForceCosmos.dbo.TFEntities.Code = '" & pCustCode & "') " &
                                               " ORDER BY Name "
                Case 2
                    PrepareVesselSelectCommand = "SELECT [Child_Value] AS Name " &
                                                " , '' AS Flag " &
                                                " FROM [Disco_Instone_EU].[dbo].[Costcen] " &
                                                " LEFT JOIN Company " &
                                                " ON Costcen.Account_Id=Company.Account_Id " &
                                                " WHERE Company.Account_Abbriviation = '" & pCustCode & "' AND Child_Name = 'CC1' AND Child_Value = '" & pVesselName & "' "

                Case Else
                    PrepareVesselSelectCommand = ""
            End Select
        End Function
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
                .CommandText = PrepareVesselSelectCommand(mlngEntityID)
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
        Private Function PrepareVesselSelectCommand(ByVal pEntityID As Integer) As String

            Select Case MySettings.PCCBackOffice
                Case 1
                    PrepareVesselSelectCommand = " SELECT DISTINCT " &
                               " RTRIM(LTRIM(Name)) AS Name " &
                               " ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag " &
                               " FROM [TravelForceCosmos].[dbo].[TFEntityDepartments] " &
                               " WHERE InUse = 1 " &
                               " AND RTRIM(LTRIM(Name)) <> '' AND EntityID = " & pEntityID & " " &
                               " ORDER BY Name "
                Case 2
                    PrepareVesselSelectCommand = " SELECT [Child_Value] AS Name " &
                                                 ",'' AS Flag " &
                                                 "  FROM [Disco_Instone_EU].[dbo].[Costcen] " &
                                                 "  WHERE Child_Name = 'CC1' AND CostCen.Account_id =  " & pEntityID
                Case Else
                    PrepareVesselSelectCommand = ""
            End Select

        End Function
    End Class

End Namespace
