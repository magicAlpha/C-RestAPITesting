using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using Assert = NUnit.Framework.Assert;

namespace RestSharpAPIAutomationTest
{
    [TestClass]
    public class RestSharpAPITest
    {
        [TestMethod]
        public void GetWeatherInfo()
        {
            try
            {
                // This will create an rest connection
                RestClient restClientObj = new RestClient("http://restapi.demoqa.com/utilities/weather/city/");

                // restClientObj.Authenticator = new HttpBasicAuthenticator(username, password);

                // This will execute the request
                RestRequest restRequestObj = new RestRequest("Delhi", Method.GET);

                // This will get the response and store in IRestResponse interface
                IRestResponse irestResponseObj = restClientObj.Execute(restRequestObj);

                // This will get content of executed URL
                string contentOfURL = irestResponseObj.Content;
                Console.WriteLine(contentOfURL);
                if (!contentOfURL.Contains("Delhi"))
                {
                    Assert.Fail("Weather information is not displayed");
                }
                HttpStatusCode objHttpStatusCode = irestResponseObj.StatusCode;

                // This will verify the status code i.e, OK
                Console.WriteLine("Status of code is " + objHttpStatusCode.ToString());
                string expectedStatusCode = objHttpStatusCode.ToString();
                Assert.AreEqual(expectedStatusCode, "OK");

                // This will verify if response code i.e, 200
                int expectedResponseCode = (int)objHttpStatusCode;
                Console.WriteLine("Response code is : " + expectedResponseCode);
                Assert.AreEqual(expectedResponseCode, 200);

                // This will verify the status of response i.e, completed
                string exepctedResponseStatus = irestResponseObj.ResponseStatus.ToString();
                Console.WriteLine("Response of status is : " + exepctedResponseStatus);
                Assert.AreEqual(exepctedResponseStatus, "Completed");

                String protocolVersion = irestResponseObj.ProtocolVersion.ToString();
                Console.WriteLine(protocolVersion);

                string descr = irestResponseObj.StatusDescription;
                Console.WriteLine(descr);


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void GETActivitiesInfo()
        {
            try
            {
                RestClient restClientObj = new RestClient("http://fakerestapi.azurewebsites.net/api/Activities");
                RestRequest restRequestObj = new RestRequest("2", Method.GET);
                IRestResponse irestResponseObj = restClientObj.Execute(restRequestObj);

                HttpStatusCode status = irestResponseObj.StatusCode;
                int responseCode = (int)status;
                Console.WriteLine("Response Code is : " + responseCode);

                string responseStatus = status.ToString();
                Console.WriteLine("Status of response  is : " + responseStatus);

                // This will get all content by executing below request and stored in IRestResponse interface object
                RestRequest restRequestObj1 = new RestRequest(Method.GET);
                restRequestObj1.AddHeader("Accept", "application/json");
                IRestResponse irestResponseObj1 = restClientObj.Execute(restRequestObj1);

                String str2 = irestResponseObj1.Content;
                Console.WriteLine(str2);

                RestRequest postDataObj = new RestRequest(Method.POST);
                postDataObj.AddHeader("Content-Type", "application/json");
                postDataObj.AddParameter("ID", 90);
                postDataObj.AddParameter("Title", "Activity 90");
                postDataObj.AddJsonBody(postDataObj);

                IRestResponse postResponseObj = restClientObj.Execute(postDataObj);
                int statusOfCode = (int)postResponseObj.StatusCode;
                Console.WriteLine("Status of code executed of POST request is " + statusOfCode);

                String responseOfStatus = postResponseObj.StatusCode.ToString();
                Console.WriteLine("Status of response is : " + responseOfStatus);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        RestAPIHelper obj;

        [TestMethod]
        public void GETActivitiesInfoUsingAPIHelperClass()
        {

            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";
            try
            {
                obj = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreateGETRequest();
                IRestResponse respponse = RestAPIHelper.GetResponse();
                String responseFromGetRequest = respponse.Content;
                Console.WriteLine(responseFromGetRequest);
                HttpStatusCode statusCode = respponse.StatusCode;

                String expected = statusCode.ToString();
                String actual = respponse.StatusCode.ToString();
                Console.WriteLine(expected);
                Console.WriteLine(actual);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void GETParticularData()
        {
            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";
            String enterValue = "5";
            try
            {
                obj = new RestAPIHelper();
                RestClient client=RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request=RestAPIHelper.CreateRequestBasisOnParameter(enterValue);
                IRestResponse respponse=RestAPIHelper.GetResponse();
                String singleUserActivitiesInfo=respponse.Content;
                Console.WriteLine(singleUserActivitiesInfo);

                HttpStatusCode httpStatusCode =respponse.StatusCode;
                int responseCode = (int)httpStatusCode;
                string responseStatus = respponse.StatusCode.ToString();

                Console.WriteLine("Response code is : "+ responseCode);
                Console.WriteLine("The status of response is : " + responseStatus);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void POSTActivitiesInfo()
        {
            String baseURL = "http://fakerestapi.azurewebsites.net";
            String endPointURL = "/api/Activities";          
            try
            {
                obj = new RestAPIHelper();
                RestClient client = RestAPIHelper.URLSetUp(baseURL, endPointURL);
                RestRequest request = RestAPIHelper.CreatePOSTRequest();
                IRestResponse respponse = RestAPIHelper.GetResponse();
                String singleUserActivitiesInfo = respponse.Content;
                Console.WriteLine(singleUserActivitiesInfo);

                HttpStatusCode httpStatusCode = respponse.StatusCode;
                int responseCode = (int)httpStatusCode;
                string responseStatus = respponse.StatusCode.ToString();

                Console.WriteLine("Response code is : " + responseCode);
                Console.WriteLine("The status of response is : " + responseStatus);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
