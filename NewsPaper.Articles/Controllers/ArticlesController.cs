﻿using System;
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

        [HttpGet("getarticlesbyidauthor")]
        public async Task<IActionResult> GetArticlesByIdAuthor(Guid authorGuid)
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

        [HttpGet("goarchivearticle")]
        public async Task<IActionResult> GoArchiveArticle(Guid articleGuid)
        {
            try
            {
                var result = await _operationArticles.GoArchive(articleGuid);
                return Ok(result);
            }
            catch (FailedTransferToArchiveAppException exception)
            {
                return Ok(exception);
            }
        }

        [HttpPost("createarticle")]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            try
            {
                var result = await _operationArticles.CreateArticle(article);
                return Ok(result);
            }
            catch (FailedToCreateArticleAppException exception)
            {
                return Ok(exception);
            }
        }
    }
}
