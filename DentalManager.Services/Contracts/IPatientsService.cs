namespace DentalManager.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalManager.Models.ViewModels;

    public interface IPatientsService
    {
        Task<IEnumerable<PatientViewModel>> AllAsync();

        Task<PatientViewModel> GetByIdAsync(int id);

        Task<DetailsPatientViewModel> GetDetailsAsync(int id);

        Task<int> AddAsync(string name, string email, string phoneNumber);

        Task UpdateAsync(int id, string name, string email, string phoneNumber);
    }
}
