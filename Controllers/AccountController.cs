using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lab06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab06.Controllers
{
    public class AccountController : Controller
    {
        // Giả lập danh sách account (thay cho database)
        private static List<Account> accounts = new List<Account>();

        // GET: Account/Index
        public IActionResult Index()
        {
            return View(accounts);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                model.Id = accounts.Count + 1;
                accounts.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Remote Validation cho Phone
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(@"^(0[0-9]{9})$|^(0[0-9]{2})[.\s]?[0-9]{3}[.\s]?[0-9]{4}$");
            if (!_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }

            return Json(true);
        }

    }
}
