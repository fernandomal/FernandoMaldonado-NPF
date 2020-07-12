using ApiWebTest.Model;
using Common;
using Math.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiWebTest.Controllers
{
    /// <summary>
    /// Controller of Validation of API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        /// <summary>
        /// List with validation of numbers
        /// </summary>
        private List<ValidationModel> listValidation = new List<ValidationModel>();

        /// <summary>
        /// The Multiple builder.
        /// </summary>
        private readonly IMultiple Math;

        /// <summary>
        /// ValidationController Class
        /// </summary>
        public ValidationController(IMultiple math)
        {
            Math = math;
        }

        /// <summary>
        /// Method to validation one number is multiple of 11
        /// </summary>
        /// <param name="jsonInput">Json file with array of numbers to Validate</param>
        /// <returns>True if number is multiple of 11</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ValidationModel>), 200)]
        [ProducesResponseType(400)]
        public IActionResult ValidationMultiple11(string jsonInput)
        {
            try
            {
                NumberDTO numberDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<NumberDTO>(jsonInput);

                foreach (var number in numberDTO.numbers)
                {
                    ValidationModel ValidationModel = new ValidationModel(number, Math.ValidationMultiple11(number));
                    listValidation.Add(ValidationModel);
                }

                return Ok(listValidation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}