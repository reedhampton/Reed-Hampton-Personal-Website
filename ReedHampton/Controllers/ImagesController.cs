using ReedHampton.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ReedHampton.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //INDEX REDIRECT
        public ActionResult Index()
        {
            return RedirectToAction("Albums");
        }
        // GET: Images
        [AllowAnonymous]
        public async System.Threading.Tasks.Task<ActionResult> Albums()
        {
            return View(await db.Images.ToListAsync());
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            var albums = GetAllAlbums();

            var model = new ImageViewModel();

            model.Albums = GetSelectListItems(albums);

            return View(model);
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageViewModel model)
        {
            var albums = GetAllAlbums();

            model.Albums = GetSelectListItems(albums);

            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                var AlbumChosen = GetAlbumId(model.AlbumName);

                var image = new Image
                {
                    Title = model.Title,
                    AltText = model.AltText,
                    Caption = model.Caption,
                    CreatedDate = DateTime.Now,
                    AlbumId = AlbumChosen.Id
                };

                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/ImageUploads";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    image.ImageUrl = imageUrl;
                }

                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlbumId,Title,AltText,Caption,ImageUrl,CreatedDate")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //GET ALL ALBUM NAMES-------------------------------------------------------------------------------------------------------------------------

        private IEnumerable<string> GetAllAlbums()
        {
            List<string> toReturn = new List<string>();

            var Albums = db.Albums.ToList();

            foreach (Album  a in Albums)
            {
                toReturn.Add(a.Name);
            }

            return toReturn;
        }

        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        private Album GetAlbumId(string AlbumName)
        {
            var albumChosenList = (from d in db.Albums where d.Name == AlbumName select d).ToList();

            Album albumChosen = albumChosenList.First();

            return albumChosen;
        }
    }
}
