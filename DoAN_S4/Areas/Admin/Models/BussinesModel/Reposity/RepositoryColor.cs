using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.Reposity
{
    public class RepositoryColor : IRepositotyColor
    {
        DbConText db;
        public RepositoryColor(DbConText db)
        {
            this.db = db;
        }
        public bool Delete(int key)
        {
            try
            {
                db.colors.DeleteOne(x => x._id == key);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public List<Color> getAll()
        {
            return db.colors.Find(FilterDefinition<Color>.Empty).ToList();
        }

        public Color GetByID(int key)
        {
            return db.colors.Find(x => x._id == key).FirstOrDefault();
        }

        public bool Insert(Color entity)
        {
            db.colors.InsertOne(entity);
            return true;
        }

        public List<Color> Paging(int page, int pagesize, out long totalpage)
        {
            int skip = pagesize * (page - 1);
            long rows = db.colors.CountDocuments(FilterDefinition<Color>.Empty);
            totalpage = rows % pagesize == 0 ? rows / pagesize : (rows / pagesize) + 1;
            return db.colors.Find(FilterDefinition<Color>.Empty).Skip(skip).Limit(pagesize).ToList();
        }

        public List<Color> SearchPaging(string name, int page, int pagesize, out long totalpage)
        {
            int skip = pagesize * (page - 1);
            long rows = db.colors.CountDocuments(x => x.ColorName.ToLower().Contains(name.ToLower()));
            totalpage = rows % pagesize == 0 ? rows / pagesize : (rows / pagesize) + 1;
            return db.colors.Find(x => x.ColorName.ToLower().Contains(name.ToLower())).Skip(skip).Limit(pagesize).ToList();
        }

        public bool Update(Color entity)
        {
            var p = Builders<Color>.Update
                           .Set("ColorName", entity.ColorName)
                           .Set("Status", entity.Status);
            db.colors.UpdateOne(x => x._id == entity._id, p);
            return true;
        }
    }
}
