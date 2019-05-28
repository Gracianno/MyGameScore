using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyGameScore.Models;

namespace MyGameScore.Controllers
{
    public class GameScoresController : Controller
    {
        private readonly MyGameScoreContext _context;

        public GameScoresController(MyGameScoreContext context)
        {
            _context = context;
        }

        // GET: GameScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameScore.ToListAsync());
        }

        // GET: GameScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameScore = await _context.GameScore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameScore == null)
            {
                return NotFound();
            }

            return View(gameScore);
        }

        // GET: GameScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,score,date")] GameScore gameScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameScore);
        }

        // GET: GameScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameScore = await _context.GameScore.FindAsync(id);
            if (gameScore == null)
            {
                return NotFound();
            }
            return View(gameScore);
        }

        // POST: GameScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,score,date")] GameScore gameScore)
        {
            if (id != gameScore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameScoreExists(gameScore.Id))
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
            return View(gameScore);
        }

        // GET: GameScores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameScore = await _context.GameScore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameScore == null)
            {
                return NotFound();
            }

            return View(gameScore);
        }

        // POST: GameScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameScore = await _context.GameScore.FindAsync(id);
            _context.GameScore.Remove(gameScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameScoreExists(int id)
        {
            return _context.GameScore.Any(e => e.Id == id);
        }
    }
}
