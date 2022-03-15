using log4net;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TEKenable.ProjectTemplate.Services;
using TEKenable.ProjectTemplate.Services.Entities;
using TEKenable.ProjectTemplate.Web.Infrastructure;
using TEKenable.ProjectTemplate.Web.Models.Admin;
using System.Net;

namespace TEKenable.ProjectTemplate.Web.Controllers
{
    [Authorized(Roles.Administrator)]
    public class AdminController : Controller
    {
        private ILog _log;
        private IAdminService _service;

        public AdminController(ILog log, IAdminService service)
        {
            _log = log;
            _service = service;
            _log.Debug("Admin Controller initialized");
        }

        public ActionResult Users(UserSearchModel model)
        {
            var query = BuildQuery(model);

            int pageNumber = (model.page ?? 1);

            model.ListData = query.ToPagedList(pageNumber, 5);
            return View(model);

        }

        private IQueryable<UserOutModel> BuildQuery(UserSearchModel model)
        {
            model.CurrentSort = model.sortOrder;

            model.SortParm = String.IsNullOrEmpty(model.sortOrder) ? "firstname_desc" : "";

            if (model.searchString != null)
            {
                model.page = 1;
            }
            else
            {
                model.searchString = model.currentFilter;
            }

            model.currentFilter = model.searchString;

            var query = from s in _service.GetUsers(model.searchString)
                        select new UserOutModel()
                        {
                            id = s.id,
                            user_name = s.user_name,
                            first_name = s.first_name,
                            last_name = s.last_name,
                            UserDepartment = s.UserDepartment,
                            EmployeeGrade = s.EmployeeGrade,
                            UserSalary = s.UserSalary
                        };

            switch (model.sortOrder)
            {
                case "Uflname":
                    query = query.OrderByDescending(s => s.first_name).ThenBy(s => s.last_name);
                    break;
                case "Uname":
                    query = query.OrderByDescending(s => s.user_name);
                    break;
                case "Udepartment":
                    query = query.OrderByDescending(s => s.UserDepartment);
                    break;
                case "Ugrade":
                    query = query.OrderByDescending(s => s.EmployeeGrade);
                    break;
                case "Usalary":
                    query = query.OrderByDescending(s => s.UserSalary);
                    break;
                default:  // Name ascending 
                    query = query.OrderBy(s => s.first_name);
                    break;
            }
            return query;
        }

