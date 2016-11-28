using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using KingfisherIT.Service.Models;
using System;

namespace KingfisherIT.Service.Api
{
    public class KingfisherApi
    {
        private readonly string baseUrl;
        private string requestToken;
        private JavaScriptSerializer jss;

        private static KingfisherApi instance;

        public static KingfisherApi Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KingfisherApi();
                }

                return instance;
            }
        }

        private KingfisherApi()
        {
            baseUrl = "http://cib.callumthomson.co.uk/api";
            jss = new JavaScriptSerializer();           
        }
              
        public Project[] GetUserProjects()
        {
            string json = InternalGetRequest(baseUrl + "/me/projects?_token=" + requestToken);
            return jss.Deserialize<Project[]>(json);
        }

        public Activity[] GetActivities()
        {
            string json = InternalGetRequest(baseUrl + "/activities?_token=" + requestToken);
            return jss.Deserialize<Activity[]>(json);
        }

        public bool Authenticate(string username, string password)
        {
            var postParams = new NameValueCollection()
            {
                {"username", username},
                {"password", password}
            };

            try
            {
                string json = InternalPostRequest(baseUrl + "/auth", postParams);
                requestToken = jss.Deserialize<dynamic>(json)["_token"];
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }

        private string InternalPostRequest(string url, NameValueCollection postParams)
        {
            postParams.Add("_token", requestToken);
            using (var wc = new WebClient())
            {
                return Encoding.UTF8.GetString(wc.UploadValues(url, postParams));
            }
        }

        private string InternalGetRequest(string url)
        {
            using (var wc = new WebClient())
            {
                return wc.DownloadString(url);
            }
        }

        public bool SubmitTimesheet(object task, DateTime dateTime, decimal hoursSpent)
        {
            var postParams = new NameValueCollection()
            {
                {"date", dateTime.Date.ToString("yyyy-MM-dd")},
                {"hours_spent", hoursSpent.ToString()},
            };

            if (task is Task)
            {
                postParams.Add("task_id", ((Task) task).Id.ToString());
            }
            else if (task is Activity)
            {
                postParams.Add("activity_id", ((Activity)task).Id.ToString());
            }

            try
            {
                InternalPostRequest(baseUrl + "/submit", postParams);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}