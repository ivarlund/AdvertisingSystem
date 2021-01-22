using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertisingSystem.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using AdvertisingSystem.Helper;
using System.Net.Http;
using System.Text;
using AdvertisingSystem.ViewModels;

namespace AdvertisingSystem.Controllers
{
    public class AdvertisersController : Controller
    {
        private readonly AdvertisingDBContext _context;
        private APIHelper _api = new APIHelper();

        public AdvertisersController(AdvertisingDBContext context)
        {
            _context = context;
        }

        // GET: Advertisers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Advertisers.ToListAsync());
        }

        // GET: Advertisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertiser = await _context.Advertisers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertiser == null)
            {
                return NotFound();
            }

            return View(advertiser);
        }

        // GET: Advertisers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subscriber,OrgNo,Name,PhoneNo,Adress,ZipCode,City,BillingAdress")] Advertiser advertiser)
        {
            if (ModelState.IsValid)
            {
                if (advertiser.Subscriber != null)
                {
                    HttpClient client = _api.Initial();
                    HttpResponseMessage response = await client.GetAsync("api/subscribers/" + advertiser.Subscriber);

                    if (response.IsSuccessStatusCode)
                    {
                        if (!SubscriberExists(advertiser.Subscriber))
                        {
                            _context.Add(advertiser);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            advertiser = await _context.Advertisers.FirstOrDefaultAsync(m => m.Subscriber == advertiser.Subscriber);
                        }

                        var result = response.Content.ReadAsStringAsync().Result;
                        Subscriber subscriber = JsonConvert.DeserializeObject<Subscriber>(result);

                        string sub = JsonConvert.SerializeObject(subscriber);
                        HttpContext.Session.SetString("subscriber", sub);

                        string subPubId = JsonConvert.SerializeObject(advertiser.Id);
                        HttpContext.Session.SetString("publicist", subPubId);

                        return RedirectToAction("EditSub");
                    } 
                    else
                    {
                        ViewBag.NotFound = "No subscriber by that Id";
                        return View();
                    }
                }

                if (!CompanyExists(advertiser.OrgNo))
                {
                    _context.Add(advertiser);
                    await _context.SaveChangesAsync();
                }
                else 
                {
                    advertiser = await _context.Advertisers.FirstOrDefaultAsync(m => m.OrgNo == advertiser.OrgNo);
                }

                string coPubId = JsonConvert.SerializeObject(advertiser.Id);
                HttpContext.Session.SetString("publicist", coPubId);

                return RedirectToAction("Create", "Ads");
            }
            return View(advertiser);
        }

        [HttpGet]
        public IActionResult EditSub()
        {
            string session = HttpContext.Session.GetString("subscriber");
            Subscriber subscriber = JsonConvert.DeserializeObject<Subscriber>(session);
            return View(subscriber);
        }

        [HttpPost]
        public async Task<IActionResult> EditSub(Subscriber subscriber)
        {
            string session = HttpContext.Session.GetString("subscriber");
            Subscriber initialSubscriber = JsonConvert.DeserializeObject<Subscriber>(session);

            if (subscriber != initialSubscriber)
            {
                HttpClient client = _api.Initial();
                StringContent content = new StringContent(JsonConvert.SerializeObject(subscriber), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("api/subscribers/" + subscriber.Id, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    subscriber = JsonConvert.DeserializeObject<Subscriber>(result);
                    string sub = JsonConvert.SerializeObject(subscriber);
                    HttpContext.Session.SetString("subscriber", sub);

                    return RedirectToAction("Create", "Ads");
                }
            }
            else if (subscriber == initialSubscriber)
            {
                return RedirectToAction("Create", "Ads");
            }

            return View(subscriber);
        }

        // GET: Advertisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertiser = await _context.Advertisers.FindAsync(id);
            if (advertiser == null)
            {
                return NotFound();
            }
            return View(advertiser);
        }

        // POST: Advertisers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subscriber,OrgNo,Name,PhoneNo,Adress,ZipCode,City")] Advertiser advertiser)
        {
            if (id != advertiser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertiser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertiserExists(advertiser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(advertiser);
        }

        // GET: Advertisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertiser = await _context.Advertisers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertiser == null)
            {
                return NotFound();
            }

            return View(advertiser);
        }

        // POST: Advertisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertiser = await _context.Advertisers.FindAsync(id);
            _context.Advertisers.Remove(advertiser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertiserExists(int id)
        {
            return _context.Advertisers.Any(e => e.Id == id);
        }

        private bool CompanyExists(int? orgNo)
        {
            return _context.Advertisers.Any(e => e.OrgNo == orgNo);
        }

        private bool SubscriberExists(int? subId)
        {
            return _context.Advertisers.Any(e => e.Subscriber == subId);
        }
    }
}
