using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fis.Fwk.Core.Geoloc
{
    public static class Geolocalisation
    {
        public class Coord
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public enum LocationType
        {
            /// <summary>
            /// Inconnu
            /// </summary>
            unknown = -1,

            /// <summary>
            /// Ville
            /// </summary>
            country = 0,

            /// <summary>
            /// Ville
            /// </summary>
            locality = 1,

            /// <summary>
            /// Entité civile de premier ordre en dessous d'une ville
            /// </summary>
            sublocality = 2,

            /// <summary>
            /// code postal tel qu'utilisé dans les adresses de courrier postal du pays
            /// </summary>
            postal_code = 3,

            /// <summary>
            /// Adresse
            /// </summary>
            street_address = 4
        }

        public class Place
        {
            /// <summary>
            /// Id google de la place
            /// </summary>
            public string placeId { get; set; }
            /// <summary>
            /// Type de la place
            /// </summary>
            public LocationType type { get; set; }

            /// <summary>
            /// Adresse formattée de la place
            /// </summary>
            public string adresseFormatted { get; set; }

            /// <summary>
            /// Code postal
            /// </summary>
            public string postalCode { get; set; }

            /// <summary>
            /// N° de rue
            /// </summary>
            public string number { get; set; }

            /// <summary>
            /// Rue
            /// </summary>
            public string route { get; set; }

            /// <summary>
            /// Ville
            /// </summary>
            public string locality { get; set; }

            /// <summary>
            /// Arrondissement
            /// </summary>
            public string subLocality { get; set; }

            /// <summary>
            /// Département
            /// </summary>
            public string departement { get; set; }

            /// <summary>
            /// Région
            /// </summary>
            public string region { get; set; }

            /// <summary>
            /// Pays
            /// </summary>
            public string country { get; set; }

            public string latitude { get; set; }
            public string longitude { get; set; }

        }

        static public Coord GetLatitude(string p_sAdresse, string p_sVille, string p_sCP, string sPays)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string sRequete = "address=" + p_sAdresse.Replace(" ", "+") + ",+" +
                      p_sVille.Replace(" ", "+") + ",+" + p_sCP.Replace(" ", "+") + ",+" +
                      sPays.Replace(" ", "+");
            Coord coord = GetLatitude(sRequete);
            if (coord == null)
            {
                sRequete = "address=" + p_sVille.Replace(" ", "+") + ",+" + p_sCP.Replace(" ", "+") + ",+" +
                      sPays.Replace(" ", "+");
                coord = GetLatitude(sRequete);
            }
            return coord;
        }

        static public Coord GetLatitude(string p_sPostData)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string p_sAdress = "http://maps.google.com/maps/api/geocode/xml";
            string l_sResult = null;
            StreamReader postreqreader = default(StreamReader);

            string postData = p_sPostData;
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteData = encoding.GetBytes(postData);
            HttpWebRequest postreq = (HttpWebRequest)HttpWebRequest.Create(p_sAdress + "?" + p_sPostData);
            postreq.Method = "GET";
            postreq.KeepAlive = true;
            WebResponse postresponse = default(HttpWebResponse);
            postresponse = postreq.GetResponse();
            postreqreader = new StreamReader(postresponse.GetResponseStream());
            l_sResult = postreqreader.ReadToEnd();
            XmlDocument l_xmlResult = new XmlDocument();
            try
            {
                l_xmlResult.LoadXml(l_sResult);
                if (l_xmlResult.LastChild.SelectSingleNode("/GeocodeResponse/status").InnerText == "OK")
                {
                    Coord coord = new Coord();
                    coord.latitude = l_xmlResult.LastChild.SelectSingleNode("/GeocodeResponse/result/geometry/location/lat").InnerText;
                    coord.longitude = l_xmlResult.LastChild.SelectSingleNode("/GeocodeResponse/result/geometry/location/lng").InnerText;
                    return coord;
                }

            }
            catch
            {

            }
            return null;

        }

        static public Coord GetCoordonnees(string key, string adresse, string ville, string cp, string pays)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string data = string.Format("address={0},+{1},+{2},+{3}", adresse.Replace(" ", "+"), ville.Replace(" ", "+"), cp.Replace(" ", "+"), pays.Replace(" ", "+"));
            Coord coord = GetCoordonnees(key, data);
            if (coord == null)
            {
                data = string.Format("address={0},+{1},+{2}", ville.Replace(" ", "+"), cp.Replace(" ", "+"), pays.Replace(" ", "+"));
                coord = GetCoordonnees(key, data);
            }
            return coord;
        }

        static public Coord GetCoordonnees(string key, string data)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://maps.google.com/maps/api/geocode/xml?{0}&key={1}", data, key));
            req.Method = "GET";
            req.KeepAlive = true;
            req.Referer = "";
            req.Headers.Add("Accept-Language", "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3");

            WebResponse reponse = req.GetResponse();
            StreamReader reader = new StreamReader(reponse.GetResponseStream());
            string result = reader.ReadToEnd();
            var xml = new XmlDocument();
            try
            {
                xml.LoadXml(result);
                if (xml.LastChild.SelectSingleNode("/GeocodeResponse/status").InnerText == "OK")
                {
                    Coord coord = new Coord();
                    coord.latitude = xml.LastChild.SelectSingleNode("/GeocodeResponse/result/geometry/location/lat").InnerText;
                    coord.longitude = xml.LastChild.SelectSingleNode("/GeocodeResponse/result/geometry/location/lng").InnerText;
                    return coord;
                }

            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// Retourne les informations d'une adresse
        /// </summary>
        /// <param name="key">clé</param>
        /// <param name="data">format: address=info1+info2+..</param>
        /// <returns></returns>
        static public Place GetPlace(string key, string data)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("https://maps.google.com/maps/api/geocode/xml?{0}&key={1}", data, key));
            req.Method = "GET";
            req.KeepAlive = true;
            req.Referer = "";
            req.Headers.Add("Accept-Language", "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3");

            WebResponse reponse = req.GetResponse();
            StreamReader reader = new StreamReader(reponse.GetResponseStream());
            string result = reader.ReadToEnd();
            var xml = new XmlDocument();
            try
            {
                xml.LoadXml(result);
                if (xml.LastChild.SelectSingleNode("/GeocodeResponse/status").InnerText == "OK")
                {
                    Place place = new Place()
                    {
                        placeId = xml.LastChild.SelectSingleNode("/GeocodeResponse/result/place_id").InnerText,
                        type = GetPlaceType(xml.LastChild.SelectSingleNode("/GeocodeResponse/result/type").InnerText),
                        adresseFormatted = xml.LastChild.SelectSingleNode("/GeocodeResponse/result/formatted_address").InnerText,
                        latitude = xml.LastChild.SelectSingleNode("/GeocodeResponse/result/geometry/location/lat").InnerText,
                        longitude = xml.LastChild.SelectSingleNode("/GeocodeResponse/result/geometry/location/lng").InnerText
                    };

                    XmlNodeList xmlNodeList = xml.LastChild.SelectNodes("/GeocodeResponse/result/address_component");

                    if (xmlNodeList != null && xmlNodeList.Count > 0)
                    {
                        foreach (XmlNode item in xmlNodeList)
                        {
                            if (item["type"].InnerText == "country")
                            {
                                place.country = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "administrative_area_level_1")
                            {
                                place.region = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "administrative_area_level_2")
                            {
                                place.departement = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "locality")
                            {
                                place.locality = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "sublocality_level_1")
                            {
                                place.subLocality = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "postal_code")
                            {
                                place.postalCode = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "route")
                            {
                                place.route = item["long_name"].InnerText;
                            }
                            else if (item["type"].InnerText == "street_number")
                            {
                                place.number = item["long_name"].InnerText;
                            }
                        }
                    }


                    return place;
                }
            }
            catch
            {

            }
            return null;
        }

        private static string GetPostalCode(XmlNodeList xmlNodeList)
        {
            var result = string.Empty;
            try
            {
                if (xmlNodeList != null && xmlNodeList.Count > 0)
                {
                    foreach (XmlNode item in xmlNodeList)
                    {
                        if (item["type"].InnerText == "postal_code")
                        {
                            result = item["long_name"].InnerText;
                        }
                    }
                }

            }
            catch
            {
            }


            return result;
        }

        private static LocationType GetPlaceType(string innerText)
        {
            var result = LocationType.unknown;
            if (innerText == "street_address")
            {
                return LocationType.street_address;
            }
            if (innerText == "locality")
            {
                return LocationType.locality;
            }
            if (innerText == "sublocality")
            {
                return LocationType.sublocality;
            }
            if (innerText == "postal_code")
            {
                return LocationType.postal_code;
            }
            if (innerText == "country")
            {
                return LocationType.country;
            }
            return result;
        }

        /// <summary>
        /// Calculer la distance entre 2 points
        /// </summary>
        /// <param name="latitudeOrigine"></param>
        /// <param name="longitudeorgine"></param>
        /// <param name="latitudeCible"></param>
        /// <param name="longitudeCible"></param>
        /// <returns></returns>
        static public Double CalculerDistance(double latitudeOrigine, double longitudeorgine, double latitudeCible, double longitudeCible)
        {
            double rayonTerre = 6366000;
            double radLatOrigine = (Math.PI / 180) * latitudeOrigine;
            double radLongOrigine = (Math.PI / 180) * longitudeorgine;
            double radLatCible = (Math.PI / 180) * latitudeCible;
            double radLongtCible = (Math.PI / 180) * longitudeCible;

            return rayonTerre * Math.Acos(Math.Sin(radLatOrigine) * Math.Sin(radLatCible) + Math.Cos(radLatOrigine) * Math.Cos(radLatCible) * Math.Cos(radLongOrigine - radLongtCible));
        }
    }
}
