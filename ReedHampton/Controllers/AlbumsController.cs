using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReedHampton.Models;
using System.IO;

namespace ReedHampton.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //INDEX REDIRECT
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("AlbumGallery");
        }

        // GET: Albums
        [AllowAnonymous]
        public ActionResult AlbumGallery()
        {
            return View(db.Albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            var model = new AlbumViewModel();
            return View(model);
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumViewModel model)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (model.AlbumThumbnailUpload == null || model.AlbumThumbnailUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ThumbnailUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.AlbumThumbnailUpload.ContentType))
            {
                ModelState.AddModelError("ThumbnailUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                var albumToAdd = new Album();

                albumToAdd.Name = model.Name;
                albumToAdd.Description = model.Description;
                albumToAdd.IsPublic = model.IsPublic;
                albumToAdd.CreatedDate = DateTime.Now;

                if (model.AlbumThumbnailUpload != null && model.AlbumThumbnailUpload.ContentLength > 0)
                {
                    var uploadDir = "~/ImageUploads/AlbumThumbnailUploads";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.AlbumThumbnailUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.AlbumThumbnailUpload.FileName);

                        imageUrl = imageUrl.Replace(@"\" , "/");
                        imagePath = imagePath.Replace(@"\", "/");
                      
                    model.AlbumThumbnailUpload.SaveAs(imagePath);
                    albumToAdd.AlbumThumbnailUrl = imageUrl;
                }

                db.Albums.Add(albumToAdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsPublic,CreatedDate,AlbumThumbnailUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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


        protected void jumbotronOnClickTransfer(object sender, EventArgs e)
        {
            Response.Redirect(Url.RouteUrl(new { controller = "Images", action = "Albums" }));
        }
    }
}
