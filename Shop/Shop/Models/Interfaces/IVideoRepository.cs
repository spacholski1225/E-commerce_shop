using Shop.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Interfaces
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetAllVideos();
        Video GetVideoById(int id);
        Video Add(Video video);
        Video Delete(Video video);
        Video Update(Video video);
    }
}
