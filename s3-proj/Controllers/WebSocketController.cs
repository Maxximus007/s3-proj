using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace s3_proj.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class WebsocketController : ControllerBase
    {
        private string text = "hello";
        private readonly ILogger<WebsocketController> _logger;

        public WebsocketController(ILogger<WebsocketController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                await SendAdvertisment(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        /*private async Task Advertisments(WebSocket webSocket)
        {          
            var task = Task.Run(() => SendAdvertisment(webSocket));
        }

        /*private async Task SendAdvertisment(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            var serverMsg = Encoding.UTF8.GetBytes($"Hello");
            await webSocket.SendAsync(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }*/

        private async Task SendAdvertisment(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            int switchtext = 1;
            while (!result.CloseStatus.HasValue)
            {
                switch (switchtext)
                {
                    case 1:
                        text = "Subscribe to the newsletter for an additional 10% discount";
                        switchtext++;
                        break;
                    case 2:
                        text = "Use BlackFriday15 for an additional 15% discount";
                        switchtext++;
                        break;
                    case 3:
                        text = "New assault rifles will be added at 29-11-2021, stay tuned!";
                        switchtext = 1;
                        break;
                }

                var serverMsg = Encoding.UTF8.GetBytes(text);
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);

                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
