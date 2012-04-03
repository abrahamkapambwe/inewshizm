using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.Models;

namespace NewsAppWebRole.Models
{
    public class NewsComponentViewModel
    {
        public IEnumerable<NewsComponents> NewsComponentses { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItems/ItemsPerPage); }
        }
    }
}