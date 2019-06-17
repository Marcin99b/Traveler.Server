using Microsoft.AspNetCore.Mvc;
using Traveler.Integration.RoverMachine.Steering;
using Traveler.Web.Areas.Steering.Models;

namespace Traveler.Web.Areas.Steering.Controllers
{
    public class SteeringController : BaseApiController
    {
        private readonly ISteeringService steeringService;

        public SteeringController(ISteeringService steeringService)
        {
            this.steeringService = steeringService;
        }

        [HttpPost]
        public IActionResult SetSteering([FromBody] SetSteeringRequest request)
        {
            return Ok();
        }

    }
}
