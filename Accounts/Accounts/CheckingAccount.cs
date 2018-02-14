using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    class CheckingAccount
    {
        double m_balance;
        public void Withdraw(double amount)  
{  
    if(m_balance >= amount)  
    {  
        m_balance -= amount;  
    }  
    else  
    {
        throw new ArgumentException(amount, "Withdrawal exceeds balance!");  
    }  
}  
  
    }
}
