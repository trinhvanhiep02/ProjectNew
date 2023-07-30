using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAN_S4.Models.DataModel;
using MongoDB.Driver;


namespace DoAN_S4.Areas.Admin.Models.BussinesModel
{
    public class RepositoryCategory : IRepositoryCategory
    {
        DbConText db;
        public RepositoryCategory  (DbConText db)
        {
            this.db = db;
        }
        public bool Delete(int key)
        {
            try
            {
                db.categories.DeleteOne(x => x._id == key);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public List<Category> getAll()
        {   
            return db.categories.Find(FilterDefinition<Category>.Empty).ToList();
        }

        public Category GetByID(int key)
        {
            return db.categories.Find(x => x._id == key).FirstOrDefault();
        }

        public bool Insert(Category entity)
        {
            db.categories.InsertOne(entity);
            return true;
        }

        public List<Category> Paging(int page, int pagesize, out long totalpage)
        {
            int skip = pagesize * (page - 1);
            long rows = db.categories.CountDocuments(FilterDefinition<Category>.Empty);
            totalpage = rows % pagesize == 0 ? rows / pagesize : (rows / pagesize) + 1;
            return db.categories.Find(FilterDefinition<Category>.Empty).Skip(skip).Limit(pagesize).ToList();
        }

        public List<Category> SearchPaging(string name, int page, int pagesize, out long totalpage)
        {
            int skip = pagesize * (page - 1);
            long rows = db.categories.CountDocuments(x => x.CategoryName.ToLower().Contains(name.ToLower()));
            totalpage = rows % pagesize == 0 ? rows / pagesize : (rows / pagesize) + 1;
            return db.categories.Find(x => x.CategoryName.ToLower().Contains(name.ToLower())).Skip(skip).Limit(pagesize).ToList();
        }

        public bool Update(Category entity)
        {
            var p = Builders<Category>.Update
               .Set("CategoryName", entity.CategoryName)
               .Set("Status", entity.Status);                                                                                                                           
            db.categories.UpdateOne(x => x._id == entity._id, p);
            return true;
        }
    }
}
