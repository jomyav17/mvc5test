using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;
using Microsoft.AspNet.Identity;

namespace Test1.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Deposit
        public ActionResult Deposit()
        {
            return View();
        }

        // GET: Transaction/Withdraw
        public ActionResult Withdraw()
        {
            return View();
        }

        // POST: Transaction/Deposit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(DepositViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = ApplicationDbContext.Create();
                    var checkingAccount = db.CheckingAccounts.Where(ac => ac.AccountNumber == vm.AccountNumber).FirstOrDefault();
                    if (checkingAccount == null)
                        throw new Exception("Invalid Account!!");
                    db.Transactions.Add(new Transaction { Amount = vm.Amount, TimeStamp = DateTime.Now, CheckingAccountId = checkingAccount.ID });
                    checkingAccount.Balance += vm.Amount;

                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    /////

                    var checkAcc = db.CheckingAccounts.Where(a => a.AccountNumber == vm.AccountNumber).FirstOrDefault();

                    /////
                    return RedirectToAction("Index", "Banking");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.ToString();
                return View();
            }
        }

        // POST: Transaction/Withdraw
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(WithdrawViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = ApplicationDbContext.Create();
                    var currentUserId = User.Identity.GetUserId();
                    var checkingAccount = db.CheckingAccounts.Where(ac => ac.ApplicationUserId == currentUserId && ac.AccountNumber == vm.AccountNumber).FirstOrDefault();
                    if (checkingAccount == null)
                        throw new Exception("Invalid Account!!");
                    if (checkingAccount.Balance < vm.Amount)
                        throw new Exception("Not enough balance!!");
                    db.Transactions.Add(new Transaction { Amount = -(vm.Amount), TimeStamp = DateTime.Now, CheckingAccountId = checkingAccount.ID });
                    checkingAccount.Balance -= vm.Amount;

                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Banking");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.ToString();
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
