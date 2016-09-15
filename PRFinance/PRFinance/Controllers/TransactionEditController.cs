using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRFinance.Models;

namespace PRFinance.Controllers
{
    public class TransactionEditController : Controller
    {
        private TransactionDBContext db = new TransactionDBContext();

        // GET: /TransactionEdit/
        public ActionResult Index(CategoryEnum CategoryList = CategoryEnum.All)
        {
            var transactions = from m in db.Transactions 
                                              select m;

            var categoryList = new List<string>();
            foreach(var str in Enum.GetValues(typeof(CategoryEnum)))
            {
                categoryList.Add(((CategoryEnum)str).ToString());
            }
            ViewBag.CategoryList = new SelectList(categoryList);
            if (CategoryList != CategoryEnum.All)
            {

                transactions = transactions.Where(s => s.Category == CategoryList);
            }
            return View(transactions);
        }

        // GET: /TransactionEdit/
        public ActionResult Index2(CategoryEnum CategoryList = CategoryEnum.All)
        {
            var transactions = from m in db.Transactions
                               select m;

            var categoryList = new List<string>();
            foreach (var str in Enum.GetValues(typeof(CategoryEnum)))
            {
                categoryList.Add(((CategoryEnum)str).ToString());
            }
            ViewBag.CategoryList = new SelectList(categoryList);
            if (CategoryList != CategoryEnum.All)
            {

                transactions = transactions.Where(s => s.Category == CategoryList);
            }
            return View(transactions);
        }

        // GET: /TransactionEdit/
        public ActionResult Index3(CategoryEnum CategoryList = CategoryEnum.All)
        {
            var transactions = from m in db.Transactions
                               select m;

            var categoryList = new List<string>();
            foreach (var str in Enum.GetValues(typeof(CategoryEnum)))
            {
                categoryList.Add(((CategoryEnum)str).ToString());
            }
            ViewBag.CategoryList = new SelectList(categoryList);
            if (CategoryList != CategoryEnum.All)
            {

                transactions = transactions.Where(s => s.Category == CategoryList);
            }
            return View(transactions);
        }

        // GET: /TransactionEdit/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: /TransactionEdit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TransactionEdit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="date,Category,Expense,Comment")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.ID = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index3");
            }

            return View(transaction);
        }

        // GET: /TransactionEdit/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: /TransactionEdit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,date,Category,Expense,Comment")] Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transaction).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }
            catch { }
            return RedirectToAction("Index3");
        }

        // GET: /TransactionEdit/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: /TransactionEdit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
