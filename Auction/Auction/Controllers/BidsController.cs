using Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Auction.Views.Bids;

namespace Auction.Controllers
{
    public class BidsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Bids
        public ActionResult Index()
        {
            var items = _db.Items.Include(i => i.Bids).ToList();

            return View(items);
        }
        public ActionResult Bid(int id)
        {
            var item = _db.Items.Where(i => i.Id == id).Include(i => i.Bids).FirstOrDefault();
            var bidVM = new BidVM
            {
                Bids = item.Bids.ToList(),
                Bid = new Bid
                {
                    ItemId = item.Id
                }
            };


            return View(bidVM);
        }
        [HttpPost]
        public ActionResult Bid(BidVM peanutbutter)
        {

            if (ModelState.IsValid) {
                //               bid.Bid.ItemId = id;
                _db.Bids.Add(peanutbutter.Bid);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }
        // GET: Bids/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bids/Create
        [HttpPost]

        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid) {

                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Bids/Edit/5
        public ActionResult Edit(int id)
        {
            var original = _db.Items.Find(id);
            return View(original);
        }

        // POST: Bids/Edit/5
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid) {
                var original = _db.Items.Find(item.Id);
                original.Name = item.Name;
                original.Description = item.Description;
                original.MinimumBid = item.MinimumBid;
                original.NumOfBids = item.NumOfBids;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Bids/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bids/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
