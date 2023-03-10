using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQuery:IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _repository;
            private readonly IMapper _mapper;

            public GetAllProductQueryHandler(IProductRepository repository,IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var product=await _repository.GetAllAsync();

                var viewModel=_mapper.Map<List<ProductViewDto>>(product);

                return new ServiceResponse<List<ProductViewDto>> (viewModel);
            }
        }
    }
}
