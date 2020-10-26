using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Articles.BusinessLayer;

namespace NewsPaper.Articles.Controllers
{
    [Route("[controller]")]
    public class ArticlesController : Controller
    {
        public ArticlesController()
        {
        }

        [HttpGet("getarticles")]
        public async Task<IActionResult> GetArticles()
        {
            OperationArticles articles = new OperationArticles();
            return Ok(articles.GetAllArticles());
        }
    }
}
