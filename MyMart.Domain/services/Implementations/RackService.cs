using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyMart.DAL.Entities;
using MyMart.DAL.Repositories;
using MyMart.Domain.Models.Request;
using MyMart.Domain.Models.Response;

namespace MyMart.Domain.services.Implementations
{
    public class RackService : IRackService
    {
        private readonly IRackRepo _repo;
        private readonly IMapper _mapper;

        public RackService(IRackRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<RackResponse> CreateAsync(RackRequest data)
        {
            var rack = _mapper.Map<RackRequest, Rack>(data);
            var createdRack = await _repo.InsertAsync(rack);
            var rackRes = _mapper.Map<Rack, RackResponse>(createdRack);
            return rackRes;
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RackResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RackResponse> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<RackResponse> UpdateAsync(long id, RackRequest data)
        {
            throw new NotImplementedException();
        }
    }
}
