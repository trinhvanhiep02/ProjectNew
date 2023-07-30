using DoAN_S4.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository
{
    public interface IRepositoryDiscoutCode : IRepositoryGeneric<Discout_Code, string>
    {
        List<Discout_Code> Paging(int page, int pagesize, out long totalpage);
        List<Discout_Code> SearchPaging(string name, int page, int pagesize, out long totalpage);
    }
}
