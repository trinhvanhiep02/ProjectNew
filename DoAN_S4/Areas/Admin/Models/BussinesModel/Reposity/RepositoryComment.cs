using DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository;
using DoAN_S4.Areas.Admin.Models.ViewModel;
using DoAN_S4.Models.DataModel;
using MongoDB.Bson;
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




        public List<CommentViewModel> GetCommentFull()
        {
            BsonDocument[] lookup = new BsonDocument[2]
           {
                new BsonDocument
                {
                    {
                        "$lookup",new BsonDocument
                        {
                            {"from","accounts" },
                            {"localField","Id_Account" },
                            {"foreignField","_id" },
                            {"as","accounts" }
                        }
                    }
                },
                 new BsonDocument
                {
                    {
                        "$lookup",new BsonDocument
                        {
                            {"from","products" },
                            {"localField","Id_Product " },
                            {"foreignField","_id" },
                            {"as","products" }
                        }
                    }
                }

           };
            var comments = db.comments.Aggregate<BsonDocument>(lookup).ToList();
            var data = new List<CommentViewModel>();
            foreach (var c in comments)
            {
                var comen = new CommentViewModel();
                comen._id = c["_id"].ToString();
                comen.Name = c["accounts"].AsBsonArray[1]["Name"].ToString();
                comen.ProductName = c["products"].AsBsonArray[1]["ProductName"].ToString();
                comen.Content = c["Content"].ToString();
                comen.DateTime = c["DateTime"].ToString();
                data.Add(comen);
            }
            return data;
        }
    }
}
