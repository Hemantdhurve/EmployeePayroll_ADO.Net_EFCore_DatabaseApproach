using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL:IAdminBL
    {
        public readonly IAdminRL iadminRL;

        public AdminBL(IAdminRL iadminRL)
        {
            this.iadminRL = iadminRL;
        }
        public AdminRegistrationModel Registration(AdminRegistrationModel adminRegistrationModel)
        {
            try
            {
                return iadminRL.Registration(adminRegistrationModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(AdminLoginModel adminLoginModel)
        {

            try
            {
                return iadminRL.Login(adminLoginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
