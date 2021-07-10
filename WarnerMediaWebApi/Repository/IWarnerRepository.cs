using System.Collections.Generic;
using System.Threading.Tasks;
using WarnerMedia.Data.Entities;

namespace WarnerMediaWebApi.Data
{
    public interface IWarnerRepository
    {
        Task<IReadOnlyCollection<Title>> GetAllTitlesBySearchTerm(string searchTerm);
        Task<Title> GetTitlesById(int titleId);
        Task<IReadOnlyCollection<Title>> GetAllTitles();
        
    }
}