using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.Converters
{
   public interface IOuncesToGrams
    {
        IOuncesToGrams InitiateWebDriver(IWebDriver driver);
        IOuncesToGrams NvigateToConvectorSite(string url);
        IOuncesToGrams ClickOnWeightConvector();
        IOuncesToGrams ClickOnOunces();
        IOuncesToGrams ClickOnOuncesToGrams();
        IOuncesToGrams TypeToOuncesTextBox(decimal num);
        string GetConvertionValue();
    }
}
