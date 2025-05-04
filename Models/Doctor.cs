namespace ClinicMVC.Models
{
    public class Doctor:BaseModel
    {
        public string Name { get; set; }
        public string ImgUrl {  get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
