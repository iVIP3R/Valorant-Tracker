﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class PlayerAccountDetails
    {
        public string ID { get; set; }
        public string AccountRegion { get; set; }
        public string GameName { get; set; }
        public string TagLine { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusCode;
        private static string[,] Countries = {
                                        {"ABW", "Aruba"},
                                        {"AFG", "Afghanistan"},
                                        {"AGO", "Angola"},
                                        {"AIA", "Anguilla"},
                                        {"ALA", "Åland Islands"},
                                        {"ALB", "Albania"},
                                        {"AND", "Andorra"},
                                        {"ARE", "United Arab Emirates"},
                                        {"ARG", "Argentina"},
                                        {"ARM", "Armenia"},
                                        {"ASM", "American Samoa"},
                                        {"ATA", "Antarctica"},
                                        {"ATF", "French Southern Territories"},
                                        {"ATG", "Antigua and Barbuda"},
                                        {"AUS", "Australia"},
                                        {"AUT", "Austria"},
                                        {"AZE", "Azerbaijan"},
                                        {"BDI", "Burundi"},
                                        {"BEL", "Belgium"},
                                        {"BEN", "Benin"},
                                        {"BES", "Bonaire, Sint Eustatius and Saba"},
                                        {"BFA", "Burkina Faso"},
                                        {"BGD", "Bangladesh"},
                                        {"BGR", "Bulgaria"},
                                        {"BHR", "Bahrain"},
                                        {"BHS", "Bahamas"},
                                        {"BIH", "Bosnia and Herzegovina"},
                                        {"BLM", "Saint Barthélemy"},
                                        {"BLR", "Belarus"},
                                        {"BLZ", "Belize"},
                                        {"BMU", "Bermuda"},
                                        {"BOL", "Bolivia"},
                                        {"BRA", "Brazil"},
                                        {"BRB", "Barbados"},
                                        {"BRN", "Brunei Darussalam"},
                                        {"BTN", "Bhutan"},
                                        {"BVT", "Bouvet Island"},
                                        {"BWA", "Botswana"},
                                        {"CAF", "Central African Republic"},
                                        {"CAN", "Canada"},
                                        {"CCK", "Cocos (Keeling) Islands"},
                                        {"CHE", "Switzerland"},
                                        {"CHL", "Chile"},
                                        {"CHN", "China"},
                                        {"CIV", "Côte d'Ivoire"},
                                        {"CMR", "Cameroon"},
                                        {"COD", "Democratic Republic of the Congo"},
                                        {"COG", "Republic of the Congo"},
                                        {"COK", "Cook Islands"},
                                        {"COL", "Colombia"},
                                        {"COM", "Comoros"},
                                        {"CPV", "Cabo Verde"},
                                        {"CRI", "Costa Rica"},
                                        {"CUB", "Cuba"},
                                        {"CUW", "Curaçao"},
                                        {"CXR", "Christmas Island"},
                                        {"CYM", "Cayman Islands"},
                                        {"CYP", "Cyprus"},
                                        {"CZE", "Czech Republic"},
                                        {"DEU", "Germany"},
                                        {"DJI", "Djibouti"},
                                        {"DMA", "Dominica"},
                                        {"DNK", "Denmark"},
                                        {"DOM", "Dominican Republic"},
                                        {"DZA", "Algeria"},
                                        {"ECU", "Ecuador"},
                                        {"EGY", "Egypt"},
                                        {"ERI", "Eritrea"},
                                        {"ESH", "Western Sahara"},
                                        {"ESP", "Spain"},
                                        {"EST", "Estonia"},
                                        {"ETH", "Ethiopia"},
                                        {"FIN", "Finland"},
                                        {"FJI", "Fiji"},
                                        {"FLK", "Falkland Islands (Malvinas)"},
                                        {"FRA", "France"},
                                        {"FRO", "Faroe Islands"},
                                        {"FSM", "Micronesia"},
                                        {"GAB", "Gabon"},
                                        {"GBR", "United Kingdom"},
                                        {"GEO", "Georgia"},
                                        {"GGY", "Guernsey"},
                                        {"GHA", "Ghana"},
                                        {"GIB", "Gibraltar"},
                                        {"GIN", "Guinea"},
                                        {"GLP", "Guadeloupe"},
                                        {"GMB", "Gambia"},
                                        {"GNB", "Guinea-Bissau"},
                                        {"GNQ", "Equatorial Guinea"},
                                        {"GRC", "Greece"},
                                        {"GRD", "Grenada"},
                                        {"GRL", "Greenland"},
                                        {"GTM", "Guatemala"},
                                        {"GUF", "French Guiana"},
                                        {"GUM", "Guam"},
                                        {"GUY", "Guyana"},
                                        {"HKG", "Hong Kong"},
                                        {"HMD", "Heard Island and McDonald Islands"},
                                        {"HND", "Honduras"},
                                        {"HRV", "Croatia"},
                                        {"HTI", "Haiti"},
                                        {"HUN", "Hungary"},
                                        {"IDN", "Indonesia"},
                                        {"IMN", "Isle of Man"},
                                        {"IND", "India"},
                                        {"IOT", "British Indian Ocean Territory"},
                                        {"IRL", "Ireland"},
                                        {"IRN", "Iran"},
                                        {"IRQ", "Iraq"},
                                        {"ISL", "Iceland"},
                                        {"ISR", "Palestine"},
                                        {"ITA", "Italy"},
                                        {"JAM", "Jamaica"},
                                        {"JEY", "Jersey"},
                                        {"JOR", "Jordan"},
                                        {"JPN", "Japan"},
                                        {"KAZ", "Kazakhstan"},
                                        {"KEN", "Kenya"},
                                        {"KGZ", "Kyrgyzstan"},
                                        {"KHM", "Cambodia"},
                                        {"KIR", "Kiribati"},
                                        {"KNA", "Saint Kitts and Nevis"},
                                        {"KOR", "South Korea"},
                                        {"KWT", "Kuwait"},
                                        {"LAO", "Lao People's Democratic Republic"},
                                        {"LBN", "Lebanon"},
                                        {"LBR", "Liberia"},
                                        {"LBY", "Libya"},
                                        {"LCA", "Saint Lucia"},
                                        {"LIE", "Liechtenstein"},
                                        {"LKA", "Sri Lanka"},
                                        {"LSO", "Lesotho"},
                                        {"LTU", "Lithuania"},
                                        {"LUX", "Luxembourg"},
                                        {"LVA", "Latvia"},
                                        {"MAC", "Macao"},
                                        {"MAF", "Saint Martin (French part)"},
                                        {"MAR", "Morocco"},
                                        {"MCO", "Monaco"},
                                        {"MDA", "Moldova"},
                                        {"MDG", "Madagascar"},
                                        {"MDV", "Maldives"},
                                        {"MEX", "Mexico"},
                                        {"MHL", "Marshall Islands"},
                                        {"MKD", "Macedonia"},
                                        {"MLI", "Mali"},
                                        {"MLT", "Malta"},
                                        {"MMR", "Myanmar"},
                                        {"MNE", "Montenegro"},
                                        {"MNG", "Mongolia"},
                                        {"MNP", "Northern Mariana Islands"},
                                        {"MOZ", "Mozambique"},
                                        {"MRT", "Mauritania"},
                                        {"MSR", "Montserrat"},
                                        {"MTQ", "Martinique"},
                                        {"MUS", "Mauritius"},
                                        {"MWI", "Malawi"},
                                        {"MYS", "Malaysia"},
                                        {"MYT", "Mayotte"},
                                        {"NAM", "Namibia"},
                                        {"NCL", "New Caledonia"},
                                        {"NER", "Niger"},
                                        {"NFK", "Norfolk Island"},
                                        {"NGA", "Nigeria"},
                                        {"NIC", "Nicaragua"},
                                        {"NIU", "Niue"},
                                        {"NLD", "Netherlands"},
                                        {"NOR", "Norway"},
                                        {"NPL", "Nepal"},
                                        {"NRU", "Nauru"},
                                        {"NZL", "New Zealand"},
                                        {"OMN", "Oman"},
                                        {"PAK", "Pakistan"},
                                        {"PAN", "Panama"},
                                        {"PCN", "Pitcairn"},
                                        {"PER", "Peru"},
                                        {"PHL", "Philippines"},
                                        {"PLW", "Palau"},
                                        {"PNG", "Papua New Guinea"},
                                        {"POL", "Poland"},
                                        {"PRI", "Puerto Rico"},
                                        {"PRK", "North Korea"},
                                        {"PRT", "Portugal"},
                                        {"PRY", "Paraguay"},
                                        {"PSE", "Palestine"},
                                        {"PYF", "French Polynesia"},
                                        {"QAT", "Qatar"},
                                        {"REU", "Réunion"},
                                        {"ROU", "Romania"},
                                        {"RUS", "Russia"},
                                        {"RWA", "Rwanda"},
                                        {"SAU", "Saudi Arabia"},
                                        {"SDN", "Sudan"},
                                        {"SEN", "Senegal"},
                                        {"SGP", "Singapore"},
                                        {"SGS", "South Georgia and the South Sandwich Islands"},
                                        {"SHN", "Saint Helena, Ascension and Tristan da Cunha"},
                                        {"SJM", "Svalbard and Jan Mayen"},
                                        {"SLB", "Solomon Islands"},
                                        {"SLE", "Sierra Leone"},
                                        {"SLV", "El Salvador"},
                                        {"SMR", "San Marino"},
                                        {"SOM", "Somalia"},
                                        {"SPM", "Saint Pierre and Miquelon"},
                                        {"SRB", "Serbia"},
                                        {"SSD", "South Sudan"},
                                        {"STP", "Sao Tome and Principe"},
                                        {"SUR", "Suriname"},
                                        {"SVK", "Slovakia"},
                                        {"SVN", "Slovenia"},
                                        {"SWE", "Sweden"},
                                        {"SWZ", "Swaziland"},
                                        {"SXM", "Sint Maarten (Dutch part)"},
                                        {"SYC", "Seychelles"},
                                        {"SYR", "Syria"},
                                        {"TCA", "Turks and Caicos Islands"},
                                        {"TCD", "Chad"},
                                        {"TGO", "Togo"},
                                        {"THA", "Thailand"},
                                        {"TJK", "Tajikistan"},
                                        {"TKL", "Tokelau"},
                                        {"TKM", "Turkmenistan"},
                                        {"TLS", "Timor-Leste"},
                                        {"TON", "Tonga"},
                                        {"TTO", "Trinidad and Tobago"},
                                        {"TUN", "Tunisia"},
                                        {"TUR", "Turkey"},
                                        {"TUV", "Tuvalu"},
                                        {"TWN", "Taiwan"},
                                        {"TZA", "Tanzania"},
                                        {"UGA", "Uganda"},
                                        {"UKR", "Ukraine"},
                                        {"UMI", "United States Minor Outlying Islands"},
                                        {"URY", "Uruguay"},
                                        {"USA", "United States of America"},
                                        {"UZB", "Uzbekistan"},
                                        {"VAT", "Holy See (Vatican City State)"},
                                        {"VCT", "Saint Vincent and the Grenadines"},
                                        {"VEN", "Venezuela"},
                                        {"VGB", "Virgin Islands, British"},
                                        {"VIR", "Virgin Islands, U.S."},
                                        {"VNM", "Viet Nam"},
                                        {"VUT", "Vanuatu"},
                                        {"WLF", "Wallis and Futuna"},
                                        {"WSM", "Samoa"},
                                        {"YEM", "Yemen"},
                                        {"ZAF", "South Africa"},
                                        {"ZMB", "Zambia"},
                                      };

        private static string ConvertPlayerLocaleToCountryName(string PlayerLocale)
        {
            string Country = null;
            for (int i = 0; i < Countries.GetLength(0); i++)
            {
                if (string.Equals(Countries[i, 0], PlayerLocale))
                {
                    Country = Countries[i, 1];
                }
            }
            return Country;
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime DateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime = DateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return DateTime;
        }

        public static PlayerAccountDetails GetDetails (Auth au)
        {
            PlayerAccountDetails ret = new PlayerAccountDetails();
            RestClient Client = new RestClient(new Uri("https://auth.riotgames.com/userinfo/"));
            RestRequest Request = new RestRequest(Method.POST);
            Request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            var Response = Client.Execute(Request);
            string ResponseContent = Response.Content;
            JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(ResponseContent));
            ret.ID = obj["sub"].Value<string>();
            ret.AccountRegion = ConvertPlayerLocaleToCountryName(obj["country"].Value<string>().ToUpper());
            ret.GameName = obj["acct"].Value<string>("game_name");
            ret.TagLine = obj["acct"].Value<string>("tag_line");
            ret.CreatedAt = UnixTimeStampToDateTime(obj["acct"].Value<double>("created_at"));
            ret.StatusCode = (int)Response.StatusCode;
            return ret;
        }
    }
}