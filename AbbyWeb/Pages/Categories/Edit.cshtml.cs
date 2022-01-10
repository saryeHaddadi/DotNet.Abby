using AbbyWeb.Data;
using AbbyWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]
public class EditModel : PageModel
{
	private readonly ApplicationDbContext _db;
	public Category Category { get; set; }

	public EditModel(ApplicationDbContext db)
	{
		_db = db;
	}

	public void OnGet(int id)
    {
		// Lecturer: I prefer Find or FirstOrDefault
		Category = _db.Category.Find(id);
		//Category = _db.Category.FirstOrDefault(c => c.Id == id);
		//Category = _db.Category.SingleOrDefault(c => c.Id == id);
		//Category = _db.Category.Where(c => c.Id == id).FirstOrDefault();
	}

	public async Task<IActionResult> OnPost()
	{
		if(Category.Name == Category.DisplayOrder.ToString())
		{
			ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name."); ;
		}
		if(ModelState.IsValid)
		{
			_db.Category.Update(Category);
			await _db.SaveChangesAsync();
			TempData["success"] = "Category edited successfully";
			return RedirectToPage("Index");
		}

		return Page();
	}
}

