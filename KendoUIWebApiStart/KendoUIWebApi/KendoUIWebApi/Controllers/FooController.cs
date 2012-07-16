using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using KendoUIWebApi.Models;

namespace KendoUIWebApi.Controllers
{
    public class FooController : ApiController
    {
        private KendoUIWebApiContext db = new KendoUIWebApiContext();

        // GET api/Foo
        public IEnumerable<Foo> GetFoos()
        {
            return db.Foos.AsEnumerable();
        }

        // GET api/Foo/5
        public Foo GetFoo(int id)
        {
            Foo foo = db.Foos.Find(id);
            if (foo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return foo;
        }

        // PUT api/Foo/5
        public HttpResponseMessage PutFoo(int id, Foo foo)
        {
            if (ModelState.IsValid && id == foo.Id)
            {
                db.Entry(foo).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, foo);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Foo
        public HttpResponseMessage PostFoo(Foo foo)
        {
            if (ModelState.IsValid)
            {
                db.Foos.Add(foo);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, foo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = foo.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Foo/5
        public HttpResponseMessage DeleteFoo(int id)
        {
            Foo foo = db.Foos.Find(id);
            if (foo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Foos.Remove(foo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, foo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}