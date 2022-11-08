using AutoMapper;
using ChallengeBackEnd5.Data;
using ChallengeBackEnd5.Data.DTOs.Categoria;
using ChallengeBackEnd5.Models;

namespace ChallengeBackEnd5.Repository
{
    public class categoryRepo
    {
        public AppDbContext _context;
        public IMapper _mapper;

        public categoryRepo(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Categoria> GetAll()
        {
            var result = _context.categorias.ToList();

            return result;
        }

        public ReadCategoriaDTO GetById(int id)
        {
            try
            {
                var result = _context.categorias.FirstOrDefault(x => x.Id == id);
                var mappedResult = _mapper.Map<ReadCategoriaDTO>(result);
                return mappedResult;
            }
            catch
            {
                throw new Exception();
            }
           
        }

        public Categoria Post(CreateCategoriaDTO categoriaDTO)
        {
            try
            {
                var result = _mapper.Map<Categoria>(categoriaDTO);
                _context.Add(result);
                _context.SaveChanges();
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }

        public Categoria Patch(int id,PatchCategoriaDTO categoriaDTO)
        {
            var result = _context.categorias.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return null;
            try
            {
                _mapper.Map(categoriaDTO, result);
                _context.SaveChanges();
                result.Id = id;
                return result;
            }
            catch
            {
                throw new Exception();
            }
            

        }

        public Categoria Delete(int id)
        {    
            if(id == 1)
            {
                throw new Exception();
            }
            try
            {
                var result = _context.categorias.FirstOrDefault(x => x.Id == id);
                _context.Remove(result);
                _context.SaveChanges();
                return result;
            }
            catch
            {
                throw new Exception();
            }
           
        }

        public object GetVideoByCategory(int id)
        {
            var query = _context.categorias.FirstOrDefault(x => x.Id == id);
            if (query == null)
                return null;

           var mappedResult = _mapper.Map<ReadCategoriaDTO>(query);

            return mappedResult.videos;

            
        }
    }
}
