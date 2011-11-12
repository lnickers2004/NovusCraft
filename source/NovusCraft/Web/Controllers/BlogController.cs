﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Net;
using System.Web.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Web.Controllers
{
	public sealed class BlogController : Controller
	{
		readonly IBlogCategoryRepository _blogCategoryRepository;

		public BlogController(IBlogCategoryRepository blogCategoryRepository)
		{
			_blogCategoryRepository = blogCategoryRepository;
		}

		public ActionResult ViewPost(string slug)
		{
			var blogPost = _blogCategoryRepository.GetBlogPost(slug);

			if (blogPost == null)
			{
				Response.StatusCode = (int)HttpStatusCode.NotFound;
				return View("PageNotFound");
			}

			var model = new ViewPostModel
			            	{
			            		Title = blogPost.Title,
			            		Content = new MvcHtmlString(blogPost.Content),
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn
			            	};

			return View(model);
		}
	}
}