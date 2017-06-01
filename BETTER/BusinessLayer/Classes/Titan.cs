using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BETTER.DataAccessLayer.Classes;

namespace BETTER.BusinessLayer.Classes
{
    public class Titan
    {
        public string TitanName { get; set; }

        public int ElementID { get; set; }

        public void AddTitan()
        {
            TitanDAL obj = new TitanDAL();
            obj.AddTitan(TitanName, ElementID);
        }
    }
}