using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace News.Models
{
    public class NewsComponents
    {

        public NewsComponents()
        {
            NewsID = Guid.NewGuid();

        }

        public string SummaryContent { get; set; }
        //private Pagination _pagination;
        //public Pagination Pagination
        //{
        //    get
        //    {
        //        if (_pagination == null)
        //            _pagination = new Pagination();
        //        return _pagination;
        //    }
        //    set { _pagination = value; }
        //}
        public Guid NewsID
        {
            get;
            set;
        }
        public string BucketName
        {
            get;
            set;
        }
        public string Source
        {
            get;
            set;
        }
        public string Area
        {
            get;
            set;
        }
        public string Section
        {
            get;
            set;
        }


        public string NewsItem
        {
            get;
            set;
        }
        public bool Publish
        {
            get;
            set;
        }
        public string NewsHeadline
        {
            get;
            set;
        }
        public DateTime NewsAdded
        {
            get;
            set;
        }
        private string _newsPhotoUrl = "";
        public string NewsPhotoUrl
        {
            get
            {
                return _newsPhotoUrl;
            }
            set
            {
                _newsPhotoUrl = value;
            }
        }
        public string Summary
        {
            get;
            set;
        }
        private Boolean _show = false;
        public Boolean Show
        {
            get
            {
                return _show;
            }
            set
            {
                _show = value;
            }
        }
        public string Category
        {
            get;
            set;
        }
        public String Country
        {
            get;
            set;
        }
        public DateTime TimeStamp
        {
            get;
            set;
        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageTotal { get; set; }
        public Boolean HasNext { get; set; }
        public Boolean HasPrevious { get; set; }
        private List<Images> images;
        public List<Images> Images
        {
            get
            {
                if (images == null)
                    images = new List<Images>();
                return images;
            }
            set
            {
                images = value;
            }
        }

        private List<Comment> _comment;
        public List<Comment> Comment
        {
            get
            {
                if (_comment == null)
                    _comment = new List<Comment>();
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }



    }


    

    public class Images
    {
        public Stream photostreams
        {
            get;
            set;
        }
        public string fileName
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }
    }
    public class Comment
    {
        public string NewsID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
        public Guid CommentID
        {
            get;
            set;
        }
        public string CommentItem
        {
            get;
            set;
        }
        public DateTime CommentAdded
        {
            get;
            set;
        }
        public int Likes
        {
            get;
            set;
        }
        private string commentReplyID = "";
        public string CommentReplyID
        {
            get
            {

                return commentReplyID;
            }
            set
            {
                commentReplyID = value;
            }
        }
        public List<CommentReply> _commentReply;
        public List<CommentReply> commentReply
        {
            get
            {
                if (_commentReply == null)
                    _commentReply = new List<CommentReply>();
                return _commentReply;
            }
            set
            {
                _commentReply = value;
            }
        }

    }
    public class CommentReply
    {
        public string NewsID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
        public Guid CommentID
        {
            get;
            set;
        }
        public string CommentItem
        {
            get;
            set;
        }
        public DateTime CommentAdded
        {
            get;
            set;
        }
        public int Likes
        {
            get;
            set;
        }
        public Guid CommentReplyID
        {
            get;
            set;
        }
    }
    public class Multimedia
    {
        public Guid VideoId
        {
            get;
            set;
        }
        public Boolean Publish { get; set; }
        public DateTime YouTubeAdded { get; set; }
        public string Category { get; set; }
        public string YoutubeUrl
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }

        public string Country { get; set; }
    }


}
