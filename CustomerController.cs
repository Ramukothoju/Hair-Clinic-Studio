using HairClinic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HairClinic.Controllers
{
   
    public class CustomerController : Controller
    {
        SqlDal sql = new SqlDal();

        [Authorize]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(int id)
        {
           Customer customer= sql.customre(id);
            
            return View("find",customer);
        }
        [Authorize]
       public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Customer customer,HttpPostedFileBase selectdFile)
        {
            if (selectdFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                selectdFile.SaveAs(path+selectdFile.FileName);
                customer.photo = selectdFile.FileName;
            }
            sql.Client_Create(customer);

            return Redirect("/Home/Clientinfo");

        }
        public ActionResult Edit(int id)
        {
            Customer user=sql.customre(id);
            TempData["Photo"] = user.photo;
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Customer customers,HttpPostedFileBase selectedFile)
        {
            if(selectedFile != null)
            {
                String path = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                selectedFile.SaveAs(path+ selectedFile.FileName);
                customers.photo= selectedFile.FileName;
            }
            else if (TempData["Photo"]!=null)
            {
                customers.photo = TempData["Photo"].ToString();
            }
            sql.Client_Update(customers);
            
            return Redirect("/Home/Clientinfo");
        }



      

    }

    
}