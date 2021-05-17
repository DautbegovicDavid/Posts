using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Posts.API.Database;
using Posts.Model.Requests;
using Posts.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Posts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PostsContext _context;
        public PostsController(IMapper mapper, PostsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get(string? tag)
        {

            if (tag != null)
            {
                Models.Tag tagEntity = _context.Tags.Where(w => w.title == tag).FirstOrDefault();
                if (tagEntity != null)
                {
                    List<Models.Post> postsTemp = _context.PostsTags.Include(i => i.Post).
                            Where(w => w.TagID == tagEntity.TagID).
                                Select(s => s.Post).
                                    OrderByDescending(o => o.createdAt).
                                        ToList();

                    List<Models.Post> postsTemp1 = new List<Models.Post>();
                    foreach (Models.Post p in postsTemp)
                    {
                        postsTemp1.Add(_context.Posts.Include("tagList.Tag").Where(w => w.PostID == p.PostID).FirstOrDefault());
                    }
                    return _mapper.Map<List<Post>>(postsTemp1);
                }
                else
                {
                    return NotFound();
                }
            }

            List<Models.Post> posts = _context.Posts.Include("tagList.Tag").
                    OrderByDescending(o => o.createdAt).
                        ToList();
            return _mapper.Map<List<Post>>(posts);

        }
        [HttpPost]
        public ActionResult<Post> Post([FromBody] PostInsertRequest request)
        {
            var obj = _mapper.Map<Models.Post>(request);

            var check = _context.Posts.Where(w => w.title == request.title).FirstOrDefault();
            if (check != null)
            {
                return BadRequest();
            }

            obj.createdAt = DateTime.Now;
            obj.updatedAt = DateTime.Now;

            obj.slug = Helpers.Helper.GenerateSlug(request.title);

            _context.Posts.Add(obj);
            _context.SaveChanges();

            int PostID = obj.PostID;

            List<string> tags = _context.Tags.Select(s => s.title).ToList();
            List<int> tagsID = _context.Tags.Select(s => s.TagID).ToList();

            for (int i = 0; i < request.tagsList.Count; i++)
            {
                string reqTag = request.tagsList[i];

                bool tagStored = false;

                for (int j = 0; j < tags.Count; j++)
                {
                    string storedTag = tags[j];

                    if (reqTag == storedTag)
                    {
                        _context.PostsTags.Add(
                            new Models.PostTag
                            {
                                PostID = PostID,

                                TagID = tagsID[j]
                            });
                        _context.SaveChanges();
                        tagStored = true;
                        break;
                    }
                }
                if (!tagStored)
                {
                    Models.Tag newTag = new Models.Tag
                    {
                        title = reqTag
                    };
                    _context.Tags.Add(newTag);
                    _context.SaveChanges();

                    _context.PostsTags.Add(
                            new Models.PostTag
                            {
                                PostID = PostID,
                                TagID = newTag.TagID
                            });
                    _context.SaveChanges();
                }
            }

            var res = _context.Posts.Include("tagList.Tag").Where(w => w.PostID == PostID).FirstOrDefault();
            return _mapper.Map<Post>(res);
        }
        [HttpDelete("{slug}")]
        public ActionResult<Post> Delete(string slug)
        {
            var delete = _context.Posts.Include("tagList.Tag").Where(w => w.slug == slug).FirstOrDefault();
            if (delete == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(delete);
            _context.SaveChanges();
            return _mapper.Map<Post>(delete);
        }
        [HttpPut("{slug}")]
        public ActionResult<Post> Update(string slug, PostUpdateRequest request)
        {
            var entity = _context.Posts.Where(w => w.slug == slug).FirstOrDefault();
            if (entity == null)
            {
                return NotFound();
            }
            _context.Posts.Attach(entity);
            _context.Posts.Update(entity);
            _mapper.Map(request, entity);
            entity.updatedAt = DateTime.Now;
            entity.slug = Helpers.Helper.GenerateSlug(request.title);
            _context.SaveChanges();

            var res = _context.Posts.Include("tagList.Tag").Where(w => w.PostID == entity.PostID).FirstOrDefault();
            return _mapper.Map<Post>(res);

        }
        [HttpGet("{slug}")]
        public ActionResult<Post> GetBySlug(string slug)
        {
            var res = _context.Posts.Include("tagList.Tag").Where(w => w.slug == slug).FirstOrDefault();
            if (res == null)
                return NotFound();
            return _mapper.Map<Post>(res);
        }
    }
}
