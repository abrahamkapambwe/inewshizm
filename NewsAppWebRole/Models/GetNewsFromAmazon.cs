using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.SimpleDB.Model;
using Amazon.SimpleDB;


using News.Models;
using System.Net;
using System.IO;
using NewsAppWebRole.Properties;
using Amazon.S3.Model;
using Amazon.S3;


namespace Newsza.Models
{
    public class GetNewsFromAmazon
    {

        private static AmazonSimpleDBClient _sdbClient;
        public static AmazonSimpleDBClient sdbClient
        {
            get
            {
                if (_sdbClient == null)
                    _sdbClient = new AmazonSimpleDBClient();
                return _sdbClient;
            }
        }
        private static AmazonS3Client _s3Client;
        public static AmazonS3Client s3Client
        {
            get
            {
                if (_s3Client == null)
                    _s3Client = new AmazonS3Client();
                return _s3Client;
            }
        }
        public static void SaveComments(string domainName, Comment comment)
        {

            PutAttributesRequest putAttrRequest = new PutAttributesRequest()
                .WithDomainName(domainName)
                .WithItemName(Convert.ToString(comment.CommentID));
            putAttrRequest.WithAttribute(new ReplaceableAttribute
            {
                Name = "NewsID",
                Value = Convert.ToString(comment.NewsID),
                Replace = false
            },

            new ReplaceableAttribute
            {
                Name = "UserName",
                Value = comment.UserName,
                Replace = false
            },
            new ReplaceableAttribute
            {
                Name = "CommentID",
                Value = Convert.ToString(comment.CommentID),
                Replace = false
            },
             new ReplaceableAttribute
             {
                 Name = "CommentAdded",
                 Value = Convert.ToString(comment.CommentAdded),
                 Replace = false
             }
             ,
             new ReplaceableAttribute
             {
                 Name = "CommentItem",
                 Value = SaveHtml(comment.CommentItem),
                 Replace = false
             }
              ,
             new ReplaceableAttribute
             {
                 Name = "CommentReplyID",
                 Value = comment.CommentReplyID,
                 Replace = false
             }
              ,
             new ReplaceableAttribute
             {
                 Name = "Likes",
                 Value = Convert.ToString(comment.Likes),
                 Replace = true
             }
           );
            sdbClient.PutAttributes(putAttrRequest);
        }

        private static string SaveHtml(string p)
        {

            string folder = Convert.ToString(Guid.NewGuid());
            string bucketName = Settings.Default.BucketName + "/" + Settings.Default.KenyaVideo + "/" + folder;
            PutObjectRequest putObjectNewsItem = new PutObjectRequest();
            putObjectNewsItem.WithBucketName(bucketName);
            putObjectNewsItem.CannedACL = S3CannedACL.PublicRead;
            putObjectNewsItem.Key = Convert.ToString(Guid.NewGuid());
            putObjectNewsItem.ContentType = "text/html";
            putObjectNewsItem.ContentBody = p;



            using (S3Response response = s3Client.PutObject(putObjectNewsItem))
            {
                WebHeaderCollection headers = response.Headers;
                foreach (string key in headers.Keys)
                {
                    //log headers ("Response Header: {0}, Value: {1}", key, headers.Get(key));
                }
            }
            return "https://" + Settings.Default.BucketName + ".s3.amazonaws.com " + "/" + Settings.Default.KenyaVideo + "/" + folder;

        }
        public static void SaveLikes(string domainName, Comment comment)
        {

            PutAttributesRequest putAttrRequest = new PutAttributesRequest()
                .WithDomainName(domainName)
                .WithItemName(Convert.ToString(comment.CommentID));
            putAttrRequest.WithAttribute(new ReplaceableAttribute
            {
                Name = "Likes",
                Value = Convert.ToString(comment.Likes),
                Replace = true
            }

           );
            sdbClient.PutAttributes(putAttrRequest);
        }
        #region GetStories

