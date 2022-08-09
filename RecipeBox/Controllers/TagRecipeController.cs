using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
{
  public class TagRecipeController : Controller
  {
    private readonly RecipeBoxContext _db;

    public TagRecipeController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Tags and Recipes";
      List<TagRecipe> model = _db.TagRecipe.ToList();
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(TagRecipe tagrecipe)
    {
      if (_db.TagRecipe.FirstOrDefault(
              tr => tr.RecipeId == tagrecipe.RecipeId && 
                    tr.TagId == tagrecipe.TagId) == null)
      {
        _db.TagRecipe.Add(tagrecipe);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}

