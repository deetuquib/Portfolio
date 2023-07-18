using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    [EnableCors]
    [Route("[controller]")]
    [ApiController]
    public class RestaurantReviewController : Controller
    {

        // GET: RestaurantReviewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantReviewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
