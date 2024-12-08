﻿using LDBeauty.Core.Constants;
using LDBeauty.Core.Contracts;
using LDBeauty.Core.Helpers;
using LDBeauty.Core.Models;
using LDBeauty.Core.Models.Gallery;
using LDBeauty.Core.Models.Product;
using LDBeauty.Core.Models.User;
using LDBeauty.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LDBeauty.Controllers
{
    [Authorize]
    public class MyLdController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IGalleryService galleryService;
        private readonly ILogger<MyLdController> logger;

        public MyLdController(
            IUserService _userService,
            IOrderService _orderService,
            IProductService _productService,
            IGalleryService _galleryService,
            ILogger<MyLdController> _logger)
        {
            userService = _userService;
            orderService = _orderService;
            productService = _productService;
            galleryService = _galleryService;
            logger = _logger;
        }


        public async Task<IActionResult> Info()
        {
            var userName = User.Identity.Name;
            ApplicationUser user = null;
            List <UserProductsViewModel> products = null;

            try
            {
                user = await userService.GetUser(userName);
                products = await orderService.GetUserProducts(user.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "MyLdController/Info");
                return DatabaseError();
            }

            ViewData["UserName"] = user.FirstName;
            return View(products);
        }

        [Authorize(Roles = UserConstant.Roles.Client)]
        public async Task<IActionResult> FavouriteProducts()
        {
            if (ProductRemovedFromFavourites.IsRemoved)
            {
                ViewData[MessageConstant.ErrorMessage] = ProductRemovedFromFavourites.Message;
                ProductRemovedFromFavourites.IsRemoved = false;
            }

            var userName = User.Identity.Name;
            List<GetProductViewModel> products = null;

            try
            {
                ApplicationUser user = await userService.GetUser(userName);
                products = await productService.GetFavouriteProducts(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "MyLdController/FavoutiteProducts");
                return DatabaseError();
            }

            return View(products);
        }

        [Authorize(Roles = UserConstant.Roles.Client)]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var userName = User.Identity.Name;
            ApplicationUser user = null;

            try
            {
                try
                {
                    user = await userService.GetUser(userName);
                    await productService.RemoveFromFavourite(id, user);
                }
                catch (ArgumentException aex)
                {
                    ProductRemovedFromFavourites.Message = ErrorMessages.RemovedProduct;
                    ProductRemovedFromFavourites.IsRemoved = true;
                    return Redirect("/MyLd/FavouriteProducts");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "MyLdController/RemoveProduct");
                return DatabaseError();
            }

            return Redirect("/MyLd/FavouriteProducts");
        }

        [Authorize(Roles = UserConstant.Roles.Client)]
        public async Task<IActionResult> FavouriteImages()
        {
            if (ImageRemovedFromFavourites.IsRemoved)
            {
                ViewData[MessageConstant.ErrorMessage] = ImageRemovedFromFavourites.Message;
                ImageRemovedFromFavourites.IsRemoved = false;
            }

            var userName = User.Identity.Name;
            List<ImageViewModel> images = null;

            try
            {
                ApplicationUser user = await userService.GetUser(userName);
                images = await galleryService.GetFavouriteImages(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "MyLdController/FavouriteImages");
                return DatabaseError();
            }

            return View(images);
        }

        [Authorize(Roles = UserConstant.Roles.Client)]
        public async Task<IActionResult> RemoveFromFavourites(int id)
        {
            var userName = User.Identity.Name;
            ApplicationUser user = null;

            try
            {
                try
                {
                    user = await userService.GetUser(userName);
                    await galleryService.RemoveFromFavourite(id, user);
                }
                catch (ArgumentException aex)
                {
                    ImageRemovedFromFavourites.Message = ErrorMessages.RemovedImage;
                    ImageRemovedFromFavourites.IsRemoved = true;
                    return Redirect("/MyLd/FavouriteImages");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "MyLdController/RemoveFromFavourites");
                return DatabaseError();
            }

            return Redirect("/MyLd/FavouriteImages");
        }

        private IActionResult DatabaseError()
        {
            ErrorViewModel error = new ErrorViewModel() { ErrorMessage = ErrorMessages.DatabaseConnectionError };
            return View("_Error", error);
        }
    }
}
