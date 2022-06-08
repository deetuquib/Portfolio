using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcademicManagement;

namespace Lab2.Pages
{
    public class RegistrationModel : PageModel
    {
        // binding properties
        [BindProperty]
        public string SelectedStudent { get; set; } = "-1";
        [BindProperty]
        public List<SelectListItem> CourseSelections { get; set; }
        [BindProperty]
        public string RegistrationStatus { get; set; }

        public void OnGet()
        {
        }

        public void OnPostStudentSelected()
        {
            // show student registration status
            if (SelectedStudent != "-1")
            {
                if (DataAccess.GetAcademicRecordsByStudentId(SelectedStudent).Count() == 0)
                {
                    RegistrationStatus = "This student has not registered any courses yet. Select the course(s) below to register.";
                } else
                {
                    RegistrationStatus = $"This student has registered {DataAccess.GetAcademicRecordsByStudentId(SelectedStudent).Count()} course(s): ";
                }
            } else
            {
                RegistrationStatus = "Please select student to view courses.";
            }
        }

        public void OnPostRegister()
        {
            int courseCounter = 0;
            foreach (SelectListItem item in CourseSelections)
            {
                if (item.Selected)
                {
                    AcademicRecord academicRecord = new AcademicRecord(SelectedStudent, item.Value);
                    DataAccess.AddAcademicRecord(academicRecord);
                    courseCounter++;
                }
            }

            if (courseCounter == 0) { RegistrationStatus = "Please select at least 1 (one) course!"; }
            else { RegistrationStatus = "This student has registered the following course(s): "; }
        }
    }
}
