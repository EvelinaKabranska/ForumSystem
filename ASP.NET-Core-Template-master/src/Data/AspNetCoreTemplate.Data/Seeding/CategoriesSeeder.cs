namespace AspNetCoreTemplate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspNetCoreTemplate.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)> 
            {
                ("Sport", "https://www.hommenorthopedics.com/editor-uploads/website-755/multi-sports-blog-1530684776.jpg"),
                ("Coronavirus", "https://ec.europa.eu/programmes/erasmus-plus/sites/erasmusplus2/files/styles/erasmus__rewamp_overview/public/covid19-cdc-unsplash.jpg?itok=e02GjCQm"),
                ("News", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRhpiNON39UBXjwmFR3gLH78i-oQe9DWpDkSw&usqp=CAU"),
                ("Music", "https://images.macrumors.com/t/tCPS-yWwAQ_siFOl14cUWLHEw1c=/400x0/filters:quality(90)/article-new/2018/05/apple-music-note-800x420.jpg?lossy"),
                ("Programming", "https://itbrief.com.au/uploads/story/2018/11/26/ThinkstockPhotos-1054955998.jpg"),
                ("Cats", "https://cdn.britannica.com/24/212324-050-076731DA/Persian-cat-sleeping.jpg"),
                ("Dogs", "https://www.cesarsway.com/wp-content/uploads/2019/10/AdobeStock_190562703.jpeg"),
            };
            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageUrl=category.ImageUrl,
                });
            }
        }
    }
}
