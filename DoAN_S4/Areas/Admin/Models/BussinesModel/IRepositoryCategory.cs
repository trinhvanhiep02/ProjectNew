using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAN_S4.Models.DataModel;


namespace DoAN_S4.Areas.Admin.Models.BussinesModel
{
    public interface IRepositoryCategory :IRepositoryGeneric <Category, int>
    {
        List<Category> Paging(int page, int pagesize, out long totalpage);
        List<Category> SearchPaging(string name, int page, int pagesize, out long totalpage);
    }
}
