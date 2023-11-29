﻿using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ReviewCollection _reviewCollection = new();

        private readonly ReviewRepository _reviewRepository = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reviews(int user_id, int page)
        {
            List<ReviewModel> reviews = _reviewCollection.GetWithUserID(user_id, page, _reviewRepository);
          
            return View(reviews);
        }
    }
}
