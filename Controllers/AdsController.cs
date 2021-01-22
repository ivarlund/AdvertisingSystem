using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertisingSystem.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AdvertisingSystem.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdvertisingDBContext _context;

        public AdsController(AdvertisingDBContext context)
        {
            _context = context;
        }

        // GET: Ads
        public async Task<IActionResult> Index()
        {
            var ads = _context.Ads.Include(a => a.Advertiser);
            return View(await ads.ToListAsync());
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.Advertiser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,ItemPrice,AdPrice,Publicist")] Ad ad)
        {

            if (ModelState.IsValid)
            {
                string publicist = HttpContext.Session.GetString("publicist");
                int advertiserId = Convert.ToInt32(JsonConvert.DeserializeObject(publicist));
                ad.Publicist = advertiserId;

                var advertiser = await _context.Advertisers.FirstOrDefaultAsync(a => a.Id == ad.Publicist);
                if (advertiser.Subscriber != null)
                {
                    ad.AdPrice = 0;
                }
                else
                {
                    ad.AdPrice = 40;
                }

                _context.Add(ad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            ViewData["Publicist"] = new SelectList(_context.Advertisers, "Id", "Id", ad.Publicist);
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,ItemPrice,AdPrice,Publicist")] Ad ad)
        {
            if (id != ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.Id))
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
            ViewData["Publicist"] = new SelectList(_context.Advertisers, "Id", "Id", ad.Publicist);
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.Advertiser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
