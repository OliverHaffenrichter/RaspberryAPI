using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaspberryAPI.DBContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RaspberryAPI.Models;

namespace RaspberryAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class NFCController : ControllerBase
    {
        private readonly ScannerDbContext _dbContext;

        public NFCController(ScannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("scanned_data")]
        public async Task<IActionResult> GetScannedData()
        {
            // Replace the following code with logic to retrieve and return scanned data from the database
            var scannedData = await _dbContext.scanneddata.ToListAsync();
            return Ok(scannedData);
        }

        [HttpPost("scanned_data")]
        public async Task<IActionResult> ReceiveScannedData([FromBody] ScannedData data)
        {
            try
            {
                // Process the received data and store it in MS SQL using Entity Framework
                Console.WriteLine($"Received data: {data.Time}, CardId: {data.CardId}");

                // Assuming you want to store the data in MS SQL using Entity Framework
                _dbContext.scanneddata.Add(data);  // Use the Add method here
                await _dbContext.SaveChangesAsync();

                return Ok("Data received successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