        public static List<Multimedia> GetMultimedia(string domainName)
        {
            List<Multimedia> multimedias = new List<Multimedia>();
            Multimedia multimedia;
            String selectExpression = "Select * From " + domainName;
            SelectRequest selectRequestAction = new SelectRequest().WithSelectExpression(selectExpression);
            SelectResponse selectResponse = sdbClient.Select(selectRequestAction);
            if (selectResponse.IsSetSelectResult())
            {
                SelectResult selectResult = selectResponse.SelectResult;
                foreach (var item in selectResult.Item)
                {
                    multimedia = new Multimedia();
                    foreach (var attribute in item.Attribute)
                    {
                        if (attribute.IsSetName())
                        {

                        }
                        if (attribute.IsSetValue())
                        {
                            switch (attribute.Name)
                            {
                                case "VideoId":
                                    multimedia.VideoId = Guid.Parse(attribute.Value);
                                    break;

                                case "YoutubeUrl":
                                    multimedia.YoutubeUrl = attribute.Value;
                                    break;
                                case "Content":
                                    multimedia.Content = attribute.Value;
                                    break;
                                case "Category":
                                    multimedia.Category = attribute.Value;
                                    break;
                                case "Title":
                                    multimedia.Title = attribute.Value;
                                    break;
                                case "YouTubeAdded":
                                    multimedia.YouTubeAdded = Convert.ToDateTime(attribute.Value);
                                    break;

                                case "Publish":
                                    multimedia.Publish = Convert.ToBoolean(attribute.Value);
                                    break;

                            }
                        }

                    }
                    multimedias.Add(multimedia);
                }
            }

            return multimedias;
        }
        public static List<Comment> GetComments(string domainName)
        {
            List<Comment> comments = new List<Comment>();
            Comment comment;

            String selectExpression = "Select * From " + domainName;
            SelectRequest selectRequestAction = new SelectRequest().WithSelectExpression(selectExpression);
            SelectResponse selectResponse = sdbClient.Select(selectRequestAction);
            if (selectResponse.IsSetSelectResult())
            {
                SelectResult selectResult = selectResponse.SelectResult;
                foreach (Item item in selectResult.Item)
                {
                    comment = new Comment();
                    if (item.IsSetName())
                    {

                    }
                    int i = 0;
                    foreach (Amazon.SimpleDB.Model.Attribute attribute in item.Attribute)
                    {


                        if (attribute.IsSetName())
                        {
                            string name = attribute.Name;
                        }
                        if (attribute.IsSetValue())
                        {
                            switch (attribute.Name)
                            {
                                case "NewsID":
                                    comment.NewsID = attribute.Value;
                                    break;

                                case "UserName":
                                    comment.UserName = attribute.Value;
                                    break;
                                case "CommentID":
                                    comment.CommentID = Guid.Parse(attribute.Value);
                                    break;
                                case "CommentAdded":
                                    comment.CommentAdded = Convert.ToDateTime(attribute.Value);
                                    break;
                                case "Likes":
                                    comment.Likes = Convert.ToInt32(attribute.Value);
                                    break;
                                case "CommentItem":
                                    comment.CommentItem = GetTheHtml(attribute.Value);
                                    break;
                                case "CommentReplyID":
                                    comment.CommentReplyID = attribute.Value;
                                    break;

                            }
                            i++;
                        }
                    }
                    comments.Add(comment);
                }
            }
            return comments;
        }

       

