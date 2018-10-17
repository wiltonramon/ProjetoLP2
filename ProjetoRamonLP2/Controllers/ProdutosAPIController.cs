using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjetoRamonLP2.Models;

namespace ProjetoRamonLP2.Controllers
{
    public class ProdutosAPIController : ApiController
    {
        private ProdutoContainer db = new ProdutoContainer();

        // GET: api/ProdutosAPI
        public IQueryable<Produto> GetProdutoSet1()
        {
            return db.ProdutoSet1;
        }

        // GET: api/ProdutosAPI/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = db.ProdutoSet1.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/ProdutosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.Codigo)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProdutosAPI
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProdutoSet1.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.Codigo }, produto);
        }

        // DELETE: api/ProdutosAPI/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.ProdutoSet1.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.ProdutoSet1.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.ProdutoSet1.Count(e => e.Codigo == id) > 0;
        }
    }
}