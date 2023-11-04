using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using RCG_EXAM_API.Service;

namespace RCG_EXAM_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringConverterController : Controller
    {



        [HttpGet]
        [Route("GetConvertedStringLen")]
        public string GetConvertedStringLen([FromQuery] string Val)
        {
            StringConverterControllerService svc = new StringConverterControllerService(); 
            try
            {
                return svc.GetConvertedStringLen(Val);
                 
            }
            catch(Exception ex)
            {
                // add logging of error in DB/Server
                return "Something went wrong. Please try again.";


            }

        }

        [HttpGet]
        [Route("GetConvertedStringChar")]
        public async Task<string> GetConvertedStringChar([FromQuery] string Val,int Idx)
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            try
            {
                return await svc.GetConvertedStringChar(Val, Idx);
            }
            catch (Exception ex)
            {
                // add logging of error in DB/Server
                return "Something went wrong. Please try again.";


            }

        }
    }
}
