using ATPI.TWME.SP.Lib.Model;

namespace ATPI.TWME.SP.Lib.Factory
{
    #region Using 

    using System;

    using Travelport.TravelData;
    using Travelport.TravelData.Factory;
    using Travelport.HostAccess;
    #endregion

    /// <summary>
    /// Smartpoint SDK Factory
    /// </summary>
    public class SmartpointSDKFactory
    {
        #region Private Methods

        /// <summary>
        /// Get desktop factory
        /// </summary>
        /// <returns></returns>
        private GalileoDesktopFactory GetDesktopFactory()
        {
            var factory = new GalileoDesktopFactory("SPG720", "MYCONNECTION", false, true, "SMRT");
            return factory;
        }

        /// <summary>
        /// Get booking file via traveldata
        /// </summary>
        /// <returns></returns>
        public BookingFile GetBookingFile()
        {
            string config = HostAccess.Instance.ConfigFileName;
            string nm = HostAccess.Instance.GetDefaultConnection();

            BookingFile bookingFile = null;

            try
            {
                var factory = GetDesktopFactory();
                bookingFile = factory.RetrieveCurrentBookingFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bookingFile;
        }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Get DFO Booking object
        /// </summary>
        /// <returns></returns>
        public DFOBooking GetBooking()
        {
            var dfoBooking = new DFOBooking();
            var bf = GetBookingFile();

            if (bf != null && !bf.BookingFileContainsNoData && bf.Passengers!=null && bf.Passengers.Count > 0)
            {
                dfoBooking.RecordLocator = bf.RecordLocator;
                dfoBooking.PaxLastName = bf.Passengers[0].LastName;
                dfoBooking.PaxFirstName = bf.Passengers[0].FirstName;
            }


            

            return dfoBooking;
        }

        

        public string Authenticate(string userName, string password)
        {
            try
            {
                var factory = GetDesktopFactory();
                return factory.SignOn(userName, password);
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
                var factory = GetDesktopFactory();
                return string.Join(string.Empty, factory.SendTerminalCommand(cmd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
