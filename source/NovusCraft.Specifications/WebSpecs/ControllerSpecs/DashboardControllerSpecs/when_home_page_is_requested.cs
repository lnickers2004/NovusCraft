﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	[Subject(typeof(DashboardController))]
	public class when_home_page_is_requested : dashboard_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				repository.Setup(bpr => bpr.GetBlogPosts()).Returns(new List<BlogPost>
				                                                    	{
				                                                    		new BlogPost
				                                                    			{
				                                                    				Id = 1,
				                                                    				Title = "Title",
				                                                    				Content = "Content",
				                                                    				Category = new BlogPostCategory { Title = "Category Title" },
				                                                    				PublishedOn = new DateTimeOffset(2012, 01, 17, 0, 0, 0, TimeSpan.Zero)
				                                                    			}
				                                                    	});

				result = controller.Home();
			};

		It should_display_home_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_list_of_blog_posts =
			() => result.Model<IList<ViewBlogPostModel>>().Count.ShouldBeGreaterThan(0);

		It should_return_list_of_blog_posts_with_blog_post_having_id =
			() => result.Model<IList<ViewBlogPostModel>>().First().Id.ShouldEqual(1);

		It should_return_list_of_blog_posts_with_blog_post_having_title =
			() => result.Model<IList<ViewBlogPostModel>>().First().Title.ShouldEqual("Title");

		It should_return_list_of_blog_posts_with_blog_post_having_content =
			() => result.Model<IList<ViewBlogPostModel>>().First().Content.ToString().ShouldEqual("Content");

		It should_return_list_of_blog_posts_with_blog_post_having_category_title =
			() => result.Model<IList<ViewBlogPostModel>>().First().CategoryTitle.ShouldEqual("Category Title");

		It should_return_list_of_blog_posts_with_blog_post_having_publish_date =
			() => result.Model<IList<ViewBlogPostModel>>().First().PublishedOn.ShouldEqual(new DateTimeOffset(2012, 01, 17, 0, 0, 0, TimeSpan.Zero));

		It requires_authentication =
			() => This.Action<DashboardController>(controller => controller.Home()).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}