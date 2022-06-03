﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Thoughts.Domain.Base.Entities;
using Thoughts.Interfaces;
using Thoughts.Interfaces.Base.Repositories;

namespace Thoughts.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostManager _manager;
        private readonly ILogger<BlogPostController> _logger;

        public BlogPostController(IBlogPostManager manager, ILogger<BlogPostController> logger)
        {
            _manager = manager;
            _logger = logger;
        }
        /// <summary>Назначение тэга посту</summary>
        /// <param name="PostId">Идентификатор поста</param>
        /// <param name="Tag">Добавляемый тэг</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Истина, если тэг был назначен успешно</returns>
        public async Task<IActionResult> AssignTagAsync(int PostId, string Tag, CancellationToken Cancel = default)
        {
            var result = await _manager.AssignTagAsync(PostId, Tag, Cancel);
            return Ok(result);
        }

        /// <summary>Изменение тела поста</summary>
        /// <param name="PostId">Идентификатор поста</param>
        /// <param name="Body">Новое тело поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Истина, если тело было изменено успешно</returns>
        public async Task<IActionResult> ChangePostBodyAsync(int PostId, string Body, CancellationToken Cancel = default)
        {
            var result = await _manager.ChangePostBodyAsync(PostId, Body, Cancel);
            return Ok(result);
        }
        public Task<Category> ChangePostCategoryAsync(int PostId, string CategoryName, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<Status> ChangePostStatusAsync(int PostId, string Status, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<bool> ChangePostTitleAsync(int PostId, string Title, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<Post> CreatePostAsync(string Title, string Body, string UserId, string Category, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<bool> DeletePostAsync(int Id, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IEnumerable<Post>> GetAllPostsAsync(CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(string UserId, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IPage<Post>> GetAllPostsByUserIdPageAsync(string UserId, int PageIndex, int PageSize, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IEnumerable<Post>> GetAllPostsByUserIdSkipTakeAsync(string UserId, int Skip, int Take, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<int> GetAllPostsCountAsync(CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IPage<Post>> GetAllPostsPageAsync(int PageIndex, int PageSize, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IEnumerable<Post>> GetAllPostsSkipTakeAsync(int Skip, int Take, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IEnumerable<Tag>> GetBlogTagsAsync(int Id, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<Post?> GetPostAsync(int Id, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<IEnumerable<Post>> GetPostsByTag(string Tag, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<int> GetUserPostsCountAsync(string UserId, CancellationToken Cancel = default) => throw new NotImplementedException();
        public Task<bool> RemoveTagAsync(int PostId, string Tag, CancellationToken Cancel = default) => throw new NotImplementedException();
    }
}
