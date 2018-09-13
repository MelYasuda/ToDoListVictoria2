using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controllers
  {
    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult CreateForm(int categoryId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      return View(categoryId);
    }
    [HttpGet("/categories/{categoryId}/itemsd/{itemId}")]
    public ActionResult Details(int categoryId, int itemId)
    {
      Item item = Item.Find(itemId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      Model.Add("item", item);
      model.Add("category", category);
      return View(item);
    }
  }
}
