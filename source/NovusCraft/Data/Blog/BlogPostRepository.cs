// # Copyright � 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Data.Blog
{
	public sealed class BlogPostRepository : IBlogPostRepository
	{
		#region IBlogPostRepository Members

		public BlogPost GetBlogPost(string slug)
		{
			if (slug == "welcome-to-my-blog")
				return new BlogPost
				       	{
				       		Title = "Welcome to my blog",
				       		Content = "<p>I have been wanting to set one up for a while, but for various reasons kept postponing. One of the things that prompted me to start a blog is my desire to learn ASP.NET MVC. I could not think of a better way to learn than building a blogging engine.</p>" +
				       		          "<p>Currently, the blog engine is just a skeleton implementation constructed with ASP.NET MVC 3 (C# 4 + Razor views) and HTML5 + CSS3 + jQuery. Source code is available publicly on <a href=\"https://github.com/NovusCraft/NovusCraft\" title=\"novuscraft.com project on GitHub\">GitHub</a>.</p>" +
				       		          "<p>My other reason for starting a blog is I <del>want</del> need a place where I can share my discoveries and ideas. It bugs me that every time I have solved a rare challenge (rare in a sense that Google had no answer to it) I have not shared the solution.</p>" +
				       		          "<p>I have lots of things on my <a href=\"https://github.com/NovusCraft/NovusCraft/issues?sort=created&direction=desc&state=open&page=1&milestone=2\" title=\"Open novuscraft.com issues in GitHub backlog\">backlog</a> (<a href=\"http://ravendb.net/\" title=\"RavenDB - an Open Source document database for the .NET/Windows platform\">RavenDB</a>, <a href=\"https://github.com/jetheredge/SquishIt\" title=\"SquishIt lets you squish some JavaScript and CSS\">SquishIt</a>, and more), so this should keep me busy for a while.</p>",
				       		Category = new BlogPostCategory
				       		           	{
				       		           		Title = "Meta"
				       		           	},
				       		PublishedOn = new DateTimeOffset(2011, 10, 23, 23, 35, 00, TimeSpan.Zero)
				       	};

			if (slug == "getting-started-with-mspec")
				return new BlogPost
				       	{
							Title = "Getting started with MSpec",
				       		Content = "<p>I am a long-time fan of <a href=\"http://xunit.codeplex.com/\" title=\"xUnit.net project on CodePlex\">xUnit.net</a>. I have been using it since it was in early beta and it is my default choice for almost any project. For building Novus Craft, I decided to use something new and very different &mdash; a Context/Specification framework called <a href=\"https://github.com/machine/machine.specifications\" title=\"Machine.Specification project on GitHub\">Machine.Specifications</a>.</p>" +
				       		          "<p>On my journey to learn MSpec, I have come across a number of helpful tips, instructions and tweaks, so I decided to put together a quick guide on how to get started. I am not going to talk about why or when you should use MSpec. If you want to read about that, check out Aaron Jensen&rsquo;s <a href=\"http://codebetter.com/aaronjensen/2008/05/08/introducing-machine-specifications-or-mspec-for-short/\" title=\"\">Introducing Machine.Specifications (or MSpec for short)</a>. Instead, I will focus on how to setup your development environment.</p>" +
				       		          "<h2>How to get MSpec</h2>" +
				       		          "<h3>Install MSpec via NuGet package manager</h3>" +
				       		          "<p>Open NuGet Package Manager Console and enter one of the following commands:</p>" +
				       		          "<ul>" +
				       		          "<li>To download and install an unsigned release:<br><code>PM> Install-Package Machine.Specifications</code></li>" +
				       		          "<li>To download and install a signed release:<br><code>PM> Install-Package Machine.Specifications-Signed</code></li>" +
				       		          "</ul>" +
				       		          "<h3>Download latest MSpec binaries from CodeBetter CI server</h3>" +
				       		          "<p>You can download the latest build directly from CodeBetter Continuous Integration server:</p>" +
				       		          "<ul>" +
				       		          "<li><a href=\"http://teamcity.codebetter.com/guestAuth/repository/download/bt342/.lastSuccessful/Machine.Specifications-Release.zip\" title=\"Latest unsigned MSpec build on CodeBetter.com CI server\">Latest unsigned build</a></li>" +
				       		          "<li><a href=\"http://teamcity.codebetter.com/guestAuth/repository/download/bt345/.lastSuccessful/Machine.Specifications-Signed-Release.zip\" title=\"Latest signed MSpec build on CodeBetter.com CI server\">Latest signed build</a></li>" +
				       		          "</ul>" +
				       		          "<h3>Compile MSpec yourself from source available on GitHub</h3>" +
				       		          "<p>MSpec is an open-source project, so you can simply pull down the latest source using Git and compile it yourself. Check out <a href=\"https://github.com/machine/machine.specifications/blob/master/README.markdown\" title=\"MSpec readme file\">MSpec readme file</a> for more information.</p>" +
				       		          "<h2>How to setup MSpec with ReSharper</h2>" +
				       		          "<p>If you use something other than ReSharper you can skip this stage. If you are not using <em>any</em> productivity plugin &mdash; install <a href=\"http://www.jetbrains.com/resharper/download/index.html\" title=\"ReSharper download page\">ReSharper</a> right now (you will thank me later).</p>" +
				       		          "<h3>Install ReSharper runner</h3>" +
				       		          "<p>Default installation of ReSharper has no knowledge of what an MSpec specification is. To enable MSpec support you need to install a ReSharper plugin.</p>" +
				       		          "<p>MSpec provides plugins compatible with ReSharper v4.1, v4.5, v5.0, v5.1, v6.0 for Visual Studio 2008 and 2010. To install the plugin you need to open MSpec installation directory and execute on the the following scripts:</p>" +
				       		          "<ul>" +
				       		          "<li>ReSharper v4.1<br><code>InstallResharperRunner.4.1.bat</code></li>" +
				       		          "<li>ReSharper v4.5<br><code>InstallResharperRunner.4.5.bat</code></li>" +
				       		          "<li>ReSharper v5.0 on Visual Studio 2008<br><code>InstallResharperRunner.5.0 - VS2008.bat</code></li>" +
				       		          "<li>ReSharper v5.0 on Visual Studio 2010<br><code>InstallResharperRunner.5.0 - VS2010.bat</code></li>" +
				       		          "<li>ReSharper v5.1 on Visual Studio 2008<br><code>InstallResharperRunner.5.1 - VS2008.bat</code></li>" +
				       		          "<li>ReSharper v5.1 on Visual Studio 2010<br><code>InstallResharperRunner.5.1 - VS2010.bat</code></li>" +
				       		          "<li>ReSharper v6.0 on Visual Studio 2008<br><code>InstallResharperRunner.6.0 - VS2008.bat</code></li>" +
				       		          "<li>ReSharper v6.0 on Visual Studio 2010<br><code>InstallResharperRunner.6.0 - VS2010.bat</code></li>" +
				       		          "</ul>" +
				       		          "<h3>Configure ReSharper Naming Rules for MSpec</h3>" +
				       		          "<p>One of the things you will notice straight away is ReSharper doesn't like MSpec naming conventions. Fortunately, you can configure ReSharper to understand MSpec naming conventions and even warn you when you are not naming you specifications correctly. Derek Greer&rsquo;s article (<a href=\"http://www.aspiringcraftsman.com/2010/02/11/resharper-naming-style-for-machine-specifications/\">Resharper Naming Style for Machine.Specifications</a>) explains how to do this correctly.</p>" +
				       		          "<h3>Suppress &lsquo;Field is never used&rsquo; warnings</h3>" +
				       		          "<p>MSpec specifications are defined using private fields. MSpec uses reflection to analyse specifications at runtime, so naturally, there are no references to those private fields. Visual Studio&rsquo;s code analysis engine reports them as unused (this behaviour is by design <em>and</em> is correct. It&rsquo;s just not correct in the context of MSpec specifications).</p>" +
				       		          "<p>You can override this behaviour via project properties. This approach works at project-level and does not affect other projects in the solution:</p>" +
				       		          "<ol>" +
				       		          "<li>Open <code>Properties</code> for your MSpec project</li>" +
				       		          "<li>Select <code>Build</code> tab</li>" +
				       		          "<li>Enter <strong>169</strong> into <code>Supress warnings</code> field</li>" +
				       		          "<li>Save (this will take immediate effect)</li>" +
				       		          "</ol>" +
				       		          "<h2>Other Resources</h2>" +
				       		          "<p>I hope you found this information useful. There are lots of other resources available. Check out Byron Sommardahl&rsquo;s <a href=\"http://www.awkwardcoder.com/index.php/2010/04/13/how-to-mspec/\">How to MSpec?</a> for lots of useful links. Another good place is <a href=\"http://stackoverflow.com/questions/tagged/mspec?sort=newest\">StackOveflow questions tagged with MSpec</a>.</p>",
				       		Category = new BlogPostCategory
				       		           	{
				       		           		Title = "Testing"
				       		           	},
				       		PublishedOn = new DateTimeOffset(2011, 11, 19, 16, 58, 37, TimeSpan.Zero)
				       	};

			return null;
		}

		#endregion
	}
}