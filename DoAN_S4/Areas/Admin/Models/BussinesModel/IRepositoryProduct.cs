using DoAN_S4.Areas.Admin.Models.ViewModel;
using DoAN_S4.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel
{
    public interface IRepositoryProduct : IRepositoryGeneric<Product, string>
    {
        List<Product> Paging(int page, int pagesize, out long totalpage);
        List<Product> SearchPaging(string name, int page, int pagesize, out long totalpage);
        List<productViewModel> getProductFull();
    }
}
