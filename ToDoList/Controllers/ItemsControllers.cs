using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
      [HttpGet("/items")]
      public ActionResult Index()
      {
          List<Item> allItems = Item.GetAll();
          return View(allItems);
      }

      [HttpGet("/items/new")]
      public ActionResult CreateForm()
      {
          return View();
      }

      [HttpPost("/items")]
      public ActionResult Create(string description, int categoryId)
      {
        Item newItem = new Item(description, categoryId);
        newItem.Save();
        List<Item> allItems = Item.GetAll();
        return RedirectToAction("Index");
      }

      [HttpGet("/items/{id}")]
      public ActionResult Details(int id)
      {
          Item item = Item.Find(id);
          return View(item);
      }

      [HttpGet("/items/{id}/update")]
      public ActionResult UpdateForm(int id)
      {
          Item thisItem = Item.Find(id);
          return View(thisItem);
      }

      [HttpPost("/items/{id}/update")]
      public ActionResult Update(int id, string newDescription)
      {
          Item thisItem = Item.Find(id);
          thisItem.Edit(newDescription);
          return RedirectToAction("Index");
      }

      [HttpPost("/items/delete")]
      public ActionResult DeleteAll()
      {
          Item.DeleteAll();
          return View();
      }
    }
}
