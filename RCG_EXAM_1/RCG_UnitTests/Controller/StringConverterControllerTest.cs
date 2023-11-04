using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCG_EXAM_API.Service;

namespace RCG_UnitTests.Controller
{
    public class StringConverterControllerTest
    {


        [Fact]
        public void StringConverterControllerTest_GetConvertedStringLen_TestLen()
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            var result = svc.GetConvertedStringLen("test");
           
            
            Assert.Equal("8", result);  
        }

        [Fact]
        public void StringConverterControllerTest_GetConvertedStringLen_ReturnError()
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            var result = svc.GetConvertedStringLen(null);


            Assert.Equal("Something went wrong. Please try again.", result);
        }

        [Fact]
        public async void StringConverterControllerTest_GetConvertedStringChar_ReturnValidChar()
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            var result = await svc.GetConvertedStringChar("test",3);


            Assert.Equal("V", result);
        }

        [Fact]
        public async void StringConverterControllerTest_GetConvertedStringChar_ReturnErrorInvalidIndex()
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            var result = await svc.GetConvertedStringChar("test", 0);


            Assert.Equal("Something went wrong. Please try again.", result);
        }


        [Fact]
        public async void StringConverterControllerTest_GetConvertedStringChar_ReturnErrorNullString()
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            var result = await svc.GetConvertedStringChar(null, 10);


            Assert.Equal("Something went wrong. Please try again.", result);
        }



        [Fact]
        public async void StringConverterControllerTest_GetConvertedStringChar_ReturnErrorOutofbounce()
        {
            StringConverterControllerService svc = new StringConverterControllerService();

            var result = await svc.GetConvertedStringChar("test", 99);


            Assert.Equal("Something went wrong. Please try again.", result);
        }
    }
}
