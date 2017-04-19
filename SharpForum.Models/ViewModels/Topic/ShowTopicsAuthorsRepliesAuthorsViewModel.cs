using SharpForum.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpForum.Models.ViewModels.Topic
{
    public class ShowTopicsAuthorsRepliesAuthorsViewModel
    {
        public IEnumerable<TopicAuthorRepliesAuthorsViewModel> Topics { get; set; }

        public Pagination Pagination { get; set; }
    }
}
