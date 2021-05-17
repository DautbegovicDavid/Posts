using AutoMapper;
using Posts.Model.Requests;
using Posts.Model;
using System.Linq;

namespace Posts.API.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Models.Tag, Tag>().ReverseMap();
            CreateMap<Models.PostTag, PostTag>().ReverseMap();
            CreateMap<Post, Models.Post>();
            CreateMap<Models.Post, Post>()
                .ForMember(x => x.tagList, opt => opt.MapFrom
                     (y => y.tagList.Select(s => s.Tag.title.ToString())
                         .ToList()));
            CreateMap<PostInsertRequest, Models.Post>().ReverseMap();
            CreateMap<PostUpdateRequest, Models.Post>().ReverseMap();

        }
    }
}
