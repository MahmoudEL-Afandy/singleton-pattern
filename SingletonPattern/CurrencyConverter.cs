using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class CurrencyConverter
    {
        private IEnumerable<ExchangeRate> _exchangeRates;
        // to use the singleton we need to convert the constructor from public to private
        // to prevent the creation of the object from outside the class
        //->
        private CurrencyConverter()
        {

            // After i implement the singleton pattern this method will be called only one time in the APP life cycle 
            // because we can create the object only one time, and use it during the APP life cycle 
            // the object that is loaded will be used in the whole APP life cycle

            LoadExChangeRates();
        }
        // we should use the following method to perform the singleton pattern  
        // to prevent the thread from creating multiple objects in same time
        private static object _lock = new();
        // to create check if the object is null or not
        private static CurrencyConverter _instance;
        // to make us can use the the object that created 
        public static CurrencyConverter Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new();
                        }
                    }
                }
                return _instance;
            }
        }
        //<-
        private void LoadExChangeRates () 
        {
            // this to make the thread sleep for 3 seconds to simulate the time to load the data from the database 
            // After i implement the singleton pattern this method will be called only one time in the APP life cycle 

            Thread.Sleep(3000);
            _exchangeRates = new[]
            {
                 new ExchangeRate("USD" ,"SAR" ,3.75m),
                 new ExchangeRate("USD","EGP",50.5m),
                 new ExchangeRate("SAR","EGP",13.45m)
            };
             
        
        }
        public decimal Convert (string baseCurrency ,string targetCurrency , decimal amount)
        {
            var exchangeRate = _exchangeRates.FirstOrDefault(c=>c.BaseCurrency == baseCurrency&&c.TargetCurrency==targetCurrency);
            return amount * exchangeRate.Rate;

        }

    }
}
