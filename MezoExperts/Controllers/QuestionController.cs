using MezoExperts.Filters;
using MezoExperts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MezoExperts.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class QuestionController : Controller
    {
        //
        // GET: /Question/
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Post()
        {
            return View();
        }

    }
}
