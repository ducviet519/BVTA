using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface IUnitOfWork
    {
        ILoginRepository Login { get; }
        IProductRepository Products { get; }
        IChoKhamRepository DanhSachChoKham { get; }
        IPhongKhamRepository PhongKham { get; }
    }
}
