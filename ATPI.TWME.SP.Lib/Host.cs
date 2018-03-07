using ATPI.TWME.SP.Lib.Model;

namespace ATPI.TWME.SP.Lib
{
    #region Using

    using System;
    using Factory;
    using Travelport.TravelData;
    #endregion

    /// <summary>
    /// Main entry point of library
    /// </summary>
    public class Host
    {
        #region Private variables

        /// <summary>
        /// SDK factory
        /// </summary>
        private SmartpointSDKFactory SDKFactory = null;

        /// <summary>
        /// UAPI Factory
        /// </summary>
        private UapiFactory UniversalAPIFactory = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Factory type
        /// </summary>
        public FactoryType HostFactoryType { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public Host()
        {
            SDKFactory = new SmartpointSDKFactory();
            UniversalAPIFactory = new UapiFactory();
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Get DFO Booking
        /// </summary>
        /// <returns></returns>
        public DFOBooking GetBooking()
        {
            var booking = new DFOBooking();

            try
            {
                if(HostFactoryType == FactoryType.SmartpointSDK)
                {
                    booking =  SDKFactory.GetBooking();
                }
                else if (HostFactoryType == FactoryType.UAPI)
                {
                    booking = UniversalAPIFactory.GetDFOBooking();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return booking;
        }

        /// <summary>
        /// Get DFO Booking
        /// </summary>
        /// <returns></returns>
        public BookingFile GetBookingFile()
        {
            BookingFile booking = null;

            try
            {
                booking = SDKFactory.GetBookingFile();                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return booking;
        }


        public string SignOn(string userName, string password)
        {
            try
            {
                return SDKFactory.Authenticate(userName, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SendCommand(string cmd)
        {
            try
            {
                return SDKFactory.SendCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
