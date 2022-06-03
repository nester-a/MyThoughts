﻿using Microsoft.AspNetCore.Mvc;

using Thoughts.Interfaces;

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
        [HttpPut("posts/{PostId}/tag/{Tag}")]
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
        [HttpPut("posts/{PostId}/body/{Body}")]
        public async Task<IActionResult> ChangePostBodyAsync(int PostId, string Body, CancellationToken Cancel = default)
        {
            var result = await _manager.ChangePostBodyAsync(PostId, Body, Cancel);
            return Ok(result);
        }

        /// <summary>Изменение категории поста</summary>
        /// <param name="PostId">Идентификатор поста</param>
        /// <param name="CategoryName">Новая категория поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Изменённая категория</returns>
        [HttpPut("posts/{PostId}/category/{CategoryName}")]
        public async Task<IActionResult> ChangePostCategoryAsync(int PostId, string CategoryName, CancellationToken Cancel = default)
        {
            var result = await _manager.ChangePostCategoryAsync(PostId, CategoryName, Cancel);
            return Ok(result);
        }

        /// <summary>Изменение статуса поста</summary>
        /// <param name="PostId">Идентификатор поста</param>
        /// <param name="Status">Новый статус поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Изменённый статус</returns>
        [HttpPut("posts/{PostId}/status/{Status}")]
        public async Task<IActionResult> ChangePostStatusAsync(int PostId, string Status, CancellationToken Cancel = default)
        {
            var result = await _manager.ChangePostStatusAsync(PostId, Status, Cancel);
            return Ok(result);
        }

        /// <summary>Изменение заголовка поста</summary>
        /// <param name="PostId">Идентификатор поста</param>
        /// <param name="Title">Новый заголовок поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Истина, если заголовок был изменен успешно</returns>
        [HttpPut("posts/{PostId}/title/{Title}")]
        public async Task<IActionResult> ChangePostTitleAsync(int PostId, string Title, CancellationToken Cancel = default)
        {
            var result = await _manager.ChangePostTitleAsync(PostId, Title, Cancel);
            return Ok(result);
        }

        /// <summary>Создание нового поста</summary>
        /// <param name="Title">Заголовок</param>
        /// <param name="Body">Тело</param>
        /// <param name="UserId">Идентификатор пользователя, создающего пост</param>
        /// <param name="Category">Категория</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Вновь созданный пост</returns>
        [HttpPost("posts/users/{UserId}/{Title}-{Body}-{Category}")]
        public async Task<IActionResult> CreatePostAsync(string UserId, string Title, string Body, string Category, CancellationToken Cancel = default)
        {
            var result = await _manager.CreatePostAsync(Title, Body, UserId, Category, Cancel);
            return Ok(result);
        }

        /// <summary>Удаление поста</summary>
        /// <param name="Id">Идентификатор поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Истина, если пост был удалён успешно</returns>
        [HttpDelete("posts/{Id}")]
        public async Task<IActionResult> DeletePostAsync(int Id, CancellationToken Cancel = default)
        {
            var result = await _manager.DeletePostAsync(Id, Cancel);
            return Ok(result);
        }

        /// <summary>Получить все посты</summary>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Перечисление всех постов</returns>
        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPostsAsync(CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsAsync(Cancel);
            return Ok(result);
        }

        /// <summary>Получить все посты пользователя по его идентификатору</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Перечисление всех постов пользователя</returns>
        [HttpGet("posts/users/{UserId}")]
        public async Task<IActionResult> GetAllPostsByUserIdAsync(string UserId, CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsByUserIdAsync(UserId, Cancel);
            return Ok(result);
        }

        /// <summary>Получить все страницы с постами пользователя по его идентификатору (есть TODO блок)</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="PageIndex">Номер страницы</param>
        /// <param name="PageSize">Размер страницы</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Страница с перечислением всех постов пользователя</returns>
        [HttpGet("posts/users/{UserId}/pages/{PageIndex}-{PageSize}")]
        public async Task<IActionResult> GetAllPostsByUserIdPageAsync(string UserId, int PageIndex, int PageSize, CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsByUserIdPageAsync(UserId, PageIndex, PageSize, Cancel);
            return Ok(result);
        }

        /// <summary>Получить определённое количество постов пользователя</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="Skip">Количество пропускаемых элементов</param>
        /// <param name="Take">Количество получаемых элементов</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Перечисление постов пользователя</returns>
        [HttpGet("posts/users/{UserId}/{Skip}-{Take}")]
        public async Task<IActionResult> GetAllPostsByUserIdSkipTakeAsync(string UserId, int Skip, int Take, CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsByUserIdSkipTakeAsync(UserId, Skip, Take, Cancel);
            return Ok(result);
        }

        /// <summary>Получить число постов</summary>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Число постов</returns>
        [HttpGet("posts/count")]
        public async Task<IActionResult> GetAllPostsCountAsync(CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsCountAsync(Cancel);
            return Ok(result);
        }

        /// <summary>Получить страницу со всеми постами</summary>
        /// <param name="PageIndex">Номер страницы</param>
        /// <param name="PageSize">Размер страницы</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Страница с постами</returns>
        [HttpGet("posts/pages/{PageIndex}/{PageSize}")]
        public async Task<IActionResult> GetAllPostsPageAsync(int PageIndex, int PageSize, CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsPageAsync(PageIndex, PageSize, Cancel);
            return Ok(result);
        }

        /// <summary>Получить определённое количество постов из всех</summary>
        /// <param name="Skip">Количество пропускаемых элементов</param>
        /// <param name="Take">Количество получаемых элементов</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Перечисление постов</returns>
        [HttpGet("posts/{Skip}-{Take}")]
        public async Task<IActionResult> GetAllPostsSkipTakeAsync(int Skip, int Take, CancellationToken Cancel = default)
        {
            var result = await _manager.GetAllPostsSkipTakeAsync(Skip, Take, Cancel);
            return Ok(result);
        }

        /// <summary>Получить тэги к посту по его идентификатору</summary>
        /// <param name="Id">Идентификатор поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Перечисление тэгов</returns>
        [HttpGet("posts/{Id}/tags")]
        public async Task<IActionResult> GetBlogTagsAsync(int Id, CancellationToken Cancel = default)
        {
            var result = await _manager.GetBlogTagsAsync(Id, Cancel);
            return Ok(result);
        }

        /// <summary>Получение поста по его идентификатору</summary>
        /// <param name="Id">Идентификатор поста</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Найденный пост или <b>null</b></returns>
        [HttpGet("posts/{Id}")]
        public async Task<IActionResult> GetPostAsync(int Id, CancellationToken Cancel = default)
        {
            var result = await _manager.GetPostAsync(Id,Cancel);
            return Ok(result);
        }

        /// <summary>Получить посты по тэгу</summary>
        /// <param name="Tag">Тэг</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Перечисление постов</returns>
        [HttpGet("posts/tags/{Tag}")]
        public async Task<IActionResult> GetPostsByTag(string Tag, CancellationToken Cancel = default)
        {
            var result = await _manager.GetPostsByTag(Tag, Cancel);
            return Ok(result);
        }

        /// <summary>Получить количество постов пользователя</summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Количество постов</returns>
        [HttpGet("posts/users/{UserId}/count")]
        public async Task<IActionResult> GetUserPostsCountAsync(string UserId, CancellationToken Cancel = default)
        {
            var result = await _manager.GetUserPostsCountAsync(UserId, Cancel);
            return Ok(result);
        }

        /// <summary>Удалить тэг с поста</summary>
        /// <param name="PostId">Идентификатор поста</param>
        /// <param name="Tag">Тэг</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Истина, если тэг был удалён успешно</returns>
        [HttpDelete("posts/{PostId}/tag/{Tag}")]
        public async Task<IActionResult> RemoveTagAsync(int PostId, string Tag, CancellationToken Cancel = default)
        {
            var result = await _manager.RemoveTagAsync(PostId, Tag, Cancel);
            return Ok(result);
        }
    }
}
