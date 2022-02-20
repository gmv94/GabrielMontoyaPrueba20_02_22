using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielMontoyaPrueba20_02_22.Entities
{
    public class AuthorEntities
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}