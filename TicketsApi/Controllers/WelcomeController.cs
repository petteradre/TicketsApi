using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpPost]
        public string welcomeMessage()
        {
            string Message = "Welcome to Ticket API";
            return Message;
        }
    }
}
