using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppJwt.Dtos
{
    public class FlowlineDimDto
    {
        public int flineId { get; set; }
        public string outerDiameter { get; set; }
        public string wallThickness { get; set; }
        public string corrosionCoatingThickness { get; set; }
        public string concreteThickness { get; set; }
        public string pipeSurfaceRoughness { get; set; }
        public string amplificationFactorDrag { get; set; }
        public string amplificationFactLift { get; set; }
    }
}
