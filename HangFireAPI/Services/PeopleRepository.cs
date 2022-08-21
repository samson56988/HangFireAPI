using HangFireAPI.Models;

namespace HangFireAPI.Services
{

    public interface IPeaopleRepository
    {
        Task CreatePerson(string personName);
    }
    public class PeopleRepository:IPeaopleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PeopleRepository> _logger;

        public PeopleRepository(ApplicationDbContext context, ILogger<PeopleRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task CreatePerson(string personName)
        {
            _logger.LogInformation($"Adding Person {personName}");
            var person = new Person { Name = personName };
            _context.Add(person);
            await Task.Delay(5000);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Added the person {personName}");
        }
    }
}
