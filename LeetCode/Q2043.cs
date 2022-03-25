using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2043
{
    public class Bank
    {
        long[] balance;
        public Bank(long[] balance)
        {
            this.balance = balance;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (account1 < 1 || account1 > balance.Length) return false;
            if (account2 < 1 || account2 > balance.Length) return false;
            if (balance[account1 - 1] < money) return false;
            balance[account1 - 1] -= money;
            balance[account2 - 1] += money;
            return true;
        }

        public bool Deposit(int account, long money)
        {
            if (account < 1 || account > balance.Length) return false;
            balance[account - 1] += money;
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            if (account < 1 || account > balance.Length) return false;
            if (balance[account - 1] < money) return false;
            balance[account - 1] -= money;
            return true;
        }
    }

    /**
     * Your Bank object will be instantiated and called as such:
     * Bank obj = new Bank(balance);
     * bool param_1 = obj.Transfer(account1,account2,money);
     * bool param_2 = obj.Deposit(account,money);
     * bool param_3 = obj.Withdraw(account,money);
     */
}
