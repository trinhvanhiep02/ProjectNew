using DoAN_S4.Models.DataModel;
using System.Collections.Generic;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository
{
    public interface IRepositotyColor : IRepositoryGeneric<Color, int>
    {
        List<Color> Paging(int page, int pagesize, out long totalpage);
        List<Color> SearchPaging(string name, int page, int pagesize, out long totalpage);
    }
}
