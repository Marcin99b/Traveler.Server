using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traveler.Web.Areas.Steering.Models
{
    public class SetSteeringRequest
    {
        public int Power { get; set; }
        public int Steering { get; set; }
        public bool ReverseGear { get; set; }
    }
}
