﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Data.Entity.Validation;

namespace Mvc.Controllers
{
    public class UserController : Controller
    {
        private vendrEntities ent = new vendrEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = ent.Users;
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = ent.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserUsername,UserPassword,UserEmail,UserSalt,UserRegisterDate,UserLastLoginDate")] User user)
        {
            if (ModelState.IsValid)
            {
                ent.Users.Add(user);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = ent.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            //ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Rolename", user.RoleID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserUsername,UserPassword,UserEmail,UserSalt,UserRegisterDate,UserLastLoginDate,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                User modUser = ent.Users.Where(u => u.UserID == user.UserID).FirstOrDefault();
                modUser.UserUsername = user.UserUsername;
                ent.Entry(modUser).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    ent.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {

                    throw;
                }
                return RedirectToAction("Index", "Manage");
            }
            //ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Rolename", user.RoleID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = ent.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = ent.Users.Find(id);
            ent.Users.Remove(user);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ent.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
