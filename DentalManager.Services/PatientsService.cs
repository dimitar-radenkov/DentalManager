namespace DentalManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DentalManager.Models;
    using DentalManager.Models.ViewModels;
    using DentalManager.Services.Contracts;
    using DentalManager.Web.Data;
    using Microsoft.EntityFrameworkCore;

    public class PatientsService : IPatientsService
    {
        private readonly DentalManagerDbContext db;
        private readonly IMapper mapper;

        public PatientsService(DentalManagerDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddAsync(string name, string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            var patient = new Patient
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                RegistrationDate = DateTime.UtcNow,
            };

            this.db.Patients.Add(patient);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientViewModel>> AllAsync() =>
            await this.db.Patients
                .Select(p => this.mapper.Map<PatientViewModel>(p))
                .ToListAsync();
    }
}
