Option Strict Off
Option Explicit On
Namespace PriceLookup
    Public Class Item
        Private Structure ClassProps
            Dim Id As Integer
            Dim CustomerName As String
            Dim Airline As String
            Dim ClassOfService As String
            Dim TicketCount As Integer
            Dim AveragePrice As Decimal
            Dim CustomerNameNull As Boolean
            Dim AirlineNull As Boolean
            Dim ClassOfServiceNull As Boolean
        End Structure
        Private mudtProps As ClassProps
        Public ReadOnly Property Id As Integer
            Get
                Id = mudtProps.Id
            End Get
        End Property
        Public ReadOnly Property CustomerName As String
            Get
                CustomerName = mudtProps.CustomerName
            End Get
        End Property
        Public ReadOnly Property Airline As String
            Get
                Airline = mudtProps.Airline
            End Get
        End Property
        Public ReadOnly Property ClassOfService As String
            Get
                ClassOfService = mudtProps.ClassOfService
            End Get
        End Property
        Public ReadOnly Property CustomerNameNull As Boolean
            Get
                CustomerNameNull = mudtProps.CustomerNameNull
            End Get
        End Property
        Public ReadOnly Property AirlineNull As Boolean
            Get
                AirlineNull = mudtProps.AirlineNull
            End Get
        End Property
        Public ReadOnly Property ClassOfServiceNull As Boolean
            Get
                ClassOfServiceNull = mudtProps.ClassOfServiceNull
            End Get
        End Property
        Public ReadOnly Property TicketCount As Integer
            Get
                TicketCount = mudtProps.TicketCount
            End Get
        End Property
        Public ReadOnly Property AveragePrice As Decimal
            Get
                AveragePrice = mudtProps.AveragePrice
            End Get
        End Property
        Friend Sub SetValues(ByVal pId As Integer, ByVal pCustomerName As Object, ByVal pAirline As Object, ByVal pClassOfService As Object, ByVal pTicketCount As Object, ByVal pAveragePrice As Object)
            With mudtProps
                .Id = pId
                If IsDBNull(pCustomerName) Then
                    .CustomerNameNull = True
                    .CustomerName = ""
                Else
                    .CustomerNameNull = False
                    .CustomerName = pCustomerName
                End If
                If IsDBNull(pAirline) Then
                    .AirlineNull = True
                    .Airline = ""
                Else
                    .AirlineNull = False
                    .Airline = pAirline
                End If
                If IsDBNull(pClassOfService) Then
                    .ClassOfServiceNull = True
                    .ClassOfService = ""
                Else
                    .ClassOfServiceNull = False
                    .ClassOfService = pClassOfService
                End If
                If IsDBNull(pTicketCount) Then
                    .TicketCount = 0
                Else
                    .TicketCount = pTicketCount
                End If
                If IsDBNull(pAveragePrice) Then
                    .AveragePrice = 0
                Else
                    .AveragePrice = pAveragePrice
                End If
            End With
        End Sub
    End Class
    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of Integer, Item)

        Private mTicketCount As Integer
        Private mAveragePrice As Decimal

        Private mFromDate As Date
        Private mOrigin As String
        Private mDestination As String
        Private mValuesLoaded As Boolean = False

        Public Sub SetValues(ByVal pFromDate As Date, ByVal pItinerary As String)
            pItinerary = pItinerary.Trim
            If pItinerary.Length >= 6 Then
                mOrigin = pItinerary.Substring(0, 3)
                mDestination = pItinerary.Substring(pItinerary.IndexOf(" ") - 3, 3)
                mFromDate = pFromDate
                mValuesLoaded = True
            End If
        End Sub
        Public Function Load() As Boolean

            mTicketCount = 0
            mAveragePrice = 0
            Load = False

            If mValuesLoaded Then
                If mOrigin <> mDestination Then
                    Load(mFromDate, mOrigin, mDestination)
                    Load = True
                End If
            End If

        End Function

        Private Sub Load(ByVal FromDate As Date, ByVal Origin As String, ByVal Destination As String)

            If MySettings.PCCBackOffice = 1 Then

                Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
                Dim pobjComm As New SqlClient.SqlCommand
                Dim pobjReader As SqlClient.SqlDataReader
                Dim pobjClass As Item

                pobjConn.Open()
                pobjComm = pobjConn.CreateCommand

                With pobjComm
                    .CommandType = CommandType.Text
                    .CommandText = " SELECT TFEntities.Code + '/' + TFEntities.Name AS ClientName  " &
                                " 	  ,Airlines.IATACode AS Airline  " &
                                "       ,AirSegFrom.ActualClass AS Class  " &
                                "   	  ,COUNT(*) AS CountOfTkts  " &
                                " 	  ,AVG(-(  CTCost.FaceValue          + CTCost.FVVatAmount        + CTCost.FaceValueExtra  " &
                                "                + CTCost.FVXVatAmount       + CTCost.Taxes              + CTCost.TAXVatAmount  " &
                                " 			   + CTCost.TaxesExtra         + CTCost.TAXXVatAmount      + CTCost.DiscountAmount  " &
                                " 			   + CTCost.DISCVatAmount      + CTCost.CommissionAmount   + CTCost.COMVatAmount    " &
                                " 			   + CTCost.ServiceFeeAmount   + CTCost.SFVatAmount        + CTCost.ExtraChargeAmount1  " &
                                " 			   + CTCost.ExtraChargeAmount2 + CTCost.ExtraChargeAmount3 + CTCost.CancellationFeeAmount  " &
                                " 			   + CTCost.CFVatAmount   " &
                                " 		)) AS AverageCostPrice  " &
                                "   FROM CommercialTransactions  " &
                                "   LEFT JOIN CommercialTransactionValues CTV  " &
                                " 	LEFT JOIN TFEntities  " &
                                " 		ON CTV.CommercialEntityID = TFEntities.Id  " &
                                " 	ON CommercialTransactions.Id = CTV.CommercialTransactionID   " &
                                " 	   AND IsCost = 0  " &
                                "   LEFT JOIN AirTicketTransactions  " &
                                " 	LEFT JOIN AirSegments AirSegFrom  " &
                                " 		ON AirSegFrom.AirTicketTransactionID = AirTicketTransactions.Id   " &
                                " 		   AND OriginalPosition = (SELECT MIN(OriginalPosition) FROM AirSegments WHERE AirSegments.AirTicketTransactionID = AirTicketTransactions.Id)  " &
                                " 	LEFT JOIN AirSegments AirSegTo  " &
                                " 		On AirSegTo.AirTicketTransactionID = AirTicketTransactions.Id  " &
                                " 			AND AirSegTo.OriginalPosition = (SELECT MAX(OriginalPosition) FROM AirSegments WHERE AirSegments.AirTicketTransactionID = AirTicketTransactions.Id)  " &
                                " 	LEFT JOIN AirTickets  " &
                                " 		ON AirTicketTransactions.AirTicketID = AirTickets.Id  " &
                                " 	ON AirTicketTransactions.CommercialTransactionID = CommercialTransactions.Id  " &
                                "   LEFT JOIN Airports AirportFrom  " &
                                " 	ON AirSegFrom.FromAirportID = AirportFrom.Id  " &
                                "   LEFT JOIN Airports AirportTo  " &
                                " 	ON AirSegTo.ToAirportID = AirportTo.Id  " &
                                "   LEFT JOIN Airlines  " &
                                " 	ON AirSegFrom.CarrierAirlineID = Airlines.Id  " &
                                "   LEFT JOIN CommercialTransactionValues CTCost  " &
                                " 	ON CTCost.CommercialTransactionID = CTV.CommercialTransactionID   " &
                                " 			  AND CTCost.IsCost=1  " &
                                "   WHERE ComTransactionTypeID = 1                   " &
                                "         AND ActionTypeID = 335                     " &
                                " 		AND AirTickets.IssueDate  >= '" & Format(FromDate, "yyyy-MM-dd") & "'     " &
                                " 		AND AirportFrom.Abbreviation = '" & Origin & "'  " &
                                " 		AND AirportTo.Abbreviation   = '" & Destination & "'  " &
                                "  GROUP BY GROUPING SETS ( " &
                                " 						 (TFEntities.Code + '/' + TFEntities.Name) " &
                                " 						,(TFEntities.Code + '/' + TFEntities.Name, Airlines.IATACode) " &
                                " 						,(Airlines.IATACode ,AirSegFrom.ActualClass) " &
                                " 						,(Airlines.IATACode) " &
                                " 						,() " &
                                " 						)" &
                                "   ORDER BY TFEntities.Code + '/' + TFEntities.Name  " &
                                " 		   ,Airlines.IATACode  " &
                                " 		   ,AirSegFrom.ActualClass  "
                    pobjReader = .ExecuteReader
                End With

                Dim pId As Integer = 0
                mTicketCount = 0
                mAveragePrice = 0
                MyBase.Clear()

                With pobjReader
                    Do While .Read
                        pId = pId + 1
                        pobjClass = New Item
                        pobjClass.SetValues(pId, .Item("ClientName"), .Item("Airline"), .Item("Class"), .Item("CountOfTkts"), .Item("AverageCostPrice"))
                        MyBase.Add(pobjClass.Id, pobjClass)
                        If pobjClass.CustomerNameNull And pobjClass.AirlineNull And pobjClass.ClassOfServiceNull Then
                            mTicketCount = pobjClass.TicketCount
                            mAveragePrice = pobjClass.AveragePrice
                        End If
                    Loop
                    .Close()
                End With
                pobjConn.Close()

            End If

        End Sub
        Public ReadOnly Property TicketCount As Integer
            Get
                TicketCount = mTicketCount
            End Get
        End Property
        Public ReadOnly Property AveragePrice As Decimal
            Get
                AveragePrice = mAveragePrice
            End Get
        End Property
        Public ReadOnly Property Itinerary As String
            Get
                Itinerary = mOrigin & "-" & mDestination
            End Get
        End Property
        Public ReadOnly Property FromDate As Date
            Get
                FromDate = mFromDate
            End Get
        End Property
    End Class
End Namespace
