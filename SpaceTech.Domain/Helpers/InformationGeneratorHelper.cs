namespace SpaceTech.Domain.Helpers;
public class InformationGeneratorHelper
{
    public static string GenerateVerificationCode()
    {
        Random random = new Random();
        int code = random.Next(10000, 99999);
        return code.ToString();
    }
}
