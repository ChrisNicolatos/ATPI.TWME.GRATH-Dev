Option Strict Off
Option Explicit On
Imports System.Xml
Namespace CustomProperties
    Public Enum CustomPropertyIDValue As Integer
        BookedBy = 1
        Department = 2
        ReasonFortravel = 4
        CostCentre = 5
    End Enum
    Public Class Item
        Private Structure ClassProps
            Dim ID As Long
            Dim CustomPropertyID As CustomPropertyIDValue
            Dim LookUpValues As String
            Dim LimitToLookup As Boolean
            Dim Label As String
            Dim TFEntityID As Long
            Dim Values() As String
        End Structure
        Private mudtProps As ClassProps

        Public ReadOnly Property ID() As Long
            Get
                ID = mudtProps.ID
            End Get
        End Property

        Public ReadOnly Property CustomPropertyID() As CustomPropertyIDValue
            Get
                CustomPropertyID = mudtProps.CustomPropertyID
            End Get
        End Property

        Public ReadOnly Property LookUpValues() As string
            Get
                LookUpValues = mudtProps.LookUpValues
            End Get
        End Property

        Public ReadOnly Property LimitToLookup() As Boolean
            Get
                LimitToLookup = mudtProps.LimitToLookup
            End Get
        End Property

        Public ReadOnly Property Label() As string
            Get
                Label = mudtProps.Label
            End Get
        End Property

        Public ReadOnly Property TFEntityID() As Long
            Get
                TFEntityID = mudtProps.TFEntityID
            End Get
        End Property

        Public ReadOnly Property ValuesCount As Integer
            Get
                ValuesCount = mudtProps.Values.Length
            End Get
        End Property

        Public ReadOnly Property Value(ByVal Index As Integer) As string
            Get
                If Index >= 0 And Index <= mudtProps.Values.GetUpperBound(0) Then
                    Value = mudtProps.Values(Index)
                Else
                    Throw New Exception("Index out of bounds")
                End If
            End Get
        End Property

        Friend Sub SetValues(ByVal pID As Long, ByVal pCustomPropertyID As CustomPropertyIDValue, ByVal pLookUpValues As String, ByVal pLimitToLookup As Boolean, ByVal pLabel As String, ByVal pTFEntityID As Long)
            With mudtProps
                .ID = pID
                .CustomPropertyID = pCustomPropertyID
                .LookUpValues = pLookUpValues
                .LimitToLookup = pLimitToLookup
                .Label = pLabel
                .TFEntityID = pTFEntityID
                ReDim .Values(0)
                If .LimitToLookup Then
                    ReadXML(pCustomPropertyID, pTFEntityID)
                Else
                    ReadLookUpValues()
                End If
            End With
        End Sub

        Private Sub ReadXML(ByVal pCustomPropertyID As Long, ByVal pTfEntityID As Long)

            Dim pobjXMLValues As New XMLValues
            pobjXMLValues.ReadValues(pCustomPropertyID, pTfEntityID)
            mudtProps.Values = pobjXMLValues.ToArray

        End Sub

        Private Sub ReadLookUpValues()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = "SELECT [Value] " & _
                               " FROM [TravelForceCosmos].[dbo].[CustomPropertyValues] " & _
                               " WHERE CustomPropertyID = " & mudtProps.CustomPropertyID & " And TFEntityID = " & mudtProps.TFEntityID & _
                               " GROUP BY Value " & _
                               " ORDER BY Value"
                pobjReader = .ExecuteReader
            End With
            mudtProps.Values(0) = ""
            With pobjReader
                Dim iCount As Integer = 0
                Do While .Read
                    iCount += 1
                    ReDim Preserve mudtProps.Values(iCount - 1)
                    mudtProps.Values(iCount - 1) = .Item("Value")
                Loop
                .Close()
            End With
            pobjConn.Close()
        End Sub

    End Class

    Public Class XMLValues

        Inherits Collections.Generic.List(Of String)

        Private mstrID As String

        Public Sub ReadValues(ByVal pCustomPropertyID As Long, ByVal pTfEntityID As Long)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            MyBase.Clear()
            mstrID = ""

            If MySettings.PCCBackOffice = 1 Then

                Do While pTfEntityID <> 0 And mstrID.IndexOf("," & pTfEntityID & ",") < 0
                    With pobjComm
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT LookUpValues, ISNULL(RelatedEntityID, 0) AS RelatedEntityID " &
                                   " FROM [TravelForceCosmos].[dbo].[ClientCustomProperties] " &
                                   " LEFT JOIN TravelForceCosmos.dbo.TFEntities " &
                                   " 	ON TFEntityID=TFEntities.Id " &
                                   " WHERE CustomPropertyID = " & pCustomPropertyID & " And TFEntityID = " & pTfEntityID
                        pobjReader = .ExecuteReader
                    End With
                    With pobjReader
                        Do While .Read
                            ParseXML(.Item("LookUpValues"))
                            mstrID &= "," & pTfEntityID & ","
                            pTfEntityID = .Item("RelatedEntityID")
                        Loop
                    End With
                    pobjReader.Close()
                Loop
                MyBase.Sort()
            ElseIf MySettings.PCCBackOffice = 2 Then
                With pobjComm
                    .CommandType = CommandType.Text
                    Select Case pCustomPropertyID
                        Case 1 ' booked by
                            .CommandText = "SELECT [Child_Value] AS Name " &
                                           " From [Disco_Instone_EU].[dbo].[Costcen] " &
                                           "  LEFT JOIN Company " &
                                           "  ON Costcen.Account_Id=Company.Account_Id " &
                                           "  WHERE CostCen.Account_id = " & pTfEntityID & " AND Child_Name = 'BBY' " &
                                           " ORDER BY Child_Value"
                        Case 4 ' reason for travel
                            .CommandText = "SELECT [Child_Value] AS Name " &
                                          " From [Disco_Instone_EU].[dbo].[Costcen] " &
                                          "  LEFT JOIN Company " &
                                          "  ON Costcen.Account_Id=Company.Account_Id " &
                                          "  WHERE CostCen.Account_id = " & pTfEntityID & " AND Child_Name = 'REF2' " &
                                          " ORDER BY Child_Value"
                    End Select

                    pobjReader = .ExecuteReader
                End With
                With pobjReader
                    Do While .Read
                        If Not MyBase.Contains(.Item("Name")) Then
                            MyBase.Add(.Item("Name"))
                        End If
                    Loop
                End With
            End If

        End Sub
        Private Sub ParseXML(ByVal pXMLString As String)

            Try
                Dim xmlString As String = pXMLString
                Dim sr As New System.IO.StringReader(xmlString)
                Dim doc As New Xml.XmlDocument
                doc.Load(sr)
                'or just in this case doc.LoadXML(xmlString)
                Dim reader As New Xml.XmlNodeReader(doc)

                While reader.Read()
                    Select Case reader.NodeType
                        Case Xml.XmlNodeType.Element
                            If reader.Name = "CustomPropertyLookupValue" Then
                                'Dim pFound As Boolean = False
                                Dim pText As String = ""
                                pText = reader.GetAttribute("Value").ToUpper.Trim
                                If reader.GetAttribute("Description").ToUpper.Trim <> "" And reader.GetAttribute("Description").ToUpper.Trim <> pText Then
                                    If pText <> "" Then
                                        pText &= "/"
                                    End If
                                    pText &= reader.GetAttribute("Description").ToUpper.Trim
                                End If
                                If pText <> "" Then
                                    If Not MyBase.Contains(pText) Then
                                        MyBase.Add(pText)
                                    End If
                                End If
                            End If
                    End Select
                End While
            Catch ex As Exception

            End Try

        End Sub

    End Class
    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of String, Item)

        Private Const MyXMLString As String = "<?xml version='1.0' encoding='utf-8'?><LookUpValues xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><CustomPropertyLookupValue Description='Crew' Value='Crew' IsDefault='false' /><CustomPropertyLookupValue Description='Technical' Value='Technical' IsDefault='false' /><CustomPropertyLookupValue Description='Marine' Value='Marine' IsDefault='false' /><CustomPropertyLookupValue Description='HSQE' Value='HSQE' IsDefault='false' /><CustomPropertyLookupValue Description='Finance' Value='Finance' IsDefault='false' /></LookUpValues>"
        Private mflgBookedBy As Boolean
        Private mflgDepartment As Boolean
        Private mflgReasonForTravel As Boolean
        Private mflgCostCentre As Boolean

        Public Sub Load(ByVal pEntityID As Long)

            If MySettings.PCCBackOffice = 1 Then
                Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
                Dim pobjComm As New SqlClient.SqlCommand
                Dim pobjReader As SqlClient.SqlDataReader
                Dim pobjClass As Item

                pobjConn.Open()
                pobjComm = pobjConn.CreateCommand

                With pobjComm
                    .CommandType = CommandType.Text
                    .CommandText = " SELECT [Id] " &
                               "       ,[CustomPropertyID] " &
                               "       ,[LookUpValues] " &
                               "       ,[LimitToLookUp] " &
                               "       ,[Label] " &
                               "       ,[TFEntityID] " &
                               "   FROM [TravelForceCosmos].[dbo].[ClientCustomProperties] " &
                               "   WHERE TFEntityID = '" & pEntityID & "'   " &
                               "   AND IsDisabled = 0"

                    pobjReader = .ExecuteReader
                End With

                mflgBookedBy = False
                mflgDepartment = False
                mflgReasonForTravel = False
                mflgCostCentre = False

                With pobjReader
                    Do While .Read
                        pobjClass = New Item
                        pobjClass.SetValues(.Item("Id"), .Item("CustomPropertyID"), .Item("LookUpValues"), .Item("LimitToLookUp"), .Item("Label"), .Item("TFEntityID"))
                        MyBase.Add(pobjClass.ID, pobjClass)
                        If pobjClass.CustomPropertyID = CustomPropertyIDValue.BookedBy Then
                            mflgBookedBy = True
                        ElseIf pobjClass.CustomPropertyID = CustomPropertyIDValue.Department Then
                            mflgDepartment = True
                        ElseIf pobjClass.CustomPropertyID = CustomPropertyIDValue.ReasonFortravel Then
                            mflgReasonForTravel = True
                        ElseIf pobjClass.CustomPropertyID = CustomPropertyIDValue.CostCentre Then
                            mflgCostCentre = True
                        End If
                    Loop
                    .Close()
                End With
                pobjConn.Close()
            Else
                Dim pobjClass As Item
                pobjClass = New Item
                pobjClass.SetValues(1, CustomPropertyIDValue.BookedBy, "", True, "BookedBy", pEntityID)
                If pobjClass.ValuesCount > 0 Then
                    MyBase.Add(pobjClass.ID, pobjClass)
                    mflgBookedBy = True
                Else
                    mflgBookedBy = False
                End If
                pobjClass = New Item
                pobjClass.SetValues(2, CustomPropertyIDValue.ReasonFortravel, "", True, "ReasonFortravel", pEntityID)
                If pobjClass.ValuesCount > 0 Then
                    MyBase.Add(pobjClass.ID, pobjClass)
                    mflgReasonForTravel = True
                Else
                    mflgReasonForTravel = False
                End If

                mflgDepartment = False
                mflgCostCentre = False
            End If

        End Sub
        Public ReadOnly Property BookedBy As Boolean
            Get
                BookedBy = mflgBookedBy
            End Get
        End Property
        Public ReadOnly Property Department As Boolean
            Get
                Department = mflgDepartment
            End Get
        End Property
        Public ReadOnly Property ReasonForTravel As Boolean
            Get
                ReasonForTravel = mflgReasonForTravel
            End Get
        End Property
        Public ReadOnly Property CostCentre As Boolean
            Get
                CostCentre = mflgCostCentre
            End Get
        End Property

    End Class

    Public Class CostCentreLookupItem
        Private Structure ClassProps
            Dim Id As Integer
            Dim Code As String
            Dim OldCode As String
            Dim ClientName As String
            Dim ClientLogo As String
            Dim VesselName As String
            Dim CostCentre As String
        End Structure
        Dim mudtProps As ClassProps

        Friend Sub New(ByVal Id As Integer, ByVal Code As String, ByVal OldCode As String, ByVal ClientName As String, ByVal ClientLogo As String, ByVal VesselName As String, ByVal CostCentre As String)

            With mudtProps
                .Id = Id
                .Code = Code
                .OldCode = OldCode
                .ClientName = ClientName
                .ClientLogo = ClientLogo
                .VesselName = VesselName
                .CostCentre = CostCentre
            End With
        End Sub
        Public ReadOnly Property Id As Integer
            Get
                Id = mudtProps.Id
            End Get
        End Property
        Public ReadOnly Property Code As string
            Get
                Code = mudtProps.Code
            End Get
        End Property
        Public ReadOnly Property OldCode As string
            Get
                OldCode = mudtProps.OldCode
            End Get
        End Property
        Public ReadOnly Property ClientName As string
            Get
                ClientName = mudtProps.ClientName
            End Get
        End Property
        Public ReadOnly Property ClientLogo As string
            Get
                ClientLogo = mudtProps.ClientLogo
            End Get
        End Property
        Public ReadOnly Property VesselName As string
            Get
                VesselName = mudtProps.VesselName
            End Get
        End Property
        Public ReadOnly Property CostCentre As string
            Get
                CostCentre = mudtProps.CostCentre
            End Get
        End Property
    End Class

    Public Class CostCentreLookupCollection
        Inherits Collections.Generic.Dictionary(Of String, CostCentreLookupItem)

        Public Sub LoadCustomerGroup(ByVal CustomerGroup As Integer)
            Load(True, CustomerGroup)
        End Sub
        Public Sub LoadCustomer(ByVal CustomerID As Integer)
            Load(False, CustomerID)
        End Sub

        Private Sub Load(ByVal byGroup As Boolean, ByVal Id As Integer)

            If MySettings.PCCBackOffice = 1 Then

                Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
                Dim pobjComm As New SqlClient.SqlCommand
                Dim pobjReader As SqlClient.SqlDataReader
                Dim pobjClass As CostCentreLookupItem
                Dim pCommandText As String = ""

                pobjConn.Open()
                pobjComm = pobjConn.CreateCommand

                With pobjComm
                    .CommandType = CommandType.Text

                    pCommandText = "USE TravelForceCosmos   " &
                " If(OBJECT_ID('tempdb..#TempTable') Is Not Null)   " &
                " Begin       " &
                " Drop Table #TempTable   " &
                " End   " &
                " SELECT ClientCustomProperties.TFEntityID   " &
                " 		, CAST(REPLACE(REPLACE(ClientCustomProperties.LookUpValues, 'utf-8', 'utf-16'), ' xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & "', '') AS XML) AS LookUpValues   " &
                " 		, CAST(REPLACE(REPLACE(ClientCustomProperties.DependsOnLookUpValues, 'utf-8', 'utf-16'), ' xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & "', '') AS XML) AS DependsOnLookUpValues   " &
                " 		INTO #TempTable   " &
                " FROM ClientCustomProperties     " &
                " LEFT JOIN TFEntities ON TFEntityId = TFEntities.Id" &
                " WHERE CustomPropertyID=5 AND TFEntities.IsActive = 1  "
                    If byGroup Then
                        pCommandText &= " 		AND TFEntityID IN (SELECT TFEntityID FROM TravelForceCosmos.dbo.TFEntityTags WHERE TagID=" & Id & ") "
                    Else
                        pCommandText &= " 		AND TFEntityID =" & Id & " "
                    End If
                    pCommandText &= " If(OBJECT_ID('tempdb..#TempTable1') Is Not Null)   " &
                " Begin " &
                " Drop Table #TempTable1 " &
                " End " &
                " SELECT DISTINCT   #TempTable.TFEntityID " &
                " 				  ,CustomProperties.CustProps.value('../@MasterLookupValue[1]','VARCHAR(1000)') AS Vessel    " &
                " 				  ,CustomProperties.CustProps.value('.','VARCHAR(1000)') AS CostCentre   " &
                " 				  INTO #TempTable1    " &
                " FROM #TempTable       " &
                " CROSS APPLY DependsOnLookUpValues.nodes('/DependsOnValues/CustomPropertyDependsOnValue/DependentLookupValues')  CustomProperties(CustProps)   " &
                " LEFT JOIN TFEntities   ON TFEntities.Id = #TempTable.TFEntityID   " &
                " LEFT JOIN TFEntityDepartments ON TFEntityDepartments.EntityID = TFEntities.Id  " &
                " 								 AND CustomProperties.CustProps.value('../@MasterLookupValue[1]','VARCHAR(1000)') = TFEntityDepartments.Name  " &
                " 								 AND TFEntityDepartments.InUse=1 " &
                " ORDER BY  Vessel,CostCentre, TFEntityID      " &
                " SELECT DISTINCT   #TempTable.TFEntityID    " &
                " 				  , Code    " &
                " 				  , '' AS Remarks    " &
                " 				  , Name    " &
                " 				  , Logo    " &
                " 				  ,CustomProperties.CustProps.value('@Value[1]','VARCHAR(1000)') AS CostCentre    " &
                " 				  ,#TempTable1.Vessel AS ActualVessel   " &
                " FROM #TempTable       " &
                " CROSS APPLY LookUpValues.nodes('/LookUpValues/CustomPropertyLookupValue')  CustomProperties(CustProps)   " &
                " LEFT JOIN TFEntities   ON TFEntities.Id = #TempTable.TFEntityID   " &
                " LEFT JOIN #TempTable1  ON #TempTable.TFEntityID=#TempTable1.TFEntityID     " &
                "                           AND CustomProperties.CustProps.value('@Value[1]','VARCHAR(1000)') = #TempTable1.CostCentre   " &
                " WHERE #TempTable1.Vessel IS NOT NULL AND TFEntities.IsActive = 1     " &
                " UNION " &
                " SELECT DISTINCT TFEntities.Id " &
                " 				, TFEntities.Code " &
                " 				, '' AS Remarks " &
                " 				, TFEntities.Name " &
                " 				, TFEntities.Logo " &
                " 				, '' AS CostCentre " &
                " 				, TFEntityDepartments.Name AS ActualVessel " &
                " FROM TFEntities " &
                " LEFT JOIN TFEntityDepartments ON TFEntityDepartments.EntityID=TFEntities.Id  " &
                " 		  AND TFEntityDepartments.InUse=1 " &
                " 		  AND (SELECT COUNT(*) FROM #TempTable1 WHERE TFEntityDepartments.Name = #TempTable1.Vessel) = 0 " &
                " WHERE TFEntityDepartments.Name IS NOT NULL AND TFEntities.IsActive = 1 "
                    If byGroup Then
                        pCommandText &= " 		AND TFEntities.Id IN (SELECT TFEntityID FROM TravelForceCosmos.dbo.TFEntityTags WHERE TagID=" & Id & ") "
                    Else
                        pCommandText &= " 		AND TFEntities.Id =" & Id & " "
                    End If
                    pCommandText &= " ORDER BY   ActualVessel,CostCentre, Code    " &
                " If(OBJECT_ID('tempdb..#TempTable') Is Not Null)   " &
                " Begin       " &
                " Drop Table #TempTable   " &
                " End   " &
                " If(OBJECT_ID('tempdb..#TempTable1') Is Not Null)   " &
                " Begin       " &
                " Drop Table #TempTable1   " &
                " End  "


                    .CommandText = pCommandText
                    pobjReader = .ExecuteReader
                End With

                Dim pId As Integer = 0
                MyBase.Clear()
                With pobjReader
                    Do While .Read
                        pId = pId + 1
                        pobjClass = New CostCentreLookupItem(pId, .Item("Code"), .Item("Remarks"), .Item("Name"), .Item("Logo"), .Item("ActualVessel"), .Item("CostCentre"))
                        MyBase.Add(pobjClass.Id, pobjClass)
                    Loop
                    .Close()
                End With
                pobjConn.Close()
            End If

        End Sub
    End Class
End Namespace
