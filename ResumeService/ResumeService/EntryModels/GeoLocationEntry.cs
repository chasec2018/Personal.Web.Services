using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResumeService.EntryModels
{
    public class GeoLocationEntry
    {
        [JsonPropertyName("continent")]
        public string Continent { get; set; }

        [JsonPropertyName("address_format")]
        public string AddressFormat { get; set; }

        [JsonPropertyName("alpha2")]
        public string AlphaTwo { get; set; }

        [JsonPropertyName("alpha3")]
        public string AlphaThree { get; set; }
        
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("international_prefix")]
        public string InternationalPrefix { get; set; }

        [JsonPropertyName("ioc")]
        public string IOC { get; set; }

        [JsonPropertyName("gec")]
        public string GEC { get; set; }

        [JsonPropertyName("name")]
        public string CountryName { get; set; }

        [JsonPropertyName("national_prefix")]
        public string NationalPrefix { get; set; }

        [JsonPropertyName("number")]
        public string NationalNumber { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string SubRegion { get; set; }

        [JsonPropertyName("world_region")]
        public string WorldRegion { get; set; }

        [JsonPropertyName("un_locode")]
        public string UNLocode { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("eu_member")]
        public bool EUMember { get; set; }
        
        [JsonPropertyName("eea_member")]
        public bool EEAMember { get; set; }

    }

    public class GeoSpecifications
    {

    }
}
