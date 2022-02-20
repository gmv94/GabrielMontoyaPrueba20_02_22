using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using GabrielMontoyaPrueba20_02_22.Entities;

namespace GabrielMontoyaPrueba20_02_22.API
{
    public class DatosAPI
    {
        public List<UserEntities> DatosUser()
        {
            //return (HttpWebRequest)WebRequest.Create(@"https://fakerestapi.azurewebsites.net/api/v1/Users");
            //List<UserEntities> Users = new List<UserEntities>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://fakerestapi.azurewebsites.net/api/v1/Users");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<UserEntities> Users = JsonConvert.DeserializeObject<List<UserEntities>>(json);

                //foreach (var item in Users)
                //{
                //    Users.Add(item);
                //}
                return Users;
            }
        }
    }
}