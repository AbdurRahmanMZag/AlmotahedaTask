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

    // POST: Order/InsertOrders
    [HttpPost]
    public JsonResult InsertOrders(SalesDetailViewModel order ,int? id )
    {
      tblSalesHeader salesHeader = order._tblSalesHeader;
      List<tblSalesDetail> salesDetails = order._tblSalesDetail;
      //var db = new AlmotahedaTaskDBEntities();
      //tblSalesHeader salesHeaderEntities = db.tblSalesHeaders.SingleOrDefault(s => s.gISerial == id);
      using(AlmotahedaTaskDBEntities entities = new AlmotahedaTaskDBEntities())
      {


        //Truncate Table to delete all old records.
        entities.Database.ExecuteSqlCommand(@"TRUNCATE TABLE [tblSalesHeader];
         TRUNCATE TABLE [tblSalesDetail");
        if(salesHeader == null)
        {
          salesHeader = new tblSalesHeader();
        }
        entities.tblSalesHeaders.Add(salesHeader);
        entities.SaveChanges();
        if(salesDetails == null)
        {
          salesDetails = new List<tblSalesDetail>();
        }
        //loop and insert records.
        foreach(tblSalesDetail salesDetail in salesDetails)
        {
          entities.tblSalesDetails.Add(salesDetail);
        }
        int insertedRecords = entities.SaveChanges();
        
        return Json(insertedRecords);
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