        public static List<Comment> FormatedComments(string domainName)
        {
            List<Comment> motherComment = new List<Comment>();
            List<Comment> tempComment = GetComments(domainName);
            CommentReply commentReply = null;

            foreach (var comment in tempComment)
            {
                if (!string.IsNullOrWhiteSpace(comment.CommentReplyID))
                {
                    var replies = (from c in motherComment
                                   where c.CommentID == Guid.Parse(comment.CommentReplyID)
                                   select c).FirstOrDefault();

                    commentReply = new CommentReply();
                    commentReply.CommentAdded = comment.CommentAdded;
                    commentReply.CommentID = comment.CommentID;
                    commentReply.CommentItem = comment.CommentItem;
                    commentReply.Likes = comment.Likes;
                    commentReply.NewsID = comment.NewsID;
                    commentReply.UserName = comment.UserName;
                    commentReply.CommentReplyID = Guid.Parse(comment.CommentReplyID);
                    replies.commentReply.Add(commentReply);
                    motherComment.Add(comment);

                }
                else
                {
                    motherComment.Add(comment);
                }


            }

            return motherComment;
        }
        public static List<NewsComponents> GetNewsStories(string domainName, AmazonSimpleDBClient sdbClient)
        {
            List<NewsComponents> newsItems = new List<NewsComponents>();
            NewsComponents newsItem = null;

            String selectExpression = "Select NewsID,Source,Section,Publish,NewsHeadline,NewsAdded,Photos,Summary,Category From " + domainName;
            SelectRequest selectRequestAction = new SelectRequest().WithSelectExpression(selectExpression);
            SelectResponse selectResponse = sdbClient.Select(selectRequestAction);
            if (selectResponse.IsSetSelectResult())
            {
                SelectResult selectResult = selectResponse.SelectResult;
                foreach (Item item in selectResult.Item)
                {
                    newsItem = new NewsComponents();
                    if (item.IsSetName())
                    {

                    }
                    int i = 0;
                    foreach (Amazon.SimpleDB.Model.Attribute attribute in item.Attribute)
                    {


                        if (attribute.IsSetName())
                        {
                            string name = attribute.Name;
                        }
                        if (attribute.IsSetValue())
                        {
                            switch (attribute.Name)
                            {
                                case "NewsID":
                                    newsItem.NewsID = Guid.Parse(attribute.Value);
                                    break;
                                case "Source":
                                    newsItem.Source = attribute.Value;
                                    break;
                                case "Section":
                                    newsItem.Section = attribute.Value;
                                    break;
                                case "NewsItem":
                                    newsItem.NewsItem = attribute.Value;
                                    break;
                                case "NewsHeadline":
                                    newsItem.NewsHeadline = attribute.Value;
                                    break;
                                case "Publish":
                                    newsItem.Publish = Convert.ToBoolean(attribute.Value);
                                    break;
                                case "NewsAdded":
                                    newsItem.NewsAdded = Convert.ToDateTime(attribute.Value);
                                    break;
                                case "Photos":
                                    newsItem.NewsPhotoUrl = attribute.Value;
                                    break;
                                case "Summary":
                                    newsItem.NewsItem = GetTheHtml(attribute.Value);
                                    break;
                                case "Category":
                                    newsItem.Category = attribute.Value;
                                    break;
                                case "SummaryContent":
                                    newsItem.SummaryContent = attribute.Value;
                                    break;
                            }
                            i++;
                        }
                    }
                    newsItems.Add(newsItem);
                }
            }
            return newsItems;
        }

        private static string GetTheHtml(string p)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(p);
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader strReader = new StreamReader(stream);
            string newsContent = strReader.ReadToEnd();

            return newsContent;

        }

        public static NewsComponents GetNewsItem(string domainName, string itemName, AmazonSimpleDBClient sdbClient)
        {
            NewsComponents newsItem = new NewsComponents();

            GetAttributesRequest getAttributeRequest = new GetAttributesRequest()
                      .WithDomainName(domainName)
                      .WithItemName(itemName);
            GetAttributesResponse getAttributeResponse = sdbClient.GetAttributes(getAttributeRequest);
            List<Amazon.SimpleDB.Model.Attribute> attrs = null;
            if (getAttributeResponse.IsSetGetAttributesResult())
            {
                attrs = getAttributeResponse.GetAttributesResult.Attribute;
                int i = 0;
                foreach (Amazon.SimpleDB.Model.Attribute attribute in attrs)
                {


                    if (attribute.IsSetName())
                    {
                        string name = attribute.Name;
                    }
                    if (attribute.IsSetValue())
                    {
                        switch (i)
                        {
                            case 0:
                                newsItem.NewsID = Guid.Parse(attribute.Value);
                                break;
                            case 1:
                                newsItem.Source = attribute.Value;
                                break;
                            case 2:
                                newsItem.Section = attribute.Value;
                                break;
                            case 3:
                                newsItem.NewsItem = attribute.Value;
                                break;
                            case 4:
                                newsItem.NewsHeadline = attribute.Value;
                                break;
                            case 5:
                                newsItem.NewsAdded = Convert.ToDateTime(attribute.Value);
                                break;
                            case 7:
                                newsItem.Summary = attribute.Value;
                                break;
                            case 8:
                                newsItem.Category = attribute.Value;
                                break;
                        }
                        i++;
                    }
                }
            }
            return newsItem;

        }

