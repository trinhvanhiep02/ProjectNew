using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using DoAN_S4.Models.DataModel;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel
{
    public class DbConText
    {
        IConfiguration Configuration;
        public DbConText(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public IMongoDatabase connections
        {
            get
            {
                var client = new MongoClient(Configuration.GetConnectionString("mongoconnection"));
                var database = client.GetDatabase(Configuration.GetConnectionString("database"));
                return database;
            }
        }
        public IMongoCollection<Category> categories => connections.GetCollection<Category>("Category");
        public IMongoCollection<Product> products => connections.GetCollection<Product>("Product");
        //public IMongoCollection<Product_Detail> products_details => connections.GetCollection<Product_Detail>("ProductDetail");
        //public IMongoCollection<Account> accounts => connections.GetCollection<Account>("Account");
        //public IMongoCollection<Blog> blogs => connections.GetCollection<Blog>("Blog");
        public IMongoCollection<Size> sizes => connections.GetCollection<Size>("Size");
        public IMongoCollection<Color> colors => connections.GetCollection<Color>("Color");
        public IMongoCollection<Comment> comments => connections.GetCollection<Comment>("Comment");
        //public IMongoCollection<Contact> contacts => connections.GetCollection<Contact>("Contact");
        public IMongoCollection<Discout_Code> codes => connections.GetCollection<Discout_Code>("DiscoutCode");
        //public IMongoCollection<Order> orders => connections.GetCollection<Order>("Order");
        //public IMongoCollection<Order_detail> order_detail => connections.GetCollection<Order_detail>("Orderdetail");
    }
}
