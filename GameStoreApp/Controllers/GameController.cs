using GameStoreApp.Data;
using GameStoreApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace GameStoreApp.Controllers
{
    public class GameController : Controller
    {

        private readonly ApplicationDbContext _db;

        public GameController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<GameEntry>objGameEntryList = _db.GameEntries.ToList();
            return View(objGameEntryList);  
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(GameEntry obj)
        {
            if(obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The Game Title is too short!");
            }
            if (ModelState.IsValid)
            {
                //Adds the entry to the database
                _db.GameEntries.Add(obj);

                //Saves the changes to the database
                _db.SaveChanges();

                //Redirects us to the main page
                return RedirectToAction("Index");
            }

            return View(obj);
        }




        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }


            GameEntry? gameEntry = _db.GameEntries.Find(id);

            if(gameEntry == null)
            {
                return NotFound();
            }
            
            
            return View(gameEntry);
        }

        
        
        [HttpPost]
        public IActionResult Edit(GameEntry obj)
        {

            if(obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The Game Title is too Short!");
            }
            if (ModelState.IsValid) 
            {
                //Updates the entry to the database
                _db.GameEntries.Update(obj);

                //Saves the changes to the database
                _db.SaveChanges();

                //Redirects us to the main page
                return RedirectToAction("Index");

            }

            return View(obj);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            GameEntry? gameEntry = _db.GameEntries.Find(id);

            if (gameEntry == null)
            {
                return NotFound();
            }

            return View(gameEntry);
        }

        [HttpPost]
        public IActionResult Delete(GameEntry obj)
        {

            //Deletes the entry from the database
            _db.GameEntries.Remove(obj);

            //Saves the changes to the database
            _db.SaveChanges();

            //Redirects us to the main page
            return RedirectToAction("Index");


        }



    }
}