        public ActionResult UserDetails(int? id)
        {
            UserInModel model = new UserInModel();

            var obj = _service.GetUser(id);

            if (obj == null)
            {
                //return HttpNotFound();
            }
            else
            {
                model.id = obj.id;
                model.first_name = obj.first_name;
                model.last_name = obj.last_name;
                model.password = obj.password;
                model.user_name = obj.user_name;
                model.UserDepartment = obj.UserDepartment;
                model.EmployeeGrade = obj.EmployeeGrade;
                model.UserSalary = obj.UserSalary;
                //model.UserAdded = obj.UserAdded;

                model.SelectedRoles = obj.Roles.Select(r => r.role_id).ToList();
            }
            UserDetailsBindControls(model.SelectedRoles);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserDetails(UserInModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUnique = !_service.IsUsernameExists(model.id, model.user_name);
                    
                    if (isUnique)
                    {

                        var obj = new User();
                        obj.id = model.id;
                        obj.first_name = model.first_name;
                        obj.last_name = model.last_name;
                        obj.user_name = model.user_name;
                        obj.password = model.password;
                        obj.UserDepartment = model.UserDepartment;
                        obj.EmployeeGrade = model.EmployeeGrade;
                        obj.UserSalary = model.UserSalary;
                        obj.Roles = _service.GetRoles().Where(r => model.SelectedRoles.Contains(r.role_id)).ToList();
                        _service.SaveUser(obj);

                        TempData["SuccessMessage"] = "Data saved successfully.";
                        return RedirectToAction("UserDetails", new { id = obj.id });
                    }
                    else
                    {
                        ModelState.AddModelError("", string.Format("Username '{0}' already in use, please enter another.", model.user_name));
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                ModelState.AddModelError("", ex.Message);
            }

            UserDetailsBindControls(model.SelectedRoles);

            return View(model);
        }

        private void UserDetailsBindControls(List<Int32> roles)
        {
            ViewBag.SelectedRoles = _service.GetRoles().ToList().Select(r => new SelectListItem()
            {
                Value = r.role_id.ToString(),
                Text = r.role_name,
                Selected = roles.Exists(sr => sr == r.role_id)
            }).ToList();
        }

        /////////////////////////CATEGORY MODEL ADMIN STARTS
        public ActionResult Companies(CompanySearchModel model)
        {
            var query = BuildQuery(model);

            int pageNumber = (model.page ?? 1);

            model.ListData = query.ToPagedList(pageNumber, 5);
            return View(model);

        }

        private IQueryable<CompanyOutModel> BuildQuery(CompanySearchModel model)
        {
            model.CurrentSort = model.sortOrder;

            model.SortParm = String.IsNullOrEmpty(model.sortOrder) ? "CompanyName_desc" : "";

            if (model.searchString != null)
            {
                model.page = 1;
            }
            else
            {
                model.searchString = model.currentFilter;
            }

            model.currentFilter = model.searchString;

            var query = from t in _service.GetCompanies(model.searchString)
                        select new CompanyOutModel()
                        {
                            CompanyId = t.CompanyId,
                            CompanyName = t.CompanyName,
                            CompanyType = t.CompanyType,
                            CompanyBusiness = t.CompanyBusiness,
                            CompanyDepartment = t.CompanyDepartment,
                            CompanyGrade = t.CompanyGrade,
                            CompanyWebsite = t.CompanyWebsite,
                            CompanyContact = t.CompanyContact,
                            CompanyEmail = t.CompanyEmail
                        };

            switch (model.sortOrder)
            {
                case "Cname":
                    query = query.OrderByDescending(s => s.CompanyName);
                    break;
                case "Ctype":
                    query = query.OrderByDescending(s => s.CompanyType);
                    break;
                case "Cbusiness":
                    query = query.OrderByDescending(s => s.CompanyBusiness);
                    break;
                case "Cdepartment":
                    query = query.OrderByDescending(s => s.CompanyDepartment);
                    break;
                case "Cgrade":
                    query = query.OrderByDescending(s => s.CompanyGrade);
                    break;
                case "Ccontact":
                    query = query.OrderByDescending(s => s.CompanyEmail);
                    break;
                default:  // Name ascending 
                    query = query.OrderBy(s => s.CompanyName);
                    break;
            }
            return query;
        }

        public ActionResult CompanyDetails(int? id)
        {
            CompanyInModel model = new CompanyInModel();

            var obj = _service.GetCompany(id);

            if (obj == null)
            {
                //return HttpNotFound();
            }
            else
            {
                model.CompanyId = obj.CompanyId;
                model.CompanyName = obj.CompanyName;
                model.CompanyType = obj.CompanyType;
                model.CompanyBusiness = obj.CompanyBusiness;
                model.CompanyDepartment = obj.CompanyDepartment;
                model.CompanyGrade = obj.CompanyGrade;
                model.CompanyWebsite = obj.CompanyWebsite;
                model.CompanyContact = obj.CompanyContact;
                model.CompanyEmail = obj.CompanyEmail;

            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyDetails(CompanyInModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //bool isUnique = !_service.IsCompanyNameExists(model.CompanyId, model.CompanyName);
                    //if (isUnique)
                    //{

                    var obj = new Company();
                        obj.CompanyId = model.CompanyId;
                        obj.CompanyName = model.CompanyName;
                        obj.CompanyType = model.CompanyType;
                        obj.CompanyBusiness = model.CompanyBusiness;
                        obj.CompanyDepartment = model.CompanyDepartment;
                        obj.CompanyGrade = model.CompanyGrade;
                        obj.CompanyWebsite= model.CompanyWebsite;
                        obj.CompanyContact = model.CompanyContact;
                        obj.CompanyEmail = model.CompanyEmail;

                        _service.SaveCompany(obj);

                        TempData["SuccessMessage"] = "Data saved successfully.";
                        return RedirectToAction("CompanyDetails", new { CompanyId = obj.CompanyId });
                    //}
                    //else
                    //{
                        //ModelState.AddModelError("", string.Format("CompanyName '{0}' already in use, please enter another.", model.CompanyName));
                    //}
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                ModelState.AddModelError("", ex.Message);
            }

            //UserDetailsBindControls(model.SelectedRoles);

            return View(model);
        }

        /////////////////////////CATEGORY MODEL ADMIN ENDS
    }
}
