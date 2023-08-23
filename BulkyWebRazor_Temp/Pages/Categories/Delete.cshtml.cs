using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category? categoryFromDb = _db.Categories.Find(id);
                if (categoryFromDb != null)
                {
                    Category = categoryFromDb;
                }
            }
        }
        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null) { return NotFound(); }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["succes"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
