using DoAN_S4.Areas.Admin.Models.ViewModel;
using DoAN_S4.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel.IRepository
{
     public interface IRepositoryComment : IRepositoryGeneric<Comment, string>
    {
        List<Comment> Paging(int page, int pagesize, out long totalpage);
        List<Comment> SearchPaging(string name, int page, int pagesize, out long totalpage);
        List<CommentViewModel> GetCommentFull();
        
    }
}
