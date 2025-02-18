using HairClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web;

namespace HairClinic.Controllers
{
    public class EQdataController:Controller
    {
        SqlDal sql = new SqlDal();

        [HttpGet]
        public ActionResult Get_EQCustomers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Get_EQCustomers(Enqiry e)
        {
            sql.insertEQ(e);
            
            return View("Get_EQCustomers");
        }


        // enquriy data

        public ActionResult Remainder()
        {

            return View();
        }
        
    }
}