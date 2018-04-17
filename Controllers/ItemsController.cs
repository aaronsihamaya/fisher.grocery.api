using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.GroceryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Fisher.GroceryApi.Data;


namespace Fisher.GroceryApi.Controllers
{
    [Route("api/[controller]")]
    public class GroceryItemsController : Controller
    {
private readonly BookstoreContext db;

public GroceryItemsController(BookstoreContext db)
{
    this.db = db;

    if (this.db.GroceryItems.Count() == 0)
    {
        this.db.GroceryItems.Add(new Item {
            Id = 1,
            Name = "Milk",
            Brand = "Horizons",
            PurchaseDate = DateTime.Parse("11/23/2010"),
            ExpirationDate = DateTime.Parse("12/23/2010"),
            Notes = "Need for cereal"

        });

        this.db.GroceryItems.Add(new Item
        {
            Id = 2,
            Name = "Eggs",
            Brand = "Kroger",
            PurchaseDate = DateTime.Parse("12/23/2010"),
            ExpirationDate = DateTime.Parse("1/20/2011"),
            Notes = "Need for baking"
        });

        this.db.GroceryItems.Add(new Item
        {
            Id = 3,
            Name = "Frosted Flakes",
            Brand = "Kelloggs",
            PurchaseDate = DateTime.Parse("12/23/2010"),
            ExpirationDate = DateTime.Parse("1/22/2011"),
            Notes = "Need for milk"
        });


        this.db.GroceryItems.Add(new Item
        {
            Id = 4,
            Name = "Apples",
            Brand = "Gala",
            PurchaseDate = DateTime.Parse("11/23/2010"),
            ExpirationDate = DateTime.Parse("12/23/2010"),
            Notes = "Keep doctor away"
        });

        this.db.SaveChanges();
    }
}

[HttpGet]
public IActionResult GetAll()
{
    return Ok(db.GroceryItems);
}

[HttpGet("{id}", Name="GetItem")]

public IActionResult GetById(int id)
{
    var item = db.GroceryItems.Find(id);

    if(item == null)
    {
        return NotFound();
    }

    return Ok(item);
}

[HttpPost]

public IActionResult Post([FromBody]Item item)
{
    if(item == null)
    {
        return BadRequest();
    }

    this.db.GroceryItems.Add(item);
    this.db.SaveChanges();

    return CreatedAtRoute("GetItem", new { id = item.Id}, item);
}

[HttpPut("{id}")]

public IActionResult Put(int id, [FromBody]Item newItem)
{
    if (newItem == null || newItem.Id != id)
    {
        return BadRequest();
    }
    var currentItem = this.db.GroceryItems.FirstOrDefault(x => x.Id == id);

    if (currentItem == null)
    {
        return NotFound();
    }

    currentItem.Brand = newItem.Brand;
    currentItem.PurchaseDate = newItem.PurchaseDate;
    currentItem.ExpirationDate = newItem.ExpirationDate;

    this.db.GroceryItems.Update(currentItem);
    this.db.SaveChanges();

    return NoContent();
}

[HttpDelete("{id}")]

public IActionResult Delete(int id)
{
    var item = this.db.GroceryItems.FirstOrDefault(x => x.Id == id);

    if (item == null)
    {
        return NotFound();
    }

    this.db.GroceryItems.Remove(item);
    this.db.SaveChanges();

    return NoContent();
}

    }

}
