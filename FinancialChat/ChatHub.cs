using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;

namespace FinancialChat
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string room, string user, string message)
        {            
            string stockCode = string.Empty;
            if (message.Contains("/stock=") && message.Length > 7)
            {
                message = await GetStock(message);
            }

            await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
        }

        public async Task ConnectToRoom(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }


        private static async Task<string> GetStock(string message)
        {
            string stockServiceURL = System.Configuration.ConfigurationManager.AppSettings["stockServiceURL"];
            string stockCode = message.Replace("/stock=", "");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            message = await client.GetStringAsync("https://localhost:44342/api/Stock?stockCode=" + stockCode);

            return message;
        }
    }
}
