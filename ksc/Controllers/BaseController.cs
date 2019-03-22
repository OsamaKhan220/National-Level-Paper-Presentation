using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ksc.Models;

namespace ksc.Controllers
{
    public class BaseController : Controller
    {
        protected KSCEntities db = new KSCEntities();
    }
}