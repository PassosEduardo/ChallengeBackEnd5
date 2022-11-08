using AutoMapper;
using ChallengeBackEnd5.Data;
using ChallengeBackEnd5.Data.DTOs;
using ChallengeBackEnd5.Data.DTOs.Video;
using ChallengeBackEnd5.Models;

namespace ChallengeBackEnd5.Repository
{
    public class videoRepo
    {

        public AppDbContext _context;
        public IMapper _mapper;

        public videoRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadVideoDTO> GetAll()
        {
            try
            {
                var query = _context.videos.ToList();
                var mappedResult = _mapper.Map<List<ReadVideoDTO>>(query);
                return mappedResult;
            }
            catch
            {
                return null;
            }
            
        }

        public Video GetById(int id)
        {
            try
            {
                return _context.videos.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public Video PostVideo(CreateVideoDTO videoDTO)
        {
            try
            {

                var video = _mapper.Map<Video>(videoDTO);
                SetCategoriaId(video);               
                _context.videos.Add(video);
                _context.SaveChanges();
                return video;
            }
            catch
            {
                return null;
            }
            
        }

        public Video PatchVideo(int id, PatchVideoDTO videoDTO)
        {
            var result = _context.videos.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return null;
            try
            {
                _mapper.Map(videoDTO, result);
                SetCategoriaId(result);
                _context.SaveChanges();
                return result;
            }
            catch
            {
                throw new Exception();
            }
            
            
        }

        public Video DeleteVideo(int id)
        {
            try
            {
                var result = _context.videos.FirstOrDefault(x => x.Id == id);
                _context.videos.Remove(result);
                _context.SaveChanges();
                return(result);
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public List<ReadVideoDTO> GetVideoFromQuery(string search)
        {
            var result = _context.videos
                .Where(videos => videos
                .Title
                .Contains(search))
                .ToList();

            var mappedResult = _mapper.Map<List<ReadVideoDTO>>(result);

            return mappedResult;
        }

        public static void SetCategoriaId(Video video)
        {
            if (video.CategoriaId == 0)
            {
                video.CategoriaId = 1;
            }
            return;
        }
    }
}
