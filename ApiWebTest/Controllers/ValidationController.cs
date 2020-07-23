using ApiWebTest.RequestRateLimit;
using HackerNews.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;

namespace ApiWebTest.Controllers
{
    /// <summary>
    /// Controller of Validation of API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private IHackerNewsClient Client;

        /// <summary>
        /// ValidationController Class
        /// </summary>
        public ValidationController(IHackerNewsClient client)
        {
            Client = client;
        }

        /// <summary>
        /// The API should return an array of the first 20 "best stories" as returned by the Hacker News API, sorted by their score in a descending order
        /// </summary>
        /// <returns>List with first 20 "best stories"</returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 10)]
        [ProducesResponseType(typeof(List<HackerNewsModel>), 200)]
        [ProducesResponseType(400)]
        public IActionResult ListTopStorys()
        {
            try
            {
                IList<HackerNewsModel> lstStoryes = Client.GetTopHackerNews();

                return Ok(lstStoryes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}