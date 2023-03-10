using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL:IAdminRL
    {
        public readonly IConfiguration iconfiguration;
        public static string Key = "hemanT15893@asd";
        public AdminRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        public SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayrollADO;Integrated Security=True;");

        public AdminRegistrationModel Registration(AdminRegistrationModel adminRegistrationModel)
        {

            try
            {
                //using block has a self closing connection property 
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("SPRegistration", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", adminRegistrationModel.FullName);
                    cmd.Parameters.AddWithValue("@Email", adminRegistrationModel.Email);
                    cmd.Parameters.AddWithValue("@Password", ConvertToEncrypt(adminRegistrationModel.Password));
                    cmd.Parameters.AddWithValue("@MobileNumber", adminRegistrationModel.MobileNumber);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return adminRegistrationModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static string ConvertToEncrypt(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return "";
                }

                password += Key;

                var passwordBytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(passwordBytes);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            try
            {
                if (string.IsNullOrEmpty(base64EncodeData))
                {
                    return "";
                }

                var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);

                var result = Encoding.UTF8.GetString(base64EncodeBytes);
                result = result.Substring(0, result.Length - Key.Length);
                return result;
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
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("SPLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", adminLoginModel.Email);
                    cmd.Parameters.AddWithValue("@Password", ConvertToEncrypt(adminLoginModel.Password));
                    //var decryptPass = ConvertToDecrypt(pass.Password);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    // var decr = ConvertToDecrypt(userLoginModel.Password);
                    if (result != null)
                    {
                        string query = "select AdminId from AdminTable where Email = '" + adminLoginModel.Email + "'";
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        var Id = cmd1.ExecuteScalar();
                        var token = GenerateSecurityToken(adminLoginModel.Email);
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GenerateSecurityToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                { 
                    //Added Role claim for the user
                    new Claim(ClaimTypes.Email, email),
                    //new Claim("AdminId", adminId.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
