using GabrielMontoyaPrueba20_02_22.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GabrielMontoyaPrueba20_02_22.Business
{
    public class AuthorBusiness
    {
        public List<AuthorEntities> DatosAuthor()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://fakerestapi.azurewebsites.net/api/v1/Authors");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<AuthorEntities> authors = JsonConvert.DeserializeObject<List<AuthorEntities>>(json);
                return authors;
            }
        }
    }
}