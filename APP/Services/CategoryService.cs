using APP.Domain;
using APP.Models;
using CORE.APP.Models;
using CORE.APP.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APP.Services
{
    public class CategoryService : Service<Category>, IService<CategoryRequest, CategoryResponse>
    {
        public CategoryService(DbContext db) : base(db)
        {
        }

        public List<CategoryResponse> List()
        {
            var query = Query().Select(c => new CategoryResponse
            {
                Id = c.Id,
                Guid = c.Guid,
                Name = c.Name,
                Description = c.Description
            });
            return query.ToList();
        }

        public CategoryResponse Item(int id)
        {
            var entity = Query().SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return null;
            return new CategoryResponse
            {
                Id = entity.Id,
                Guid = entity.Guid,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public CategoryRequest Edit(int id)
        {
            var entity = Query().SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return null;
            return new CategoryRequest
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public CommandResponse Create(CategoryRequest request)
        {
            if (Query().Any(c => c.Name == request.Name.Trim()))
                return Error("Category with the same name exists!");
            var entity = new Category
            {
                Name = request.Name,
                Description = request.Description
            };
            Create(entity);
            return Success("Category created successfully.", entity.Id);
        }

        public CommandResponse Update(CategoryRequest request)
        {
            if (Query().Any(c => c.Id != request.Id && c.Name == request.Name.Trim()))
                return Error("Category with the same name exists!");
            var entity = Query(false).SingleOrDefault(c => c.Id == request.Id);
            if (entity is null)
                return Error("Category not found!");
            entity.Name = request.Name;
            entity.Description = request.Description;
            Update(entity);
            return Success("Category updated successfully.", entity.Id);
        }

        public CommandResponse Delete(int id)
        {
            var entity = Query(false).Include(c => c.Footballers).SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return Error("Category not found!");
            if (entity.Footballers != null && entity.Footballers.Count > 0)
                return Error("Cannot delete category that has footballers.");
            Delete(entity);
            return Success("Category deleted successfully.", entity.Id);
        }
    }
}


