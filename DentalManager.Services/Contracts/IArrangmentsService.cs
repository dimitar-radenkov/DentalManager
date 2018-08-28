namespace DentalManager.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalManager.Models.ViewModels.Arrangments;

    public interface IArrangmentsService
    {
        Task<IEnumerable<ArrangmentViewModel>> AllAsync();

        Task AddAsync(DateTime dateTime, string notice, int patientId);
    }
}
