using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDTOs;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDTO>>("Contacts");
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync("Contacts/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            await _client.PostAsJsonAsync("Contacts", createContactDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateContactDTO>("Contacts/" + id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            await _client.PutAsJsonAsync("Contacts", updateContactDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("Contacts/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("Contacts/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}