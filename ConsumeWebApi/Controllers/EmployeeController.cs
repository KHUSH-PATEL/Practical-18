using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumeWebApi.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5022/api");
        private readonly HttpClient _httpClient;
        public EmployeeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            HttpResponseMessage responce = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/GetEmployee").Result;
            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employees = new EmployeeViewModel();
            HttpResponseMessage responce = _httpClient.GetAsync(_httpClient.BaseAddress + $"/Employee/GetEmployee/{id}").Result;
            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
            }
            return View(employees);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel emp)
        {
            try
            {
                string json = JsonConvert.SerializeObject(emp);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Employee/AddEmployee", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    // Employee added successfully
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle unsuccessful response
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, errorResponse);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employees = new EmployeeViewModel();
            HttpResponseMessage responce = _httpClient.GetAsync(_httpClient.BaseAddress + $"/Employee/GetEmployee/{id}").Result;
            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
            }
            return View(employees);
        }

        // POST: EmployeeController/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(EmployeeViewModel emp)
        {
            try
            {
                string json = JsonConvert.SerializeObject(emp);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"/Employee/UpdateEmployee/{emp.Id}", httpContent);


                if (response.IsSuccessStatusCode)
                {
                    // Employee added successfully
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle unsuccessful response
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, errorResponse);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employees = new EmployeeViewModel();
            HttpResponseMessage responce = _httpClient.GetAsync(_httpClient.BaseAddress + $"/Employee/GetEmployee/{id}").Result;
            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
            }
            return View(employees);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, EmployeeViewModel emp)
        {
            try
            {
                string json = JsonConvert.SerializeObject(emp);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"/Employee/DeleteEmployee/{id}", httpContent);


                if (response.IsSuccessStatusCode)
                {
                    // Employee added successfully
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle unsuccessful response
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, errorResponse);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
