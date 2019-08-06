using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlmotahidaTask.Models;

namespace AlmotahidaTask.Controllers
{
  public class OrderController : Controller
  {
    // GET: Order
    public ActionResult Index()
    {
      return View();
    }

    // GET: Order/Details/5
    public ActionResult Order(int? id)
    {
      var db = new AlmotahedaTaskDBEntities();
      var tblSalesHeader = (from a in db.tblSalesHeaders
                            where a.gISerial == id
                            select a).FirstOrDefault();

      var tblSalesDetails = (from a in db.tblSalesDetails
                            where a.tblSalesHeader == id
                            select a).ToList();

      var model = new SalesDetailViewModel { _tblSalesHeader = tblSalesHeader, _tblSalesDetail = tblSalesDetails };
      return View(model);
    }

    // GET: Order/Create
    public ActionResult Create()
    {
      var model = new SalesDetailViewModel();
      return View(model);
    }

    // POST: Order/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Order/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Order/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Order/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Order/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
