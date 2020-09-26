using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LineNotifyProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LineNotifyProject.Controllers
{
    [Route("api/[controller]")]
    public class LineNotifyController : Controller
    {
        private readonly string _notifyUrl;
        public LineNotifyController(IConfiguration config)
        {
            _notifyUrl = "https://notify-api.line.me/api/notify";
        }

        // GET: api/LineNotify/SendMessage?token=PoyChang&message=HelloWorld
        /// <summary>傳送文字訊息</summary>
        /// <param name="token">令牌</param>
        /// <param name="message">訊息</param>
        [HttpGet]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(string token, string message)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_notifyUrl);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var form = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("message", message)
                });

                await client.PostAsync("", form);
            }

            return new EmptyResult();
        }

        // POST: api/LineNotify/SendMessage
        /// <summary>傳送文字訊息</summary>
        /// <param name="msg">訊息</param>
        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageModel msg)
        {
            var access_token = "XXREfnsKffhCaEpsSZQsfXknl1Dijg6MyiGwuGIaHWi";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_notifyUrl);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
                var name = msg.resource.createdBy.displayName;
                var uri = msg.resource._links.web.href;
                var message = $"{name} create a new pull request！\n {uri}";

                var form = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("message", message),

                });

                await client.PostAsync("", form);
            }

            return new EmptyResult();
        }
    }
}
