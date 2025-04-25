using System.Net;
using System.Text;

namespace WebApplication1.Controllers
{
    public class CommonServices
    {


        #region public string PostRequest(string jsondata, string sHostURL, string Method = "POST")

        /// <summary>

        /// PostRequest

        /// </summary>

        /// <param name="jsondata"></param>

        /// <param name="sHostURL"></param>

        /// <param name="Method"></param>

        /// <returns></returns>

        public string PostRequest(string jsondata, string sHostURL)

        {

            string response = string.Empty;

            try

            {

                response = sHostURL;

                HttpWebRequest webServiceRequest = (HttpWebRequest)HttpWebRequest.Create(sHostURL);

                webServiceRequest.Method = "Get";

                webServiceRequest.ContentType = "application/json";


                if (jsondata.Length != 0)

                {

                    using (var streamWriter = new StreamWriter(webServiceRequest.GetRequestStream()))

                    {

                        streamWriter.WriteLine(jsondata);

                        streamWriter.Flush();

                        streamWriter.Close();

                    }

                }

                using (HttpWebResponse httpResponse = (HttpWebResponse)webServiceRequest.GetResponse())

                {

                    using (Stream responseStream = httpResponse.GetResponseStream())

                    {

                        using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default))

                        {

                            string sResponse = myStreamReader.ReadToEnd();

                            if (!string.IsNullOrEmpty(sResponse))

                            {

                                response = response+ sResponse;

                            }

                        }

                    }

                }

            }

            catch (Exception ex)

            {

                response= response+" "+ ex.Message.ToString();

            }

            return response;

        }

        #endregion
 
    }
}
