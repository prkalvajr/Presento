using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presento.Models;

namespace Presento.Controllers
{
    public class DUserController : Controller
    {
        private readonly UserDBContext _context;

        public DUserController(UserDBContext context)
        {
            _context = context;
        }

        // GET: DUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.DUsers.ToListAsync());
        }

        // GET: DUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVO = await _context.DUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userVO == null)
            {
                return NotFound();
            }

            return View(userVO);
        }

        // GET: DUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Name,Picture,LastLogin,Email,AuthType")] UserVO userVO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userVO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userVO);
        }

        // GET: DUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVO = await _context.DUsers.FindAsync(id);
            if (userVO == null)
            {
                return NotFound();
            }
            return View(userVO);
        }

        // POST: DUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Name,Picture,LastLogin,Email,AuthType")] UserVO userVO)
        {
            userVO.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userVO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserVOExists(userVO.Id))
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
            return View(userVO);
        }

        // GET: DUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVO = await _context.DUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userVO == null)
            {
                return NotFound();
            }

            return View(userVO);
        }

        // POST: DUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userVO = await _context.DUsers.FindAsync(id);
            _context.DUsers.Remove(userVO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserVOExists(int id)
        {
            return _context.DUsers.Any(e => e.Id == id);
        }
    }
}
