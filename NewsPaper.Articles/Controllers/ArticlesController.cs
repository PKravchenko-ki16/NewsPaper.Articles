using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.Models.Exceptions;

namespace NewsPaper.Articles.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private OperationArticles _operationArticles;

        public ArticlesController(OperationArticles operationArticles)
        {
            _operationArticles = operationArticles;
        }

        [HttpGet("getarticlebyid")]
        public async Task<IActionResult> GetArticleById(Guid articleGuid)
        {
            try
            {
                var result = await _operationArticles.GetByIdArticleAsync(articleGuid);
                return Ok(result);
            }
            catch (NoArticlesFoundForAuthorAppException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getarticles")]
        public async Task<IActionResult> GetArticles()
        {
            try
            {
                var result = await _operationArticles.GetAllArticlesAsync();
                return Ok(result);
            }
            catch (NoArticlesFoundForAuthorAppException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getarticlesbyauthor")]
        public async Task<IActionResult> GetArticlesById(Guid authorGuid)
        {
            try
            {
                var result = await _operationArticles.GetArticlesByAuthor(authorGuid);
                return Ok(result);
            }
            catch (NoArticlesFoundForAuthorAppException exception)
            {
                return Ok(exception);
            }
        }
    }
}
