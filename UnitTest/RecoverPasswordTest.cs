using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Cliente_PANGEA.Controllers;

namespace UnitTest
{
    [TestClass]
    public class RecoverPasswordTest
    {
        [TestMethod]
        public void ValidateEmailExist()
        {
            String email = "irving_cena2@hotmail.com";
            int result = AccountController.UserExist(email);
            int expected = 1;
            Assert.AreEqual(expected,result);
        }
        [TestMethod]
        public void ValidateToken()
        {
            String email = "irving_cena2@hotmail.com";
            String token = "1493819622";
            Cuentas account = AccountController.GetTokenAccount(email,token);
            String tokenResult = account.Token;
            String expected = token;
            Assert.AreEqual(expected,tokenResult);
        }
        [TestMethod]
        public void GetToken()
        {
            String email = "irving_cena2@hotmail.com";
            String token = "1493819622";
            Cuentas account = AccountController.GetTokenAccount(email, token);
            Assert.IsNotNull(account);
        }
        [TestMethod]
        public void UpdatePassword()
        {
            String email = "irving_cena2@hotmail.com";
            String password = "123";
            int result = AccountController.UpdatePassword(email,password);
            int expected = 1;
            Assert.AreEqual(expected,result);
        }
    }
}
