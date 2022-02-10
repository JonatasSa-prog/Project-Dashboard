using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Usuario usuario = null;

            try
            {
                usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                return View(usuario);
            }
            catch
            {
                
            }

            return Redirect($"{Url.Action("Index", "Login")}");
        }
    }
}
