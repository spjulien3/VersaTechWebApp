using VersaTechWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersaTechWebApp.Services
{
    public class SecurityService
    {
        
        AccountsDAO accountsDAO = new AccountsDAO();

        public bool IsValid(Account account)
        {
            return accountsDAO.AuthenticateUserAndPassword(account);
        }
    }
}
