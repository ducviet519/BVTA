using DataBVTA.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.ViewModels
{
    public class ThongTinBenhNhanVM
    {
        public ThongTinBenhNhan BenhNhan { get; set; } 

        public List<ThongTinBenhNhan> ListBenhNhan { get; set; }

        public IEnumerable<SelectListItem> ListBacSi { get; set; }

        public IEnumerable<SelectListItem> ListDieuDuong { get; set; }
    }
}
