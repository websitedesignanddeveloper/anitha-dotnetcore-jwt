using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppJwt.Dtos;
namespace WebAppJwt.Models
{
    public class SetDefaultValues
    {
        public List<FlowlineDimDto> GetAllFlowLineDim()
        {
            List<FlowlineDimDto> items = new List<FlowlineDimDto>()
            {
                new FlowlineDimDto()
                {
                 flineId = 1,
                 outerDiameter="609.6",
                 wallThickness="14.3",
                 corrosionCoatingThickness="6",
                 concreteThickness="50",
                 pipeSurfaceRoughness="5",
                 amplificationFactorDrag="1",
                 amplificationFactLift="1"
                },
            };

            return items;

        }


    }
}
