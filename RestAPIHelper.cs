using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomationTest
{
    class RestAPIHelper
    {

        static RestClient client;
        static IRestResponse response;
        static RestRequest request;

        // This will create a client connection
        public static RestClient URLSetUp(String baseURL, String endPointURL)
        {
            try
            {
                String completeURL = baseURL + endPointURL;
                client = new RestClient(completeURL);
            }
            catch (Exception e)
            {
                throw e;
            }
            return client;
        }

        // This will create GET method as request
        public static RestRequest CreateGETRequest()
        {
            request = new RestRequest(Method.GET);
            try
            {
                request.AddHeader("Accept", "application/json");
            }
            catch(Exception e)
            {
                throw e;
            }
            return request;
        }

        // This will execute requested method and return the content in the form of response interface object
        public static IRestResponse GetResponse()
        {
            try
            {
                response=client.Execute(request);
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        // This method will return a particular userInfo requested data 
        public static RestRequest CreateRequestBasisOnParameter(String enterValue)
        {
            try
            {
                request = new RestRequest(enterValue, Method.GET);
                request.AddHeader("Accept", "application/json");
            }
            catch(Exception e)
            {
                throw e;
            }
            return request;
        }

        public static RestRequest CreatePOSTRequest()
        {
            UserInformations userInformationObj = new UserInformations();
            try
            {
                request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");               
                userInformationObj.Id = "100";
                userInformationObj.Title = "Activities 100";
                request.AddJsonBody(userInformationObj);
            }
            catch(Exception e)
            {
                throw e;

            }

            return request;
        }
    }
}
