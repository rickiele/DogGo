using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Repositories;
using DogGo.Models;

namespace DogGo.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _ownerRepo;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        // GET: Owners
        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();

            return View(owners);
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }


        /*You might notice...there are two Create methods! How can this be? Think about interactions we have in real life involving filling out forms. Doctors' visits comes to mind... 
        When you go to the doctor, you're likely to have 2 interactions with a person behind the counter. The first interaction is when you go to the receptionist and ask for a blank form. 
        The receptionist gives you the form so you can go back to your chair and fill it out. Once you're done, you can go back up to the counter and give that form back so they can process it. 
        This is the same sort of interaction end users have with a server. Notice the comments above the two Create methods--one says GET and the other says POST. When a user navigates to the url 
        /owners/create, they are making a GET request to that url. This is the request that will give the user the html of the empty form. When the user clicks a "submit" button, that is going to 
        make a POST request to the same url.*/

        // GET: OwnersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }

        // GET: Owners/Edit/5
        /* Once again, the controller will get an owner id from the url route (i.e /owner/edit/2). 
           We can use that Id to get the current data from the database and use it to fill out the initial state of the form.*/
        public ActionResult Edit(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Edit/5
        // This is similar to Create except we are updating the database instead of inserting into.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                _ownerRepo.UpdateOwner(owner);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }

        // GET: OwnersController/Delete/5
        /* The GET method assumes you'd like to create a view that asks the user to confirm the deletion. 
         * Notice that the GET method for Delete accepts an int id parameter.  ASP.NET will get this value from the route. i.e. 
           owners/delete/5 suggests that the user is attempting to delete the owner with Id of 5.*/
        public ActionResult Delete(int id)
        {
            // Need to get a certain ID to delete a specific Owner
            Owner owner = _ownerRepo.GetOwnerById(id);

            return View(owner);
        }

        // POST: OwnersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(owner);
            }
        }
    }
}