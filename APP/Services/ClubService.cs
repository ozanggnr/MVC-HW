using APP.Domain;
using APP.Models;
using CORE.APP.Models;
using CORE.APP.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APP.Services
{
    public class ClubService : Service<Club>, IService<ClubRequest, ClubResponse>
    {
        public ClubService(DbContext db) : base(db)
        {
        }

        public List<ClubResponse> List()
        {
            var query = Query().Select(c => new ClubResponse
            {
                Id = c.Id,
                Guid = c.Guid,
                Name = c.Name,
                Stadium = c.Stadium
            });
            return query.ToList();
        }

        public ClubResponse Item(int id)
        {
            var entity = Query().SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return null;
            return new ClubResponse
            {
                Id = entity.Id,
                Guid = entity.Guid,
                Name = entity.Name,
                Stadium = entity.Stadium
            };
        }

        public ClubRequest Edit(int id)
        {
            var entity = Query().SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return null;
            return new ClubRequest
            {
                Id = entity.Id,
                Name = entity.Name,
                Stadium = entity.Stadium
            };
        }

        public CommandResponse Create(ClubRequest request)
        {
            if (Query().Any(c => c.Name == request.Name.Trim()))
                return Error("Club with the same name exists!");
            var entity = new Club
            {
                Name = request.Name,
                Stadium = request.Stadium
            };
            Create(entity);
            return Success("Club created successfully.", entity.Id);
        }

        public CommandResponse Update(ClubRequest request)
        {
            if (Query().Any(c => c.Id != request.Id && c.Name == request.Name.Trim()))
                return Error("Club with the same name exists!");
            var entity = Query(false).SingleOrDefault(c => c.Id == request.Id);
            if (entity is null)
                return Error("Club not found!");
            entity.Name = request.Name;
            entity.Stadium = request.Stadium;
            Update(entity);
            return Success("Club updated successfully.", entity.Id);
        }

        public CommandResponse Delete(int id)
        {
            var entity = Query(false).SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return Error("Club not found!");
            Delete(entity);
            return Success("Club deleted successfully.", entity.Id);
        }
    }
}


