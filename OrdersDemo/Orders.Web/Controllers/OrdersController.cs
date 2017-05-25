using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Orders.Domain;
using Orders.Web.DataLayer;

namespace Orders.Web.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersDatabase db = new OrdersDatabase();

        // GET: Orders
        public ActionResult Index()
        {
            var r = (from o in db.Orders
                    join d in db.OrderDetails on o.Id equals d.OrderId
                    select new 
                    {   Id = o.Id,
                        OrderDate = o.OrderDate,
                        OrderNumber = o.OrderNumber,
                        OrderTotal = d.Price
                    }).ToList();

            var r2 = (from line in r
                     group line by line.Id into g
                     select new 
                     {
                         Id = g.First().Id,
                         OrderNumber = g.First().OrderNumber,
                         OrderDate = g.First().OrderDate,
                         OrderTotal = g.Sum( a => a.OrderTotal)
                     }).Select(x=> new Order
                                    {
                                        Id = x.Id,
                                        OrderNumber = x.OrderNumber,
                                        OrderDate = x.OrderDate,
                                        OrderTotal = x.OrderTotal
                     });


            return View(r2.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Order order = db.Orders.Find(id);
            order.OrderDetails = db.OrderDetails.Where(d => d.OrderId == id).ToList();
            order.OrderTotal = db.OrderDetails.Where(d => d.OrderId == id).Sum(d => d.Price);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //// GET: Orders/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Orders/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,OrderNumber,OrderDate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(order);
        //}

        //// GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,OrderNumber,OrderDate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(order);
        //}

        //// GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    db.Orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
