using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarnerMedia.Data.Entities;
using WarnerMediaWebApi.Data;
using WarnerMediaWebApi.Models;
using WarnerMediaWebApi.DTO;

namespace WarnerMediaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly WarnerMediaDbContext _context;
        private readonly IWarnerRepository _repository;
        private readonly ILogger<TitlesController> _logger;
        public TitlesController(IWarnerRepository repository, ILogger<TitlesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Titles
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<TitlesDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTitles()
        {
            try
            {
                var lst = await _repository.GetAllTitles();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Title: {ex}");
                return BadRequest("failed to get Title");
            }
           
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TitlesDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTitle(int id)
        {
            var title = await _repository.GetTitlesById(id);
            if (title == null) return NotFound();
            else return Ok(title);

        }
        
        [HttpGet("search/{searchTerm}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<TitlesDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(StatusDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(StatusDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTitlesBySearchTerm(string searchTerm)
        {

            var title = await _repository.GetAllTitlesBySearchTerm(searchTerm);
            if (title.Count == 0)
            {
                return NotFound();
            }
            return Ok(title);

        }



    }
}
