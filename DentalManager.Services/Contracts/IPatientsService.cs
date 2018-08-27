namespace DentalManager.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalManager.Models.ViewModels;

    public interface IPatientsService
    {
        Task<IEnumerable<PatientViewModel>> AllAsync();

        Task AddAsync(string name, string email, string phoneNumber);
    }
}
