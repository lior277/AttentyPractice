using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.Converters
{
   public interface IMetersToFeet
    {
        IMetersToFeet InitiateWebDriver(IWebDriver driver);
        IMetersToFeet NvigateToConvectorSite(string url);
        IMetersToFeet ClickOnLengthConvector();
        IMetersToFeet ClickOnMeters();
        IMetersToFeet ClickOnMetersToFeet();
        IMetersToFeet TypeToMetersTextBox(decimal num);
        IMetersToFeet ChangeFormatToDecimal();
        string GetConvertionValue();
    }
}
