 namespace AspNetCoreTemplate.Web.ViewModels.Home
{
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AutoMapper;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";

        /* public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, IndexCategoryViewModel>()
                .ForMember(x => x.Url, c => c.MapFrom(e => "/f/" + e.Name.Replace(' ', '-')));
        } */
    }
}
