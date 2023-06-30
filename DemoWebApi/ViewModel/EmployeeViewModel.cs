namespace DemoWebApi.ViewModel
{
    public class EmployeeViewModel
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public required IFormFile Photo { get; set; }
    }

}
