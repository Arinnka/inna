using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_5_6.Models;

namespace lab_5_6.Controllers
{
    public class HomeController : Controller
    {
        private bazaEntities3 db = new bazaEntities3();
        // GET: Home
        public ActionResult Index()
        {
            var Order = (from order in db.Order select order).ToList();
            return View(Order);
        }

        // GET: Home/Details/5
       [Authorize(Roles = "moderator, admin")]
        public ActionResult Details(int id)
        {
            var orderDet = (from news in db.Order where news.Id == id select news).First();
            return View(orderDet);
        }

        // GET: Home/DetailsFlower
          [Authorize(Roles = "moderator, admin")]
        public ActionResult DetailsFlower()
        {
            var FlowerDet = (from flower in db.Flower select flower).ToList();
            return View(FlowerDet);
        }

        // GET: Home/DetailsStock
        public ActionResult DetailsStock()
        {
            var StockDet = (from stosk in db.Stock select stosk).ToList();
            return View(StockDet);
        }
        // GET: Home/DetailsCheckman
        public ActionResult DetailsCheckman()
        {
            var CheckmanDet = (from checkman in db.Checkman select checkman).ToList();
            return View(CheckmanDet);
        }

        // GET: Home/DetailsTable
            [Authorize(Roles = "moderator, admin, user")]
        public ActionResult DetailsTable()
        {
            var TableDet = (from table in db.Table select table).ToList();
            return View(TableDet);
        }

        // GET: Home/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            Order order_new = new Order();
            return View(order_new);
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Order order_new)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Order.Add(order_new);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            return View(order_new);
        }

        // GET: Home/CreateFlower
        [Authorize(Roles = "admin")]
        public ActionResult CreateFlower()
        {
            Flower flower_new = new Flower();
            return View(flower_new);
        }

        // POST: Home/CreateFlower
        [HttpPost]
        public ActionResult CreateFlower(Flower flower_new)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Flower.Add(flower_new);
                    db.SaveChanges();
                    return RedirectToAction("DetailsFlower");
                }
            }
            catch
            {

            }
            return View(flower_new);
        }

        // GET: Home/CreateStock
        [Authorize(Roles = "admin")]
        public ActionResult CreateStock()
        {
            Stock stock_new = new Stock();
            return View(stock_new);
        }

        // POST: Home/CreateStock
        [HttpPost]
        public ActionResult CreateStock(Stock stock_new)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Stock.Add(stock_new);
                    db.SaveChanges();
                    return RedirectToAction("DetailsStock");
                }
            }
            catch
            {

            }
            return View(stock_new);
        }

        // GET: Home/CreateCheckman
        [Authorize(Roles = "admin")]
        public ActionResult CreateCheckman()
        {
            Checkman Checkman_new = new Checkman();
            return View(Checkman_new);
        }

        // POST: Home/CreateCheckman
        [HttpPost]
        public ActionResult CreateCheckman(Checkman Checkman_new)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Checkman.Add(Checkman_new);
                    db.SaveChanges();
                    return RedirectToAction("DetailsCheckman");
                }
            }
            catch
            {

            }
            return View(Checkman_new);
        }

       
        // GET: Home/CreateTable
        [Authorize(Roles = "user")]
        public ActionResult CreateTable()
        {
            Table Table_new = new Table();
            return View(Table_new);
        }

        // POST: Home/CreateTable
        [HttpPost]
        public ActionResult CreateTable(Table Table_new)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Table.Add(Table_new);
                    db.SaveChanges();
                    return RedirectToAction("DetailsTable");
                }
            }
            catch
            {

            }
            return View(Table_new);
        }

        // GET: Home/CreateTable
        [Authorize(Roles = "user")]
        public ActionResult CreateTable1()
        {
            Table Table_new1 = new Table();
            Table_new1.volume = "-";
            return View(Table_new1);
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult CreateTable1(Table Table_new1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Table.Add(Table_new1);
                    db.SaveChanges();
                    return RedirectToAction("DetailsTable");
                }
            }
            catch
            {

            }
            return View(Table_new1);
        }
        // GET: Home/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var OrderEdit = (from Order in db.Order where Order.Id == id select Order).First();
            return View(OrderEdit);
        }

        // POST: Home/Edit/5


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var OrderEdit = (from Order in db.Order where Order.Id == id select Order).First();
            try
            {

                UpdateModel(OrderEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(OrderEdit);
            }
        }
        // GET: Home/Edit1/5
        [Authorize(Roles = "moderator")]
        public ActionResult Edit1(int id)
        {
            var OrderEdit1 = (from Order in db.Order where Order.Id == id select Order).First();
            return View(OrderEdit1);
        }

        // POST: Home/Edit1/5


        [HttpPost]
        public ActionResult Edit1(int id, FormCollection collection)
        {
            var OrderEdit1 = (from Order in db.Order where Order.Id == id select Order).First();
            try
            {

                UpdateModel(OrderEdit1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(OrderEdit1);
            }
        }
        // GET: Home/EditCheckman/5
        [Authorize(Roles = "admin, moderator")]
        public ActionResult EditCheckman(string Name)
        {
            var CheckmanEdit = (from Checkman in db.Checkman where Checkman.Name == Name select Checkman).First();
            return View(CheckmanEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult EditCheckman(string Name, FormCollection collection)
        {
            var CheckmanEdit = (from Checkman in db.Checkman where Checkman.Name == Name select Checkman).First();
            try
            {

                UpdateModel(CheckmanEdit);
                db.SaveChanges();
                return RedirectToAction("DetailsCheckman");
            }
            catch
            {
                return View(CheckmanEdit);
            }
        }

      
        // GET: Home/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var orderDell = (from Order in db.Order where Order.Id == id select Order).First();
            return View(orderDell);
        }

        // POST: Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {
                db.Order.Remove((from Order in db.Order where Order.Id == id select Order).First());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/DeleteFlower/5
        [Authorize(Roles = "admin")]
        public ActionResult DeleteFlower(String Name)
        {
            var FlowerDell = (from Flower in db.Flower where Flower.Name == Name select Flower).First();
            return View(FlowerDell);
        }

        // POST: Home/DeleteFlower/5

        [HttpPost]
        public ActionResult DeleteFlower(String Name, FormCollection collection)
        {

            try
            {
                db.Flower.Remove((from Flower in db.Flower where Flower.Name == Name select Flower).First());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/DeleteStock/5
        [Authorize(Roles = "admin")]
        public ActionResult DeleteStock(int id)
        {
            var StockDell = (from Stock in db.Stock where Stock.Id == id select Stock).First();
            return View(StockDell);
        }

        // POST: Home/DeleteStock/5

        [HttpPost]
        public ActionResult DeleteStock(int id, FormCollection collection)
        {

            try
            {
                db.Stock.Remove((from Stock in db.Stock where Stock.Id == id select Stock).First());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/DeleteTable/5
        [Authorize(Roles = "admin")]
        public ActionResult DeleteTable(int id)
        {
            var TableDell = (from Table in db.Table where Table.Id == id select Table).First();
            return View(TableDell);
        }

        // POST: Home/DeleteTable/5

        [HttpPost]
        public ActionResult DeleteTable(int id, FormCollection collection)
        {

            try
            {
                db.Table.Remove((from Table in db.Table where Table.Id == id select Table).First());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
