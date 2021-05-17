using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Posts.API.Database;
using Posts.Model;
using System.Collections.Generic;
using System.Linq;

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
