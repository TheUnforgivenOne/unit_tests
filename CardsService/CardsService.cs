using System;

namespace Cards.Services
{
  public class CreditCard
  {
    private int Balance { get; set; }
    private List<string> operations = new List<string>();

    public CreditCard()
    {
      Balance = 0;
    }

    public CreditCard(int initialBalance)
    {
      Balance = initialBalance;
    }

    public int GetBalance()
    {
      return Balance;
    }

    public void Deposit(int amount)
    {
      if (amount < 0)
      {
        throw new ArgumentException("Amount should not be negative");
      }
      if (amount == 0)
      {
        throw new ArgumentException("Amount should not be zero");
      }

      Balance += amount;
      operations.Add($"+{amount}");
    }

    public void Withdraw(int amount)
    {
      if (amount < 0)
      {
        throw new ArgumentException("Amount should not be negative");
      }
      if (amount == 0)
      {
        throw new ArgumentException("Amount should not be zero");
      }
      if (amount > Balance)
      {
        throw new InvalidOperationException("Amount should not be more than current balance");
      }

      Balance -= amount;
      operations.Add($"-{amount}");
    }

    public List<string> GetOperations()
    {
      return operations;
    }
  }
}
