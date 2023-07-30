using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Models.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.Reposity
{
    public class RepositoryDiscoutCode : IRepositoryDiscoutCode
    {

        DbConText db;
        public RepositoryDiscoutCode( DbConText db)
        {
            this.db = db;
        }

        public bool Delete(string key)
        {
            try
            {
                db.codes.DeleteOne(x => x._id == key);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public List<Discout_Code> getAll()
        {
            return db.codes.Find(FilterDefinition<Discout_Code>.Empty).ToList();
        }

        public Discout_Code GetByID(string key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Discout_Code entity)
        {
            db.codes.InsertOne(entity);
            return true;
        }

        public List<Discout_Code> Paging(int page, int pagesize, out long totalpage)
        {
            throw new NotImplementedException();
        }

        public List<Discout_Code> SearchPaging(string name, int page, int pagesize, out long totalpage)
        {
            throw new NotImplementedException();
        }

        public bool Update(Discout_Code entity)
        {
            var c = Builders<Discout_Code>.Update.Set("code", entity.Code);
            db.codes.UpdateOne(x => x._id == entity._id, c);
            return true;
        }
    }
}
