using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicMVC.Areas.ViewModels.DepartmentVMs
{
    public class BatchAssignVM
    {
        public int CategoryId {  get; set; }  
        public List<SelectListItem> AllServices { get; set; }
        public List<int> DoctorIds {  get; set; }
        public int DepartmentId { get; internal set; }
    }
}
