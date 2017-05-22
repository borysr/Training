using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Domain;
using Test.Web.Data;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        private TestDb db = new TestDb();

        // GET: OrderDetails
        //public ActionResult Index()
        //{
        //    return View(db.OrderDetails.ToList());
        //}

        //public ActionResult Order(int? orderId)
        //{
        //    if (orderId == null)
        //    {
        //        return RedirectToAction("index", "orders");
        //    }
        //    var orderDetails = db.OrderDetails.Where(d => d.OrderId == orderId).OrderBy(d => d.Id).ToList();
        //    if (orderDetails == null)
        //    {
        //        orderDetails = new List<OrderDetail>();
        //    }
        //    return View(orderDetails);
        //}

        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create(int orderId)
        {
            var model = new OrderDetail();
            model.OrderId = orderId;
            return View(model);
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,OrderId,ItemName,ItemPrice,Quantity")] OrderDetail orderDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.OrderDetails.Add(orderDetail);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(orderDetail);
        //}
        public ActionResult Create([Bind(Include = "Id,OrderId,ItemName,ItemPrice,Quantity")] OrderDetail model)
        {
            OrderDetail detail = new OrderDetail();
            if (ModelState.IsValid)
            {
                var order = db.Orders.Single(d => d.Id == model.OrderId);
                detail = new OrderDetail()
                {
                    OrderId = model.OrderId,
                    ItemName = model.ItemName,
                    Quantity = model.Quantity,
                    ItemPrice = model.ItemPrice
                };
                order.OrderDetails.Add(detail);

                db.SaveChanges();

                return RedirectToAction("details", "orders", new { id = model.OrderId });
            }
            return View(model);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,ItemName,ItemPrice,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("details", "orders", new { id = orderDetail.OrderId });
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("details", "orders", new { id = orderDetail.OrderId });
        }

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
