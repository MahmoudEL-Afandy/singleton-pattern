using SingletonPattern;
while (true)
{
    Console.WriteLine("Currency Converter");
    Console.WriteLine("Becareful the exchange only from SAR to EGP, from USD to SAR, from USD to EGP");
    Console.WriteLine("-------------------------------------------------------------------------------------");
    Console.Write("Enter Your Base Currency : ");
    var baseCurrency = Console.ReadLine();
    Console.Write("Enter Your Target Currency : ");
    var targetCurrency = Console.ReadLine();
    Console.Write("Enter Your Amount :");
    var amount = decimal.Parse(Console.ReadLine());
   // var converter = new CurrencyConverter(); this before use the creational singletonPattern 
    var exchangeAmount = CurrencyConverter.Instance.Convert(baseCurrency,targetCurrency,amount);
    Console.WriteLine($"{amount} {baseCurrency} = {exchangeAmount} {targetCurrency}");
    Console.WriteLine("----------------------------");



}