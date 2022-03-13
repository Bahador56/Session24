using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models
{
    public class ClassRoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte AgeRange { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public List<SelectListItem> SchoolSelectList { get; set; }
    }
}
