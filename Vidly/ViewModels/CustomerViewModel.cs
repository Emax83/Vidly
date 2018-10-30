using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        //https://stackoverflow.com/questions/21677038/mvc-upload-file-with-model-second-parameter-posted-file-is-null
        public HttpPostedFileBase Thumbnail { get; set; }
    }
}