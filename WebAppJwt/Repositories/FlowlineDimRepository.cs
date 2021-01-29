using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppJwt.Dtos;
using WebAppJwt.Models;

namespace WebAppJwt.Repositories
{
    public interface IFlowlineDimRepository
    {
        List<FlowlineDimDto> GetAllFlowLineDim();
    }
    public class FlowlineDimRepository : IFlowlineDimRepository
    {
        SetDefaultValues defaultVal = new SetDefaultValues();
        public List<FlowlineDimDto> GetAllFlowLineDim()
        {
            return defaultVal.GetAllFlowLineDim();
        }
    }
}
