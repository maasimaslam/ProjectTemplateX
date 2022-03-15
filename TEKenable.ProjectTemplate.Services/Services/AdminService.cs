using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Services
{
    public interface IAdminService
    {
        IQueryable<User> GetUsers(string keysearch);
        User GetUser(int? id);
        void SaveUser(User user);
        IQueryable<Role> GetRoles();
        bool IsUsernameExists(int id, string username);

        ///////////////////////////////////////////////
        //////////////////COMPANY INITIALS STARTS
        IQueryable<Company> GetCompanies(string keysearch);
        Company GetCompany(int? id);
        void SaveCompany(Company company);
        
        //bool IsCompanyNameExists(int id, string companyname);

        ///////////////////////////////////////////////
        //////////////////COMPANY INITIALS STARTS

    }

    public class AdminService : IAdminService
    {
        private readonly ILog _log;
        private readonly ProjectTemplateDBContext _dBContext;

        public AdminService(ILog log, ProjectTemplateDBContext dBContext)
            : base()
        {
            _log = log;

            _dBContext = dBContext;

            _log.Debug("Admin constructor");
        }

        public IQueryable<User> GetUsers(string keysearch)
        {
            return from u in _dBContext.Users
                   where keysearch == null || (u.first_name.ToUpper().Contains(keysearch.ToUpper()) ||
                         u.last_name.ToUpper().Contains(keysearch.ToUpper()) ||
                         u.user_name.ToUpper().Contains(keysearch.ToUpper()))
                   select u;
        }

        public User GetUser(int? id)
        {
            var user = (from u in _dBContext.Users
                        where u.id == id
                        select u).FirstOrDefault();
            return user;
        }

        public void SaveUser(User user)
        {
            var existing = GetUser(user.id);
            
            if (existing != null)
            {
                existing.user_name      = user.user_name;
                existing.first_name     = user.first_name;
                existing.last_name      = user.last_name;
                existing.UserDepartment = user.UserDepartment;
                existing.UserSalary     = user.UserSalary;
                existing.EmployeeGrade  = user.EmployeeGrade;
                existing.UserEmail      = user.user_name;

                if (user.password != null)
                    existing.password = user.password;

                existing.Roles.RemoveAll(r => user.Roles.Select(ur => ur.role_id).Contains(r.role_id));
                existing.Roles = user.Roles;

                _dBContext.SaveChanges();
            }
            else
            {
                _dBContext.Users.Add(user);
                _dBContext.SaveChanges();
            }
        }

        public IQueryable<Role> GetRoles()
        {
            return _dBContext.Roles;
        }

        public bool IsUsernameExists(int id, string username)
        {
            var user = (from u in _dBContext.Users
                        where u.id != id && String.Compare(u.user_name, username, StringComparison.OrdinalIgnoreCase) == 0
                        select u).FirstOrDefault();
            return user != null;
        }

        ///////////////////////////////////////////////////////////
        /////////////////COMPANY ADMIN SERVICE STARTS
        ///////////////////////////////////////////////////////////
        public IQueryable<Company> GetCompanies(string keysearch)
        {
            return from u in _dBContext.Companies
                   where keysearch == null || (u.CompanyName.ToUpper().Contains(keysearch.ToUpper()) ||
                         u.CompanyType.ToUpper().Contains(keysearch.ToUpper()) ||
                         u.CompanyBusiness.ToUpper().Contains(keysearch.ToUpper()) ||
                         u.CompanyDepartment.ToUpper().Contains(keysearch.ToUpper()) ||
                         u.CompanyGrade.ToUpper().Contains(keysearch.ToUpper()))
                   select u;
        }

        public Company GetCompany(int? id)
        {
            var company = (from c in _dBContext.Companies
                           where c.CompanyId == id
                           select c).FirstOrDefault();
            return company;
        }
        public void SaveCompany(Company company)
        {
            var existing = GetCompany(company.CompanyId);

            if (existing != null)
            {
                existing.CompanyName = company.CompanyName;
                existing.CompanyType = company.CompanyType;
                existing.CompanyBusiness = company.CompanyBusiness;
                existing.CompanyDepartment = company.CompanyDepartment;
                existing.CompanyGrade = company.CompanyGrade;
                existing.CompanyWebsite = company.CompanyWebsite;
                existing.CompanyContact = company.CompanyContact;
                existing.CompanyEmail = company.CompanyEmail;
               // existing.CompanyAdded = company.CompanyAdded;

                _dBContext.SaveChanges();

            }
            else
            {
                _dBContext.Companies.Add(company);
                _dBContext.SaveChanges();

            }

            //return _dBContext.Companies;
        }

        public bool IsCompanyExists(int id, string companyname)
        {
            var company = (from c in _dBContext.Companies
                           where c.CompanyId != id && String.Compare(c.CompanyName, companyname, StringComparison.OrdinalIgnoreCase) == 0
                           select c).FirstOrDefault();
            return company != null;
        }

        ///////////////////////////////////////////////////////////
        /////////////////COMPANY ADMIN SERVICE ENDS
        ///////////////////////////////////////////////////////////
    }
}
