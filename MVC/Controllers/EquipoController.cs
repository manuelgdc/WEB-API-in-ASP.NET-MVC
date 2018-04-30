using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            IEnumerable<mvcEquipo> equipoLista;
            HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("Equipoes").Result;
            equipoLista = response.Content.ReadAsAsync<IEnumerable<mvcEquipo>>().Result;
            return View(equipoLista);
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcEquipo());
            else
            {
                HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("Equipoes/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEquipo>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcEquipo emp)
        {
            if (emp.EmpleadoID == 0)
            {
                HttpResponseMessage response = GlobalVariables.httpClient.PostAsJsonAsync("Equipoes", emp).Result;
                TempData["SuccessMessage"] = "Guardado";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.httpClient.PutAsJsonAsync("Equipoes/" + emp.EmpleadoID, emp).Result;
                TempData["SuccessMessage"] = "Modificado";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.httpClient.DeleteAsync("Equipoes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado";
            return RedirectToAction("Index");
        }
    }
}