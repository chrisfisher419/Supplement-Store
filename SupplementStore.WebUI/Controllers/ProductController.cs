using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SupplementStore.Domain.Abstract;
using SupplementStore.Domain.Entities;
using SupplementStore.WebUI.Models;

namespace SupplementStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }


        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() : 
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult ViewDetails(int id = 0)
        {
            if (id == 0)
            {
                int page = (int)Session["page"];
                string category = (string)Session["category"];
                ProductsListViewModel viewModel = new ProductsListViewModel
                {
                    Products = repository.Products
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                            repository.Products.Count() :
                            repository.Products.Where(e => e.Category == category).Count()
                    },
                    CurrentCategory = category
                };
                return View("List", viewModel);
            }

            Product product = repository.Products.Where(x => x.ProductID == id).FirstOrDefault();
            ProductViewModel model = new ProductViewModel();
            model.Name = product.Name;
            model.Category = product.Category;
            model.Description = product.Description;
            model.Price = product.Price;
            return View(model);
        }
    }
}