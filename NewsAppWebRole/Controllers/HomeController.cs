using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using System.IO;

using Newsza.Models;


using News.Models;
using NewsAppWebRole.Properties;
using PagedList;
using NewsAppWebRole.Models;


namespace Newsza.Controllers
{
    public class HomeController : Controller
    {
        const int pageSize = 3;
        private NewsComponents _news;
        public NewsComponents news
        {
            get
            {
                if (_news == null)
                    _news = new NewsComponents();
                return _news;
            }
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var news = GetNewsFromAmazon.GetNewsFromCache();
            return View(news);

        }

        public ActionResult NewsDetails(string id,int? page)
        {
            var news = GetNewsFromAmazon.GetNewsFromCache().Where(n => n.NewsID == Guid.Parse(id)).FirstOrDefault();
            if (news != null)
            {
                if (news.Comment.Count > 0)
                    news.Comment.Clear();
                var comments = GetNewsFromAmazon.FormatedComments(Settings.Default.DomainNameComment).Where(n => n.NewsID == Convert.ToString(news.NewsID));
                //var paginatedNews = new PagedList<Comment>(comments, page ?? 1, pageSize);
                //news.Comment.AddRange(comments);
                return View(news);
            }
            return new EmptyResult();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
        public ActionResult News()
        {
            var news = GetNewsFromAmazon.GetNewsFromCache();
            return View(news);
        }
        public ActionResult Multimedia()
        {
            var videos = GetNewsFromAmazon.GetVideosFromCache(Settings.Default.KenyaVideo).ToList();
            return View(videos);
        }
        public ActionResult Search(string term, int? page)
        {


            var news = GetNewsFromAmazon.GetNewsFromCache().Where(s => s.NewsItem.Contains(term)).ToList();

            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);
            return View("OtherNews", paginatedNews);
        }
        public ActionResult Technology(int? page)
        {
            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.TECHNOLOGY).ToList();
            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);
            return View("OtherNews", paginatedNews);

        }
        public ActionResult Lifetstyle(int? page)
        {
            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.LIFESTYLE).ToList();
            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);
            //NewsComponentViewModel viewModel = new NewsComponentViewModel
            //{
            //    NewsComponentses = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.LIFESTYLE).Skip((page - 1) * pageSize).Take(pageSize),

            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = pageSize,
            //        TotalItems = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.LIFESTYLE).Count()
            //    }
            //};
            return View("OtherNews", paginatedNews);
        }
        public ActionResult Entertainment(int? page)
        {
            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.BUSINESS).ToList();
            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);
           
           
            return View("OtherNews", paginatedNews);
        }
        public ActionResult Business(int? page)
        {

            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.BUSINESS).ToList();
            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);

            return View("OtherNews", paginatedNews);
        }
        public ActionResult Sport(int? page)
        {
            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.SPORT).ToList();
            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);
          
           
            return View("OtherNews", paginatedNews);
        }
        public ActionResult Politics(int? page)
        {

            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Category == Categories.POLITICS).ToList();
            var paginatedNews = new PagedList<NewsComponents>(news, page ?? 1, pageSize);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://epropertysearchke.apphb.com/PropertyTableAzures");
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader(stream);
            
            return View("OtherNews", paginatedNews);
           
        }
        [HttpPost]
        public ActionResult Property()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://epropertysearchke.apphb.com/PropertyTableAzures");
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader(stream);


            return Json(new { });
        }
        [HttpPost]
        public ActionResult Comment(string NewsID, string CommentItem)
        {

            Comment comment = new Comment();
            comment.CommentID = Guid.NewGuid();
            comment.NewsID = NewsID;
            comment.CommentItem = CommentItem;
            comment.UserName = HttpContext.User.Identity.Name;
            comment.CommentAdded = DateTime.Now;
            if (news.Comment.Count > 0)
                news.Comment.Clear();
            news.Comment.Add(comment);
            GetNewsFromAmazon.SaveComments(Settings.Default.DomainNameComment, comment);
            return View(news);

        }

        [HttpPost]
        public ActionResult Like(int like, string commentId)
        {
            //likes = Convert.ToInt32(HttpContext.Request.QueryString["like"]);
            //commentID = Convert.ToString(HttpContext.Request.QueryString["Comment"]);
            like = like + 1;
            Comment comment = new Comment();
            comment.Likes = Convert.ToInt32(like);
            comment.CommentID = Guid.Parse(commentId);
            GetNewsFromAmazon.SaveLikes(Settings.Default.DomainNameComment, comment);
            if (news.Comment.Count > 0)
                news.Comment.Clear();
            news.Comment.Add(comment);
            return Json(new
            {
                like = like
            });

        }
        [HttpPost]
        public ActionResult CommentReply(string newsId, string commentreply, string username, string commentID)
        {

            Comment comment = new Comment();
            comment.CommentReplyID = commentID;
            comment.NewsID = newsId;
            comment.CommentItem = commentreply;
            comment.CommentID = Guid.NewGuid();
            comment.UserName = username;
            comment.CommentAdded = DateTime.Now;
            if (news.Comment.Count > 0)
                news.Comment.Clear();
            news.Comment.Add(comment);
            GetNewsFromAmazon.SaveComments(Settings.Default.DomainNameComment, comment);
            return View(news);

        }
        [ChildActionOnly]
        public ActionResult BreakinNews()
        {
            var news = GetNewsFromAmazon.GetNewsFromCache().Where(t => t.Section == Categories.POLITICS).Take(1);

            return PartialView(news);
        }
        [ChildActionOnly]
        public ActionResult Comment()
        {
            var comments = GetNewsFromAmazon.GetComments(Settings.Default.DomainNameComment);
            return PartialView("_Comment", comments);
        }
    }
}
