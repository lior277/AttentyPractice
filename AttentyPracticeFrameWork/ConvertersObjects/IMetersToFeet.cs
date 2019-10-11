using AttentyPractice.Internals;

namespace AttentyPracticeFrameWork.Converters
{
    public interface IMetersToFeet : IApiFactory
    {
        IMetersToFeet ClickOnLengthConvector();
        IMetersToFeet ClickOnMeters();
        IMetersToFeet ClickOnMetersToFeet();
        IMetersToFeet TypeToMetersTextBox(decimal num);
        IMetersToFeet ChangeFormatToDecimal();
        string GetConvertionValue();
    }
}
