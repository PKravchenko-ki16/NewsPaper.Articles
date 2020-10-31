using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.Models;
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

        [HttpGet("getarticles")]
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _operationArticles.GetAllArticlesAsync();
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
