using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RCG_EXAM_API.Service
{
    public class StringConverterControllerService
    {
        public string GetConvertedStringLen(string Val)
        {
            try
            {
                // Encode the original string
                byte[] encodedBytes = Encoding.UTF8.GetBytes(Val);
                string encodedString = Convert.ToBase64String(encodedBytes);

                return encodedString.Length.ToString();

            }
            catch (Exception ex)
            {
                // add logging of error in DB/Server
                return "Something went wrong. Please try again.";


            }

        }

        public async Task<string> GetConvertedStringChar(string Val, int Idx)
        {
            try
            {
                // Encode the original string
                byte[] encodedBytes = Encoding.UTF8.GetBytes(Val);
                string encodedString = Convert.ToBase64String(encodedBytes);


                char characterAtIndex = encodedString[Idx - 1];
                await Task.Delay(TimeSpan.FromSeconds(new Random().Next(1, 6))); // Random delay between 1 to 5 seconds

                return characterAtIndex.ToString();
            }
            catch (Exception ex)
            {
                // add logging of error in DB/Server
                return "Something went wrong. Please try again.";


            }

        }

    }
}
