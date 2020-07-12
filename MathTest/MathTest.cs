using ApiWebTest.Model;
using Math;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MathTest
{
    public class MathTest
    {
        [Fact]
        public void ValidationMultiple11Test()
        {
            Multiple math = new Multiple();
            string[] files = Directory.GetFiles(@"JsonTest\ValidationMultiple11");

            foreach (var file in files)
            {
                string json = System.IO.File.ReadAllText(file);
                List <ValidationModel> lstNumber = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ValidationModel>>(json);

                foreach (var number in lstNumber)
                {
                    Assert.Equal(math.ValidationMultiple11(number.Number), number.IsMultiple);
                }
            }
        }
    }
}
