using Xunit;
using Cards.Services;

namespace Cards.UnitTests
{
  public class CreditCardTests
  {
    [Fact]
    public void GetBalance_Return0()
    {
      CreditCard creditCard = new CreditCard();
      int balance = creditCard.GetBalance();

      Assert.Equal(balance, 0);
    }

    [Fact]
    public void Deposit_InputIsNegative_ThrowException()
    {
      CreditCard creditCard = new CreditCard();
      string extectedMessage = "Amount should not be negative";

      ArgumentException exception = Assert.Throws<ArgumentException>(() => creditCard.Deposit(-100));
      Assert.Equal(exception.Message, extectedMessage);
    }

    [Fact]
    public void Deposit_InputIsZero_ThrowException()
    {
      CreditCard creditCard = new CreditCard();
      string extectedMessage = "Amount should not be zero";

      ArgumentException exception = Assert.Throws<ArgumentException>(() => creditCard.Deposit(0));
      Assert.Equal(exception.Message, extectedMessage);
    }

    [Fact]
    public void Deposit_InputIs100_Return100()
    {
      CreditCard creditCard = new CreditCard();
      creditCard.Deposit(100);
      int balance = creditCard.GetBalance();

      Assert.Equal(balance, 100);
    }

    [Fact]
    public void Withdraw_InputIsNegative_ThrowException()
    {
      CreditCard creditCard = new CreditCard();
      string extectedMessage = "Amount should not be negative";

      ArgumentException exception = Assert.Throws<ArgumentException>(() => creditCard.Withdraw(-100));
      Assert.Equal(exception.Message, extectedMessage);
    }

    [Fact]
    public void Withdraw_InputIsZero_ThrowException()
    {
      CreditCard creditCard = new CreditCard();
      string extectedMessage = "Amount should not be zero";

      ArgumentException exception = Assert.Throws<ArgumentException>(() => creditCard.Withdraw(0));
      Assert.Equal(exception.Message, extectedMessage);
    }

    [Fact]
    public void Withdraw_InputIsMoreTheBalance_ThrowException()
    {
      CreditCard creditCard = new CreditCard();
      string extectedMessage = "Amount should not be more than current balance";

      InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => creditCard.Withdraw(100));
      Assert.Equal(exception.Message, extectedMessage);
    }

    [Fact]
    public void Withdraw_InputIs100_Return0()
    {
      CreditCard creditCard = new CreditCard(100);
      creditCard.Withdraw(100);
      int balance = creditCard.GetBalance();

      Assert.Equal(balance, 0);
    }

    [Fact]
    public void GetOperations_ReturnList()
    {
      CreditCard creditCard = new CreditCard();
      creditCard.Deposit(100);
      creditCard.Withdraw(100);
      List<string> operations = creditCard.GetOperations();
      List<string> expectedOperations = new List<string>() { "+100", "-100" };

      Assert.Equal(operations, expectedOperations);
    }
  }
}
