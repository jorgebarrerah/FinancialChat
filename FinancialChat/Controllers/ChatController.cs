﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialChat.Controllers
{
    public class ChatController : Controller
    {

        public static Dictionary<int, string> Rooms =
            new Dictionary<int, string>
            {
                {1, "Room 1" },
                {2, "Room 2" },
                {3, "Room 3" }
            };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Room(int room)
        {
            return View("Room", room);
        }
    }
}
