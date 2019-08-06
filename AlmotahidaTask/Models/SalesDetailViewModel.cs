using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmotahidaTask.Models
{
  public class SalesDetailViewModel
  {
    public tblSalesHeader _tblSalesHeader { get; set; }
    public List<tblSalesDetail> _tblSalesDetail { get; set;}
  }
}