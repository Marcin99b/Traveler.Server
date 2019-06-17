﻿using Microsoft.AspNetCore.Mvc;
using Traveler.Integration.RoverMachine.Steering;
using Traveler.Web.Areas.Steering.Models;

namespace Traveler.Web.Areas.Steering.Controllers
{
    public class SteeringController : BaseApiController
    {
        private readonly ISteeringService _steeringService;

        public SteeringController(ISteeringService steeringService)
        {
            this._steeringService = steeringService;
        }

        [HttpPost]
        public IActionResult SetSteering([FromBody] SetSteeringRequest request)
        {
            this._steeringService.UpdateSteeringInfo(request.Power, request.Steering);
            return Ok();
        }

    }
}