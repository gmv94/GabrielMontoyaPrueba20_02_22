using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielMontoyaPrueba20_02_22.Entities
{
    public class ActivityEntities
    {
        public int id { get; set; }
        public string title { get; set; }
        public string dueDate { get; set; }
        public bool completed { get; set; }
    }
}