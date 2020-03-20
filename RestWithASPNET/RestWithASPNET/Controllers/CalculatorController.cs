using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum( string firstNumber, string secondNumber)
        {
            if ( IsNumeric( firstNumber ) && IsNumeric( secondNumber ))
            {
                var sum = CovertToDecimal(firstNumber) + CovertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

                return BadRequest("Invalid Input");
        }

        // GET api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = CovertToDecimal(firstNumber) - CovertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = CovertToDecimal(firstNumber) / CovertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mul = CovertToDecimal(firstNumber) * CovertToDecimal(secondNumber);
                return Ok(mul.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/calculator/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (CovertToDecimal(firstNumber) + CovertToDecimal(secondNumber)) / 2 ;
                return Ok(mean.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/calculator/mean/5/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)CovertToDecimal(number));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal CovertToDecimal(string number)
        {
            decimal decimalValue;
            if ( decimal.TryParse( number, out decimalValue ) )
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric( string strNumber )
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
