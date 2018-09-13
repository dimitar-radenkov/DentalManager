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
    using Z.EntityFramework.Plus;

    public class PatientsService : IPatientsService
    {
        private readonly DentalManagerDbContext db;
        private readonly IMapper mapper;

        public PatientsService(DentalManagerDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<int> AddAsync(string name, string email, string phoneNumber)
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

            return patient.Id;
        }

        public async Task<IEnumerable<PatientViewModel>> AllAsync() =>
            await this.db.Patients
                .Select(p => this.mapper.Map<PatientViewModel>(p))
                .ToListAsync();

        public async Task DeleteAsync(int id)
        {
            await this.db.Patients
                .Where(x => x.Id == id)
                .DeleteAsync();
            this.db.SaveChanges();
        }

        public async Task<PatientViewModel> GetByIdAsync(int id)
        {
            var patient = await this.db.Patients
                .Include(p => p.Arrangments)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                throw new ArgumentException(nameof(id));
            }

            return this.mapper.Map<PatientViewModel>(patient);
        }

        public async Task<DetailsPatientViewModel> GetDetailsAsync(int id)
        {
            var patient = await this.db.Patients
                .Include(p => p.Arrangments)
                .Include(p => p.Documents)
                .FirstAsync(p => p.Id == id);

            if (patient == null)
            {
                throw new ArgumentException(nameof(id));
            }

            return this.mapper.Map<DetailsPatientViewModel>(patient);
        }

        public async Task UpdateAsync(int id, string name, string email, string phoneNumber)
        {
            var patient = await this.db.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new ArgumentException(nameof(id));
            }

            patient.Name = name;
            patient.Email = email;
            patient.PhoneNumber = phoneNumber;

            this.db.Patients.Update(patient);
            await this.db.SaveChangesAsync();
        }
    }
}
