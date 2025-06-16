using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO.Models
{
    public class StudentFilterView
    {

        public string SelectedFilter { get; set; }
        public List<SelectListItem> FilterList { get; set; }

    }
}
