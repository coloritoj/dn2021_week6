using Microsoft.AspNetCore.Mvc;
using MVCDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo2.Controllers
{
    // New view: Do NOT choose the empty one
    // New controller: DO choose the empty one. Make sure to include the name Controller with a capital C as in: ShopController.cs
    // To access this controller on the webpage it would be <webpage>/shop/xxx
    // Before we had <webpage>/home/xxx

    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // This will be /shop/addproductform ... It will show the product form
        // This is called a route
        public IActionResult AddProductForm()
        {
            return View();
        }

        // This will be /shop/addproduct ... It will add product after form is submitted
        [HttpPost]
        public IActionResult AddProduct(Item theItem) // Make sure to add the using statement. Click the dropdown lightbulb thing to add it. The main controller has it, but this one doesn't by default.
            // Doing what you see in the line above creates a new instance of an Item for us when you pass the information into the fields. Jeff really likes this feature. There's basically "fancy stuff" going on behind the scenes for that to work.
        {
            // This is where we would add the item to the database. We aren't doing this today.
            // For now, we are just going to display the information.
            Item.Items.Add(theItem); // Now we are doing this with a list.

            return Redirect("/");
        }

        public IActionResult DeleteItem(int id) // This is a coincidence that it's called id. I don't think it's necessarily related to the "id" we created in Item.cs.
        {
            Item found = null;
            foreach (Item current in Item.Items)
            {
                if (current.id == id)
                {
                    found = current;
                }
            }
            if (found != null)
            {
                Item.Items.Remove(found);
            }

            return Redirect("/home/index"); // Alternatively could say return Redirect("/") - This will also take you back to home.
            // What this is basically doing is going back to/refreshing the page. It just kinda looks like nothing is happening to the naked eye.
        }

        public IActionResult EditProductForm(int id) // Again, this is just a coincidence it's called id. It will always be called id within the function.
        {
            Item found = null;
            foreach (Item current in Item.Items)
            {
                if (current.id == id)
                {
                    found = current;
                }
            }

            if (found != null)
            {
                return View(found);
            }
            else
            {
                return Redirect("/"); // This means redirect to the home page
            }
        }

        public IActionResult EditProduct(Item theItem)
        {
            foreach (Item current in Item.Items)
            {
                if (current.id == theItem.id)
                {
                    current.Name = theItem.Name;
                    current.Price = theItem.Price;
                    break;
                }
            }
            return Redirect("/");
        }
    }
}

