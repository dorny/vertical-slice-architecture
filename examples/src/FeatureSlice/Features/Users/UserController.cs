using FeatureSlice.Core.Models;
using FeatureSlice.Features.Users.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureSlice.Features.Users
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAll()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(Guid id)
        {
            var query = new GetUsersQuery { Id = id };
            var result = (await _mediator.Send(query)).FirstOrDefault();
            return result;
        }
    }
}