        #endregion
        #region Cache
        public static List<NewsComponents> GetNewsFromCache()
        {
            // LoadItemsInCache();
            List<NewsComponents> news = null;
            if (HttpRuntime.Cache["NewsItems"] != null)
            {
                news = (List<NewsComponents>)HttpRuntime.Cache["NewsItems"];
            }
            else
            {
                news = LoadItemsInCache().Where(p => p.Publish == true).ToList();
                HttpRuntime.Cache.Insert("NewsItems", news, null, DateTime.Now.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return news;
        }
        public static List<Multimedia> GetVideosFromCache(string domainName)
        {

            List<Multimedia> videos = null;
            if (HttpRuntime.Cache["VideoItems"] != null)
            {
                videos = (List<Multimedia>)HttpRuntime.Cache["VideoItems"];
            }
            else
            {
                videos = GetMultimedia(domainName).Where(p => p.Publish == true).ToList();
                HttpRuntime.Cache.Insert("VideoItems", videos, null, DateTime.Now.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return videos;
        }

        private static List<NewsComponents> LoadItemsInCache()
        {
            bool techn = false;
            bool busin = false;
            bool sport = false;
            bool entern = false;
            var news = GetNewsStories(Settings.Default.DomainNameZM, sdbClient);
            List<NewsComponents> list = new List<NewsComponents>();
            List<Images> Images = new List<Images>();
            Images img;
            int i = 0;
            foreach (var item in news)
            {
                
                var photourl = item.NewsPhotoUrl.Split(new char[] { '|' });
                foreach (var url in photourl)
                {
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        img = new Images();
                        img.Url = url;
                        item.Images.Add(img);
                    }
                }
                if (item.Category == Categories.POLITICS)
                {
                    if (i < 1 && item.Images.Count > 0)
                    {
                        item.Section = "Section 1";
                        item.Show = true;
                    }
                    else if (i >= 1 && i <= 4)
                    {
                        item.Section = "Section 2";
                    }
                    else if (i > 5 && i <= 11)
                    {
                        item.Section = "Section 3";
                    }
                    else if (i > 11 && i < 17)
                    {
                        item.Section = "Section 4";
                    }
                    else if (i > 18 && i < 24)
                    {
                        item.Section = "Section 5";
                    }
                    i++;
                }
                else if (item.Category == Categories.ENTERTAINMENT)
                {
                    item.Section = "Section 6";
                    if (entern)
                    {
                        entern = false;
                        item.Area = "right";
                    }
                    else
                    {
                        entern = true;
                        item.Area = "left";
                    }

                }
                else if (item.Category == Categories.BUSINESS)
                {
                    item.Section = "Section 7";
                    if (busin)
                    {
                        busin = false;
                        item.Area = "right";
                    }
                    else
                    {
                        busin = true;
                        item.Area = "left";
                    }
                }
                else if (item.Category == Categories.TECHNOLOGY)
                {
                    item.Section = "Section 9";
                    if (techn)
                    {
                        techn = false;
                        item.Area = "right";
                    }
                    else
                    {
                        techn = true;
                        item.Area = "left";
                    }
                }
                else if (item.Category == Categories.SPORT)
                {
                    item.Section = "Section 8";
                    if (sport)
                    {
                        sport = false;
                        item.Area = "right";
                    }
                    else
                    {
                        sport = true;
                        item.Area = "left";


                    }

                }

                list.Add(item);
            }

            return news;
        }
        #endregion
    }
}