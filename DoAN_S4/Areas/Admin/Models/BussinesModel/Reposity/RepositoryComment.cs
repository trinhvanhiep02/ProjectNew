using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.Reposity
{
    public class RepositoryComment : IRepositoryComment
    {
        DbConText db;
        public RepositoryComment(DbConText db)
        {
            this.db = db;
        }
         
        public bool Delete(string key)
        {
            try
            {
                db.comments.DeleteOne(x => x._id == key);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public List<Comment> getAll()
        {
            return db.comments.Find(FilterDefinition<Comment>.Empty).ToList();
        }

        public Comment GetByID(string key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Comment entity)
        {
            db.comments.InsertOne(entity);
            return true;
        }

        public List<Comment> Paging(int page, int pagesize, out long totalpage)
        {
            throw new NotImplementedException();
        }

        public List<Comment> SearchPaging(string name, int page, int pagesize, out long totalpage)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment entity)
        {
            var c = Builders<Comment>.Update.Set("Content", entity.Content);
            db.comments.UpdateOne(x => x._id == entity._id, c);
            return true;
        }
    }
}
