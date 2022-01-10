using AbbyWeb.Data;
using AbbyWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]
public class DeleteModel : PageModel
{
	private readonly ApplicationDbContext _db;
	public Category Category { get; set; }

	public DeleteModel(ApplicationDbContext db)
	{
		_db = db;
	}

	public void OnGet(int id)
    {
		Category = _db.Category.FirstOrDefault(c => c.Id == id);
	}

	public async Task<IActionResult> OnPost()
	{
		_db.Category.Remove(Category);
		await _db.SaveChangesAsync();
		return RedirectToPage("Index");
	}
}

