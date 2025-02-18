using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairClinic.Models;
using Microsoft.Ajax.Utilities;
namespace HairClinic.Controllers
{
    public class HomeController : Controller
    {
        
      public ActionResult Clientinfo()
        {
            return View();
        }
       
       
    }
}