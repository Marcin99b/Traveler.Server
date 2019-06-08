using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Traveler.Web.Areas
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : Controller
    {
    }
}
