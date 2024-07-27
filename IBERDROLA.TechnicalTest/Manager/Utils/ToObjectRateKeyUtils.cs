using IBERDROLA.TechnicalTest.Domain.Utils;
using IBERDROLA.TechnicalTest.ExternalServices;
using IBERDROLA.TechnicalTest.ExternalServices.AvailabilityB2B.Common.Models;
using IBERDROLA.TechnicalTest.ExternalServices.AvailabilityB2B.Common.response;

namespace IBERDROLA.TechnicalTest.Manager.Utils
{
    internal static class ToObjectRateKeyUtils
    {
        /// <summary>
        ///  Convert RateIdentifier b2b to RateKey b2c
        /// </summary>
        /// <param name="rateIdentifier"></param>
        /// <returns>object ratekey</returns>
        internal static RateKey RateIdentifierToObjectRateKey(this string rateIdentifier)
        {
            return rateIdentifier.Base64Decode().DeserializeFromJsonString<RateKey>();
        }
        /// <summary>
        ///  Convert  RateKey b2c to RateIdentifier b2b     
        /// </summary>
        /// <param name="rateKey"></param>
        /// <returns>Object Rateidentifier </returns>
        internal static RateIdentifier ToObjectRateIdentifier(this string rateKey)
        {
            return rateKey.Base64Decode().DeserializeFromJsonString<RateIdentifier>();
        }

    }
}
