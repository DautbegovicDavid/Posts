using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Posts.API.Database;
using Posts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PostsContext _context;
        public TagsController(IMapper mapper, PostsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            List<Models.Tag> tagovi = _context.Tags.ToList();
            return _mapper.Map<List<Tag>>(tagovi);
        }
    }
}
