using DoAN_S4.Models.DataModel;
using System.Collections.Generic;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository
{
    public interface IRepositorySize :IRepositoryGeneric<Size, int>
    {
        List<Size> Paging(int page, int pagesize, out long totalpage);
        List<Size> SearchPaging(string name, int page, int pagesize, out long totalpage);
    }
}
