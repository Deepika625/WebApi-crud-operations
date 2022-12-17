using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUD_WEB_API.Models;

namespace CRUD_WEB_API.Controllers
{
    public class ProductController : ApiController
    {
        deepikaDBEntities1 d= new deepikaDBEntities1();
        //POST request
        public string POST(Demo demo)
        {
            d.Demoes.Add(demo);
            d.SaveChanges();
            return "Added success";
        }
        //Get request
        public IEnumerable<Demo> Get()
        {
            return d.Demoes.ToList();
        }
        //Get single record
        public Demo Get(int id)
        {
            Demo employee = d.Demoes.Find(id);
            return employee;
        }
        //updating the record
        public string PUT(int id, Demo employess)
        {
            var employess_ = d.Demoes.Find(id);
            employess_.Name = employess.Name;
            employess_.Price = employess.Price;
            employess_.Quantity = employess.Quantity;
            employess_.Active= employess.Active;



            d.Entry(employess_).State = System.Data.Entity.EntityState.Modified;
            d.SaveChanges();
            return "employee details are updated";



        }
        //deleting the record
        public string DELETE(int id)
        {
            Demo employee = d.Demoes.Find(id);
            d.Demoes.Remove(employee);
            d.SaveChanges();
            return "record deleted successfully";
        }
    }
}
    

