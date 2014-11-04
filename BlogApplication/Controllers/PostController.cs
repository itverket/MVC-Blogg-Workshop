﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using ApplicationModel;
using ApplicationModel.Models;
using ApplicationModel.Repositories;
using BlogApplication.Extensions;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class PostController : Controller
    {
        private readonly PostRepository _postRepository = new PostRepository();
        private readonly int _postsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["PostsPerPage"]);
        // GET: Post
        public ActionResult ViewPosts(int startPos = 0)
        {
            var remainingPosts = _postRepository.GetAllPosts().Skip(startPos + _postsPerPage).ToList();
            var posts = _postRepository.GetPostsInRange(startPos, _postsPerPage).ToList();

            var model = new ViewPostsViewModel
            {
                CurrentPos = startPos,
                PreviousPageExists = startPos >= _postsPerPage,
                PreviousPageStartPosition = startPos >= _postsPerPage ? startPos-_postsPerPage : 0,
                NextPageExists = remainingPosts.Any(),
                NextPageStartPosition = remainingPosts.Any() ? startPos + _postsPerPage: startPos,
                Posts = posts.Select(x => new PostViewModel
                {
                    Content = x.Content,
                    Created = x.Created,
                    Edited = x.Edited,
                    Introduction = x.Introduction,
                    PostId = x.PostId,
                    Title = x.Title
                }).ToList()
            };
            return View(model);
        }

        public ActionResult NewPost()
        {
            var model = new PostViewModel();

            return View(model);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPost(PostViewModel post)
        {
            _postRepository.AddPost(new Post
            {
                Created = DateTime.Now,
                Edited = DateTime.Now,
                Introduction = post.Introduction,
                Content = post.Content,
                Title = post.Title
            });

            return RedirectToAction("ViewPosts");
        }

        public ActionResult ViewPost(int id)
        {
            var post = _postRepository.GetPost(id);
            post.Comments = _postRepository.GetComments(post.PostId);
            var model = new PostViewModel
            {
                Edited = post.Edited,
                Introduction = post.Introduction,
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                Created = post.Created,
                Comments = post.Comments.ToList().GetMapping()
            };

            return View(model);
        }

        [HttpDelete, Authorize]
        public ActionResult DeletePost(int id)
        {
            var post = _postRepository.GetPost(id);
            _postRepository.DeletePost(post);
            _postRepository.DeleteCommentsForPost(post);
            return RedirectToAction("ViewPosts");
        }
        
        private ActionResult RedirectToPost(int postId)
        {
            return RedirectToAction("ViewPost", "Post", new {id = postId});
        }

        [HttpDelete, Authorize]
        public ActionResult DeleteComment(int commentId, int postId)
        {
            _postRepository.DeleteComment(commentId);
            return RedirectToAction("ViewPost", "Post", new { id = postId });
        }
    }
}