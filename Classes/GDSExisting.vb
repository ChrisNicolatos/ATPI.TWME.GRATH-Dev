Option Strict Off
Option Explicit On
Namespace GDSExisting
    Public Class Item
        Private Structure ExistingItemClass

            Dim Exists As Boolean
            Dim LineNumber As Integer
            Dim RawText As String
            Dim Key As String

            Friend Sub Clear()
                Exists = False
                LineNumber = 0
                RawText = ""
                Key = ""
            End Sub

        End Structure
        Private mudtProps As ExistingItemClass

        Public ReadOnly Property Exists As Boolean
            Get
                Exists = mudtProps.Exists
            End Get
        End Property

        Public ReadOnly Property LineNumber As Integer
            Get
                LineNumber = mudtProps.LineNumber
            End Get
        End Property
        Public ReadOnly Property RawText As String
            Get
                RawText = mudtProps.RawText
            End Get
        End Property
        Public ReadOnly Property Key As String
            Get
                Key = mudtProps.Key
            End Get
        End Property
        Public Sub SetValues(ByVal pExists As Boolean, ByVal pLineNumber As Integer, ByVal pRawText As String, ByVal pKey As String)
            With mudtProps
                .Exists = pExists
                .LineNumber = pLineNumber
                .RawText = pRawText
                .Key = pKey
            End With
        End Sub
        Friend Sub Clear()
            mudtProps.Clear()
        End Sub
    End Class

    Public Class Collection
        Private mobjOpenSegment As New Item
        Private mobjPhoneElement As New Item
        Private mobjAgentElement As New Item
        Private mobjEmailElement As New Item
        Private mobjTicketElement As New Item
        Private mobjOptionQueueElement As New Item
        Private mobjAOH As New Item
        Private mobjAgentID As New Item
        Private mobjSavingsElement As New Item
        Private mobjLossElement As New Item

        Private mobjCustomerCode As New Item
        Private mobjCustomerName As New Item
        Private mobjSubDepartmentCode As New Item
        Private mobjSubDepartmentName As New Item
        Private mobjCRMCode As New Item
        Private mobjCRMName As New Item
        Private mobjVesselName As New Item
        Private mobjVesselFlag As New Item
        Private mobjVesselOSI As New Item
        Private mobjReference As New Item
        Private mobjBookedBy As New Item
        Private mobjDepartment As New Item
        Private mobjReasonForTravel As New Item
        Private mobjCostCentre As New Item

        Public ReadOnly Property OpenSegment As Item
            Get
                OpenSegment = mobjOpenSegment
            End Get
        End Property
        Public ReadOnly Property PhoneElement As Item
            Get
                PhoneElement = mobjPhoneElement
            End Get
        End Property
        Public ReadOnly Property AgentElement As Item
            Get
                AgentElement = mobjAgentElement
            End Get
        End Property
        Public ReadOnly Property EmailElement As Item
            Get
                EmailElement = mobjEmailElement
            End Get
        End Property
        Public ReadOnly Property TicketElement As Item
            Get
                TicketElement = mobjTicketElement
            End Get
        End Property
        Public ReadOnly Property OptionQueueElement As Item
            Get
                OptionQueueElement = mobjOptionQueueElement
            End Get
        End Property
        Public ReadOnly Property AOH As Item
            Get
                AOH = mobjAOH
            End Get
        End Property
        Public ReadOnly Property AgentID As Item
            Get
                AgentID = mobjAgentID
            End Get
        End Property
        Public ReadOnly Property SavingsElement As Item
            Get
                SavingsElement = mobjSavingsElement
            End Get
        End Property
        Public ReadOnly Property LossElement As Item
            Get
                LossElement = mobjLossElement
            End Get
        End Property

        Public ReadOnly Property CustomerCode As Item
            Get
                CustomerCode = mobjCustomerCode
            End Get
        End Property
        Public ReadOnly Property CustomerName As Item
            Get
                CustomerName = mobjCustomerName
            End Get
        End Property
        Public ReadOnly Property SubDepartmentCode As Item
            Get
                SubDepartmentCode = mobjSubDepartmentCode
            End Get
        End Property
        Public ReadOnly Property SubDepartmentName As Item
            Get
                SubDepartmentName = mobjSubDepartmentName
            End Get
        End Property
        Public ReadOnly Property CRMCode As Item
            Get
                CRMCode = mobjCRMCode
            End Get
        End Property
        Public ReadOnly Property CRMName As Item
            Get
                CRMName = mobjCRMName
            End Get
        End Property
        Public ReadOnly Property VesselName As Item
            Get
                VesselName = mobjVesselName
            End Get
        End Property
        Public ReadOnly Property VesselFlag As Item
            Get
                VesselFlag = mobjVesselFlag
            End Get
        End Property
        Public ReadOnly Property VesselOSI As Item
            Get
                VesselOSI = mobjVesselOSI
            End Get
        End Property
        Public ReadOnly Property Reference As Item
            Get
                Reference = mobjReference
            End Get
        End Property
        Public ReadOnly Property BookedBy As Item
            Get
                BookedBy = mobjBookedBy
            End Get
        End Property
        Public ReadOnly Property Department As Item
            Get
                Department = mobjDepartment
            End Get
        End Property
        Public ReadOnly Property ReasonForTravel As Item
            Get
                ReasonForTravel = mobjReasonForTravel
            End Get
        End Property
        Public ReadOnly Property CostCentre As Item
            Get
                CostCentre = mobjCostCentre
            End Get
        End Property
        Public Sub Clear()
            mobjOpenSegment.Clear()
            mobjPhoneElement.Clear()
            mobjAgentElement.Clear()
            mobjEmailElement.Clear()
            mobjTicketElement.Clear()
            mobjOptionQueueElement.Clear()
            mobjAOH.Clear()
            mobjAgentID.Clear()
            mobjSavingsElement.Clear()
            mobjLossElement.Clear()

            mobjCustomerCode.Clear()
            mobjCustomerName.Clear()
            mobjSubDepartmentCode.Clear()
            mobjSubDepartmentName.Clear()
            mobjCRMCode.Clear()
            mobjCRMName.Clear()
            mobjVesselName.Clear()
            mobjVesselFlag.Clear()
            mobjVesselOSI.Clear()
            mobjReference.Clear()
            mobjBookedBy.Clear()
            mobjDepartment.Clear()
            mobjReasonForTravel.Clear()
            mobjCostCentre.Clear()
        End Sub

    End Class

End Namespace
