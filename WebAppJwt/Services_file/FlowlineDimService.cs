using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppJwt.Dtos;
using WebAppJwt.Repositories;

namespace WebAppJwt.Services_file
{
    public interface IFlowlineDimService 
    {
        List<FlowlineDimDto> GetAllFlowLineDim();
    }
    public class FlowlineDimService : IFlowlineDimService
    {
        private readonly IFlowlineDimRepository _flowLineDimRepo;

        public FlowlineDimService(IFlowlineDimRepository flowLineDimRepo)
        {
            _flowLineDimRepo = flowLineDimRepo;
        }

        public List<FlowlineDimDto> GetAllFlowLineDim()
        {
            return _flowLineDimRepo.GetAllFlowLineDim();
        }

    }
}
