using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntroAPI.EF;
using IntroAPI.DTOs;

namespace IntroAPI.Controllers
{
    public class ProductsController : ApiController
    {
        LabTaskEntities db = new LabTaskEntities();

        List<ProductsDTO> Convert(List<Product> prod)
        {
            var list = new List<ProductsDTO>();
            foreach (var item in prod)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        Product Convert(ProductsDTO p)
        {
            return new Product
            {
                id = p.id,
                productName = p.productName,
                productPrice = p.productPrice
            };
        }
        ProductsDTO Convert(Product p)
        {
            return new ProductsDTO
            {
                id = p.id,
                productName = p.productName,
                productPrice = p.productPrice
            };
        }

        [HttpGet]
        [Route("api/products/all")]
        public HttpResponseMessage GetAllProducts()
        {
            var data = db.Products.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }
        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage GetProduct(int id)
        {
            var data = db.Products.Find(id);
            var conv = Convert(data);
            return Request.CreateResponse(HttpStatusCode.OK, conv);

        }
        [HttpPost]
        [Route("api/products/create")]
        public HttpResponseMessage CreateProduct(ProductsDTO d)
        {
            var data = Convert(d);
            db.Products.Add(data);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpPost]
        [Route("api/products/update/{id}")]
        public HttpResponseMessage UpdateProduct(int id, ProductsDTO p)
        {
            var existingProduct = db.Products.Find(id);
            if (existingProduct == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            existingProduct.productName = p.productName;
            existingProduct.productPrice = p.productPrice;

            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/products/delete/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            var existingProduct = db.Products.Find(id);
            if (existingProduct == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
