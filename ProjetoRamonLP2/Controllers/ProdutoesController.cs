﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoRamonLP2.Models;

namespace ProjetoRamonLP2.Controllers
{
    public class ProdutoesController : Controller
    {
        private ProdutoContainer db = new ProdutoContainer();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produtoSet1 = db.ProdutoSet1.Include(p => p.Categoria);
            return View(produtoSet1.ToList());
        }

        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.ProdutoSet1.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaCodigoCategoria = new SelectList(db.CategoriaSet, "CodigoCategoria", "NomeCategoria");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,Preco,CategoriaCodigoCategoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoSet1.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaCodigoCategoria = new SelectList(db.CategoriaSet, "CodigoCategoria", "NomeCategoria", produto.CategoriaCodigoCategoria);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.ProdutoSet1.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaCodigoCategoria = new SelectList(db.CategoriaSet, "CodigoCategoria", "NomeCategoria", produto.CategoriaCodigoCategoria);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,Preco,CategoriaCodigoCategoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaCodigoCategoria = new SelectList(db.CategoriaSet, "CodigoCategoria", "NomeCategoria", produto.CategoriaCodigoCategoria);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.ProdutoSet1.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.ProdutoSet1.Find(id);
            db.ProdutoSet1.Remove(produto);
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
    }
}
