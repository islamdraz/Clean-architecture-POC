using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Post.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HCM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPostsController : ControllerBase
    {
        private IMediator _mediator;
      //  protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public StudentPostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task< IActionResult> Post([FromBody] StudentPostAddCommand request)
        {
           var result=await _mediator.Send(request);

           return Ok(result);
        }  

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ik");
        }
    }
}