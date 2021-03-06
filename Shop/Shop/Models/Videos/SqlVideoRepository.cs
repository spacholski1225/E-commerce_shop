using Shop.Data;
using Shop.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Models.Videos
{
    public class SqlVideoRepository : IVideoRepository
    {
        private readonly ShopDbContext _context;

        public SqlVideoRepository(ShopDbContext context)
        {
            _context = context;
        }

        Video IVideoRepository.Add(Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
            return video;
        }

        Video IVideoRepository.Delete(Video video)
        {
            _context.Videos.Remove(video);
            _context.SaveChanges();
            return video;
        }

        IEnumerable<Video> IVideoRepository.GetAllVideos()
        {
            return _context.Videos.ToList();
        }

        Video IVideoRepository.GetVideoById(int id)
        {
            return _context.Videos.FirstOrDefault(x => x.VideoId == id);
        }

        Video IVideoRepository.Update(Video video)
        {
            _context.Videos.Update(video);
            _context.SaveChanges();
            return video;
        }
    }
}
