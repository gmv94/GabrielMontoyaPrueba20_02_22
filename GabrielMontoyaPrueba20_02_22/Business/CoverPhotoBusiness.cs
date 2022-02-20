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
    public class CoverPhotoBusiness
    {
        public List<CoverPhotoEntities> DatosCoverPhoto()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://fakerestapi.azurewebsites.net/api/v1/CoverPhotos");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<CoverPhotoEntities> coverPhotos = JsonConvert.DeserializeObject<List<CoverPhotoEntities>>(json);
                return coverPhotos;
            }
        }
    }
}