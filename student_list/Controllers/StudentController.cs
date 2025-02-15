using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_list.Data;
using student_list.Models;

namespace student_list.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var student = await _dbContext.Students.ToListAsync();
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name", "Program", "Year", "Section", "Status", "School", "Age", "Gender", "Email", "Phone", "Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(student);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePermanently(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind("Id", "Name", "Program", "Year", "Section", "Status", "School", "Age", "Gender", "Email", "Phone", "Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Update(student);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
