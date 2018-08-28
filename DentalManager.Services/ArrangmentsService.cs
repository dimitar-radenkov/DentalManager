namespace DentalManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DentalManager.Models;
    using DentalManager.Models.ViewModels.Arrangments;
    using DentalManager.Services.Contracts;
    using DentalManager.Web.Data;
    using Microsoft.EntityFrameworkCore;

    public class ArrangmentsService : IArrangmentsService
    {
        private readonly DentalManagerDbContext db;
        private readonly IMapper mapper;

        public ArrangmentsService(DentalManagerDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddAsync(DateTime dateTime, string notice, int patientId)
        {
            var patient = this.db.Patients.Find(patientId);
            if (patient == null)
            {
                throw new ArgumentException(nameof(patientId));
            }

            var arrangment = new Arrangment()
            {
                DateTime = dateTime,
                Status = ArrangmentStatus.Scheduled,
                Notice = notice,
                PatientId = patientId
            };

            await this.db.Arrangments.AddAsync(arrangment);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArrangmentViewModel>> AllAsync() => 
            await this.db.Arrangments
                .Include(a => a.Patient)
                .Select(a => this.mapper.Map<ArrangmentViewModel>(a))
                .OrderByDescending(x => x.DateTime)
                .ToListAsync();
    }
}
