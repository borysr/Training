using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Domain;
using Test.Web.Data;

namespace Test.Web.Controllers
{
    public class OrderApiController : ApiController
    {
        TestDb _db;

        public OrderApiController(TestDb db)
        {
            _db = db;
        }
        // GET: api/OrderApi
        public IEnumerable<Order> GetOrders()
        {
            return _db.Orders;
        }

        // GET: api/OrderApi/5
        public Order GetOrder(int id)
        {
            return _db.Orders.Find(id);
        }

        // POST: api/OrderApi
        public HttpResponseMessage CreateOrder(Order order)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid && order != null)
            {
                try
                {
                    _db.Orders.Add(order);
                    _db.SaveChanges();
                    response = Request.CreateResponse(HttpStatusCode.Created, order);
                }
                catch (Exception)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            return response;

        }

        // PUT: api/OrderApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderApi/5
        public void Delete(int id)
        {
        }
    }
}
