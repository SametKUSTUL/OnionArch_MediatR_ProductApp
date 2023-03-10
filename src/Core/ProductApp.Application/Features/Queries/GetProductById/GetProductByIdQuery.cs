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

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
        {
            IProductRepository _repository;
            IMapper _mapper;

            public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = _repository.GetByIdAsync(request.Id);
                var responseModel=_mapper.Map<ProductViewDto>(product.Result);
                return new ServiceResponse<ProductViewDto>(responseModel);
            }
        }

    }
}
