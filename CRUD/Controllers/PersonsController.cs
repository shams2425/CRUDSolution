using CRUD.EF;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class PersonsController : Controller
{
    private readonly ApplicationDbContext _db;
    public PersonsController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Person> person = _db.Persons.ToList();
        
        return View(person);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        _db.Persons.Add(person);
        _db.SaveChanges();
        return RedirectToAction("Index");
        
    }

    public IActionResult Update(int id)
    {
        var edit = _db.Persons.Find(id);
        return View(edit);
    }

    [HttpPost]
    public IActionResult Update(Person person)
    {
        _db.Persons.Update(person);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var delete = _db.Persons.Find(id);
        return View("DeleteConfirm",delete);
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int id) 
    {
        var deleteConfirm = _db.Persons.Find(id);
        _db.Persons.Remove(deleteConfirm);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
