Public Class VesselPicker

    Private Structure ClassProps
        Dim Name As String
        Dim Flag As String
    End Structure
    Private mudtProps As ClassProps
    Public Property Name As String
        Get
            Name = mudtProps.Name
        End Get
        Set(value As String)
            mudtProps.Name = value
        End Set
    End Property
    Public Property Flag As String
        Get
            Flag = mudtProps.Flag
        End Get
        Set(value As String)
            mudtProps.Flag = value
        End Set
    End Property
End Class
