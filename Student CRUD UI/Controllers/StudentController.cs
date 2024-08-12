using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student_CRUD_UI.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace Student_CRUD_UI.Controllers
{
    public class StudentController : Controller
    {
        //API URL 
        private string url = "https://localhost:7030/api/Students/";

        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);

                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["edit_message"] = "Student edited..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Student deleted..";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }
    }

}
