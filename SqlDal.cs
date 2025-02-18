using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HairClinic.Models
{
    public class SqlDal: ISqlDal
    {
        HairStudioEntities context = new HairStudioEntities();

        public Customer customre(int id)
        {
            Customer cust = context.Customers.Find(id);
            return cust;
        }
        public void Client_Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();

        }

        public void Client_Update(Customer customer)
        {
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
       
        public void SiginData(Singin entry)
        {
            context.Singins.Add(entry);
            context.SaveChanges();
        }

        public void insertEQ(Enqiry eq)
        {
            context.Enqiries.Add(eq);
            context.SaveChanges();

            Remaider remaider = new Remaider();

            remaider.EnqId = eq.Id;
            remaider.name = eq.Name;
            remaider.Phone = eq.Phone;
            remaider.Gender = eq.Gender;
            remaider.Date = eq.AvaliDate;
            remaider.Feedback = eq.Discription;

            context.Remaiders.Add(remaider);
            context.SaveChanges();


        }

        public void eqremderdate(Remaider re)
        {
            context.Remaiders.Add(re);
            context.SaveChanges();
        }

        public void insertEQTest(Enqiry eq)
        {
            //
        }
    }

    public interface ISqlDal
    {
         void insertEQTest(Enqiry eq);
    }
}