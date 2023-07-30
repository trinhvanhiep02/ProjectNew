using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.Reposity
{
    public class RepositorySize : IRepositorySize
    {
        DbConText db;
        public RepositorySize(DbConText db)
        {
            this.db = db;
        }

        public bool Delete(int key)
        {
            try
            {
                db.sizes.DeleteOne(x => x._id == key);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public List<Size> getAll()
        {
            return db.sizes.Find(FilterDefinition<Size>.Empty).ToList();
        }

        public Size GetByID(int key)
        {
            return db.sizes.Find(x => x._id == key).FirstOrDefault();
        }

        public bool Insert(Size entity)
        {
            db.sizes.InsertOne(entity);
            return true;
        }

        public List<Size> Paging(int page, int pagesize, out long totalpage)
        {
            int skip = pagesize * (page - 1);
            long rows = db.sizes.CountDocuments(FilterDefinition<Size>.Empty);
            totalpage = rows % pagesize == 0 ? rows / pagesize : (rows / pagesize) + 1;
            return db.sizes.Find(FilterDefinition<Size>.Empty).Skip(skip).Limit(pagesize).ToList();
        }

        public List<Size> SearchPaging(string name, int page, int pagesize, out long totalpage)
        {
            int skip = pagesize * (page - 1);
            long rows = db.sizes.CountDocuments(x => x.SizeName.ToLower().Contains(name.ToLower()));
            totalpage = rows % pagesize == 0 ? rows / pagesize : (rows / pagesize) + 1;
            return db.sizes.Find(x => x.SizeName.ToLower().Contains(name.ToLower())).Skip(skip).Limit(pagesize).ToList();
        }

        public bool Update(Size entity)
        {
            var p = Builders<Size>.Update
                .Set("SizeName", entity.SizeName)
                .Set("Status", entity.Status);
            db.sizes.UpdateOne(x => x._id == entity._id, p);
            return true;
        }
    }
}
