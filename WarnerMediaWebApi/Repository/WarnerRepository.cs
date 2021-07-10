using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarnerMedia.Data.Entities;
using WarnerMediaWebApi.Models;

namespace WarnerMediaWebApi.Data
{
    public class WarnerRepository: IWarnerRepository
    {
            private readonly WarnerMediaDbContext _context;
            private readonly ILogger<WarnerRepository> _logger;

            public WarnerRepository(WarnerMediaDbContext ctx, ILogger<WarnerRepository> logger)
            {
                _context = ctx;
                _logger = logger;
            }

            public async Task<IReadOnlyCollection<Title>> GetAllTitlesBySearchTerm(string searchTerm)
            {
                try
                {
                    var listrt = new List<Title>();

                    //might need to revisit
                    var searchList =   await _context.Titles.Where(p => p.TitleName.Contains(searchTerm))
                                .OrderBy(q => q.TitleName.StartsWith(searchTerm)
                                ? (q.TitleName == searchTerm ? 0 : 1)
                               : 2)
                            .Take(10)
                            .ToListAsync();

                    if (searchList == null)
                    {
                        _logger.LogInformation($"error");
                    }
                    else
                    {
                        foreach (var item in searchList)
                        {
                              listrt.Add(item);
                        }
                    }
                   return listrt;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to get all Products: {ex}");
                    return null;
                }
            }

            public async Task<Title> GetTitlesById(int titleId)
            {
                    return await _context.Titles
                           .Where(p => p.TitleId == titleId)
                           .FirstOrDefaultAsync();
            }

            public async Task<IReadOnlyCollection<Title>> GetAllTitles()
            {
                    return await  _context.Titles
                           .ToListAsync();
            }

            
            }
}
