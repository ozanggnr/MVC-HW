using APP.Domain;
using APP.Models;
using CORE.APP.Models;
using CORE.APP.Services;
using Microsoft.EntityFrameworkCore;

namespace APP.Services
{
    public class FootballerService : Service<Footballer>, IService<FootballerRequest, FootballerResponse>
    {
        public FootballerService(DbContext db) : base(db)
        {

        }

        public List<FootballerResponse> List()
        {
            var query = Query().Select(a => new FootballerResponse
            {
                Id = a.Id,
                Name = a.Name,
                Surname = a.Surname,
                Position = a.Position,
                ShirtNumber = a.ShirtNumber,
                DateOfBirth = a.DateOfBirth,
                National = a.National,
                Foot = a.Foot,
                IsInjured = a.IsInjured,

                FullName = a.Name + " " + a.Surname,
                BirthDateF = a.DateOfBirth.ToString("dd/MM/yyyy"),
                ShirtNumberF = a.ShirtNumber,
                IsInjuredF = a.IsInjured
            });
            return query.ToList();
        }
        public FootballerResponse Item(int id)
        {
            var entity = Query().SingleOrDefault(a => a.Id == id);
            if (entity is null)
                return null;
            return new FootballerResponse()
            {
                Id = entity.Id,
                Guid = entity.Guid,
                Name = entity.Name,
                Surname = entity.Surname,
                Position = entity.Position,
                ShirtNumber = entity.ShirtNumber,
                National = entity.National,
                Foot = entity.Foot,
                IsInjured = entity.IsInjured,
                DateOfBirth = entity.DateOfBirth,

                FullName = entity.Name + " " + entity.Surname,
                IsInjuredF = entity.IsInjured,
                BirthDateF = entity.DateOfBirth.ToString("MM/dd/yyyy HH:mm:ss")
            };
        }

        public CommandResponse Create(FootballerRequest request)
        {
            if (Query().Any(s => s.Name == request.Name.Trim() && s.Surname == request.Surname.Trim()))
                return Error("Footballer with the same name and surname exists!");
            var entity = new Footballer
            {
                Name = request.Name,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                IsInjured = request.IsInjured,
                National = request.National,
                Foot = request.Foot,
                Position = request.Position,
                ShirtNumber = request.ShirtNumber

            };
            Create(entity);
            return Success("Footballer created successfully.", entity.Id);
        }

        public CommandResponse Update(FootballerRequest request)
        {
            if (Query().Any(s => s.Id != request.Id && s.Name == request.Name.Trim() && s.Surname == request.Surname.Trim()))
                return Error("Footballer with the same name and surname exists!");
            var entity = Query(false).SingleOrDefault(s => s.Id == request.Id);
            if (entity is null)
                return Error("Footballer not found!");

            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.DateOfBirth = request.DateOfBirth;
            entity.IsInjured = request.IsInjured;
            entity.National = request.National;
            entity.Foot = request.Foot;
            entity.Position = request.Position;
            entity.ShirtNumber = request.ShirtNumber;


            Update(entity);
            return Success("Footballer updated successfully.", entity.Id);
        }

        public CommandResponse Delete(int id)
        {
            var entity = Query(false).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return Error("Footballer not found!");
            Delete(entity);
            return Success("Footballer deleted successfully.", entity.Id);
        }

        public FootballerRequest Edit(int id)
        {
            var entity = Query().SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return null;
            return new FootballerRequest()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                DateOfBirth = entity.DateOfBirth,
                IsInjured = entity.IsInjured,
                National = entity.National,
                Foot = entity.Foot,
                Position = entity.Position,
                ShirtNumber = entity.ShirtNumber

            };
        }
    }
}
