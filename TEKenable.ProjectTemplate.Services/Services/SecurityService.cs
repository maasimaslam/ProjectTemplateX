using log4net;
using System;
using System.Linq;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Services
{
    public interface ISecurityService
    {
        bool ValidateUser(string username, string password);
        User GetUser(string username);

        void SaveUser(User user);

        ///////////////////////////////////////////////
        //////////////////COMPANY INITIALS STARTS

        bool ValidateCompany(string companyname, string companyemail);
        Company GetCompany(string companyname);

        void SaveCompany(Company company);

        ///////////////////////////////////////////////
        //////////////////COMPANY INITIALS ENDS
    }


    public class SecurityService : ISecurityService
    {
        private readonly ILog _log;
        private readonly ProjectTemplateDBContext _dBContext;

        public SecurityService(ILog log, ProjectTemplateDBContext dBContext)
            : base()
        {
            _log = log;
            _dBContext = dBContext;

            _log.Debug("MyService constructor");
        }

        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            var user = (from u in _dBContext.Users
                        where String.Compare(u.user_name, username, StringComparison.OrdinalIgnoreCase) == 0
                              && String.Compare(u.password, password, StringComparison.OrdinalIgnoreCase) == 0
                        //&& !u.Deleted
                        select u).FirstOrDefault();
            return user != null;
        }

        public User GetUser(string username)
        {
            var user = (from u in _dBContext.Users
                        where String.Compare(u.user_name, username, StringComparison.OrdinalIgnoreCase) == 0
                        select u).FirstOrDefault();
            return user;
        }

        private User GetUser(int? id)
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
                existing.first_name = user.first_name;
                existing.last_name = user.last_name;
                existing.user_name = user.user_name;
                //existing.Roles.RemoveAll(r=> user.Roles.Select(ur=> ur.Id).Contains(r.Id));
                //existing.Roles = user.Roles;
                if (user.password != null)
                    existing.password = user.password;

                _dBContext.SaveChanges();
            }
        }

        ///////////////////////////////////////////////////////////
        /////////////////COMPANY SECURITY SERVICE STARTS
        ///////////////////////////////////////////////////////////

        public bool ValidateCompany(string companyname, string companyemail)
        {
            if (string.IsNullOrEmpty(companyname) || string.IsNullOrEmpty(companyemail))
                return false;

            var company = (from u in _dBContext.Companies
                           where String.Compare(u.CompanyName, companyname, StringComparison.OrdinalIgnoreCase) == 0
                                   && String.Compare(u.CompanyEmail, companyemail, StringComparison.OrdinalIgnoreCase) == 0
                           //&& !u.Deleted
                           select u).FirstOrDefault();
            return company != null;
        }

        public Company GetCompany(string companyname)
        {
            var company = (from u in _dBContext.Companies
                           where String.Compare(u.CompanyName, companyname, StringComparison.OrdinalIgnoreCase) == 0
                           select u).FirstOrDefault();
            return company;
        }

        private Company GetCompany(int? id)
        {
            var company = (from u in _dBContext.Companies
                           where u.CompanyId == id
                           select u).FirstOrDefault();
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
                //existing.Roles.RemoveAll(r=> user.Roles.Select(ur=> ur.Id).Contains(r.Id));
                //existing.Roles = user.Roles;
                if (company.CompanyEmail != null)
                    existing.CompanyEmail = company.CompanyEmail;

                _dBContext.SaveChanges();
            }
        }

    }
}
