using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Articles.BusinessLayer;
using NewsPaper.Articles.Models;

namespace NewsPaper.Articles.Controllers
{
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        OperationArticles articles = new OperationArticles();

        [HttpGet("getarticles")]
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await articles.GetAllArticlesAsync();
        }

        [HttpGet("getarticlesbyauthor")]
        public async Task<IActionResult> GetArticlesById(Guid authorGuid)
        {
            return Ok( await articles.GetArticlesByAuthor(authorGuid));
        }
    }
}
