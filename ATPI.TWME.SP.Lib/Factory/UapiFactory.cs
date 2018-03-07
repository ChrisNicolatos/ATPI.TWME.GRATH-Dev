using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ATPI.TWME.SP.Lib.AirService;
using ATPI.TWME.SP.Lib.URService;
using ATPI.TWME.SP.Lib.Model;

namespace ATPI.TWME.SP.Lib.Factory
{
    #region Using

    

    #endregion

    /// <summary>
    /// UAPI Factory class
    /// </summary>
    public class UapiFactory
    {
        #region Private Methods
        
        /// <summary>
        /// Get Universal Record
        /// </summary>
        /// <returns></returns>
        /// 
        private AvailabilitySearchRsp GetAirAvailability()
        {
            AvailabilitySearchRsp response = null;

            

            string someTraceId = "doesntmatter-8176";
            string originApp = "UAPI";

            AvailabilitySearchReq req = new AvailabilitySearchReq();
                   
            req.TraceId = someTraceId;
            req.AuthorizedBy = "user";
            req.TargetBranch = "P7001182";
            req.RetrieveProviderReservationDetails = true;

            ATPI.TWME.SP.Lib.AirService.BillingPointOfSaleInfo billSetInfo = new ATPI.TWME.SP.Lib.AirService.BillingPointOfSaleInfo();
            billSetInfo.OriginApplication = originApp;

            Airport org = new Airport() { Code = "SYD" };
            Airport dest = new Airport() { Code = "MEL" };

            SearchAirLeg leg = new SearchAirLeg();


            AddDepartureDate(leg, daysInFuture(1));

            List<typeSearchLocation> locs = new List<typeSearchLocation>();
            locs.Add(new typeSearchLocation() { Item = org });

            leg.SearchOrigin = locs.ToArray();

            List<typeSearchLocation> locs1 = new List<typeSearchLocation>();
            locs1.Add(new typeSearchLocation() { Item = dest });

            leg.SearchDestination = locs1.ToArray();
            
            
            req.BillingPointOfSaleInfo = billSetInfo;

            req.Items = new object[1] { leg};

            var mod  = new AirSearchModifiers();
            mod.PreferredProviders = new List<ATPI.TWME.SP.Lib.AirService.Provider>() { new ATPI.TWME.SP.Lib.AirService.Provider() { Code = "1G"} }.ToArray();

            req.AirSearchModifiers = mod;


            try
            {
                BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);

                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                string uri = "https://americas.universal-api.pp.travelport.com/B2BGateway/connect/uAPI/AirService";
                EndpointAddress endpointAddress = new EndpointAddress(uri);

                AirAvailabilitySearchPortTypeClient client = new AirAvailabilitySearchPortTypeClient(binding, endpointAddress);
                if (client.ClientCredentials != null)
                {
                    client.ClientCredentials.UserName.UserName = "Universal API/uAPI2743556899-8c0c3e98";
                    client.ClientCredentials.UserName.Password = "n*8G9E}em4";
                }

                response = client.service(null, req);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        // return a date that is n days in future
        public static String daysInFuture(int n)
        {
            DateTime now = DateTime.Now, future;
            future = now.AddDays(n);
            return string.Format("{0:yyyy-MM-dd}", future);
        }

        public static void AddDepartureDate(SearchAirLeg outbound, String departureDate)
        {
            // flexible time spec is flexible in that it allows you to say
            // days before or days after
            typeFlexibleTimeSpec noFlex = new typeFlexibleTimeSpec();
            noFlex.PreferredTime = departureDate;

            List<typeFlexibleTimeSpec> flexList = new List<typeFlexibleTimeSpec>();
            flexList.Add(noFlex);
            outbound.Items = flexList.ToArray();

        }


        private UniversalRecordRetrieveRsp GetUniversalRecord()
        {
            var res = GetAirAvailability();

            UniversalRecordRetrieveRsp response = null;

            string someTraceId = "doesntmatter-8176";
            string originApp = "UAPI";

            UniversalRecordRetrieveReq req = new UniversalRecordRetrieveReq();
            req.TraceId = someTraceId;
            req.AuthorizedBy = "user";
            req.TargetBranch = "P7001182";
            req.RetrieveProviderReservationDetails = true;

            ATPI.TWME.SP.Lib.URService.BillingPointOfSaleInfo billSetInfo = new ATPI.TWME.SP.Lib.URService.BillingPointOfSaleInfo();
            billSetInfo.OriginApplication = originApp;

            UniversalRecordRetrieveReqProviderReservationInfo prov = new UniversalRecordRetrieveReqProviderReservationInfo();
            prov.ProviderCode = "1G";
            prov.ProviderLocatorCode = "7BC4N4";
            //prov.ProviderLocatorCode = "C3829K";

            req.BillingPointOfSaleInfo = billSetInfo;
            req.Item = prov;


            try
            {
                BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);

                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                string uri = "https://americas.universal-api.pp.travelport.com/B2BGateway/connect/uAPI/UniversalRecordService";
                EndpointAddress endpointAddress = new EndpointAddress(uri);

                UniversalRecordRetrieveServicePortTypeClient client = new UniversalRecordRetrieveServicePortTypeClient(binding, endpointAddress);
                if (client.ClientCredentials != null)
                {
                    client.ClientCredentials.UserName.UserName = "Universal API/uAPI2743556899-8c0c3e98";
                    client.ClientCredentials.UserName.Password = "n*8G9E}em4";
                }

                response = client.service(null, null, req);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets DFO booking
        /// </summary>
        /// <returns></returns>
        public DFOBooking GetDFOBooking()
        {
            var dfoBooking = new DFOBooking();
            var bf = GetUniversalRecord();

            if (bf != null && bf.UniversalRecord!=null && bf.UniversalRecord.BookingTraveler!=null 
                && bf.UniversalRecord.BookingTraveler.Any() && bf.UniversalRecord.ProviderReservationInfo!=null && bf.UniversalRecord.ProviderReservationInfo.Any())
            {
                dfoBooking.RecordLocator = bf.UniversalRecord.ProviderReservationInfo[0].LocatorCode;
                dfoBooking.PaxLastName = bf.UniversalRecord.BookingTraveler[0].BookingTravelerName.Last;
                dfoBooking.PaxFirstName = bf.UniversalRecord.BookingTraveler[0].BookingTravelerName.First;
            }

            return dfoBooking;
        }
        
        #endregion
    }
}
