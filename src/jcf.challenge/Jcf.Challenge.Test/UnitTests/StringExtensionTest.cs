using Jcf.Challenge.Server.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Jcf.Challenge.Test.UnitTests
{
    public class StringExtensionTest
    {
        [Theory]
        [InlineData("(84) 99682-8298")]
        [InlineData("+55 (84) 99682-8298")]
        [InlineData("(84) 99682_8298")]
        [InlineData("056.845.451-84")]
        [InlineData("07/07/2023")]
        [InlineData("12 anos")]
        [InlineData("Joao 1827")]
        public void Only_Number_ReturnTrue(string str)
        {
            var onlyNumber = str.OnlyNumbers();
            _ = long.TryParse(onlyNumber, out long number);
            Assert.True(number > 0, $" {number} is a number");
        }

        [Theory]
        [InlineData("antonia fransicao")]
        [InlineData("antonio maria")]
        [InlineData("")]
        public void Only_Number_ReturnFalse(string str)
        {
            var onlyNumber = str.OnlyNumbers();
            _ = long.TryParse(onlyNumber, out long number);
            Assert.False(number > 0, $" {number} is not a number");
        }

        [Theory]
        [InlineData(null)]
        public void Only_Number_String_Null_ReturnTrue(string str)
        {
            Assert.True(str.OnlyNumbers().IsNullOrEmpty(), $"Not be number and string is null or Empty");
        }

        [Theory]
        [InlineData(null)]
        public void Only_Number_String_Null_ReturnNotNull(string str)
        {
            Assert.NotNull(str.OnlyNumbers());
        }

        [Theory]
        [InlineData("João Carias de França")]
        [InlineData("Messias Targino")]
        [InlineData("Ana Maria")]
        public void First_Part_More_Than_One_ReturnTrue(string str)
        {
            Assert.True(str.Length > str.FirstPart().Length, $" {str.FirstPart()} is first part");
        }

        [Theory]
        [InlineData("João")]
        [InlineData("Messias")]
        [InlineData("Ana")]
        public void First_Part_Only_One_ReturnTrue(string str)
        {
            Assert.True(str.Length.Equals(str.FirstPart().Length), $" {str.FirstPart()} is first part");
        }
    }
}
