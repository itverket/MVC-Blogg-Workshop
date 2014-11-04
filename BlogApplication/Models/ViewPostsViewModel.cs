using System.Collections.Generic;

namespace BlogApplication.Models
{
    public class ViewPostsViewModel
    {
        public ViewPostsViewModel()
        {
            Posts = new List<PostViewModel>();
        }
        public List<PostViewModel> Posts { get; set; }
        public int CurrentPos { get; set; }
        public bool PreviousPageExists { get; set; }
        public bool NextPageExists { get; set; }
        public int PreviousPageStartPosition { get; set; }
        public object NextPageStartPosition { get; set; }
    }
}