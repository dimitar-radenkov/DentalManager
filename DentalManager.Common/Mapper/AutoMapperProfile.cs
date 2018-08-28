namespace DentalManager.Common.Mapper
{
    using AutoMapper;
    using DentalManager.Models;
    using DentalManager.Models.ViewModels;
    using DentalManager.Models.ViewModels.Arrangments;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Patient, PatientViewModel>();

            this.CreateMap<Patient, DetailsPatientViewModel>();

            this.CreateMap<Arrangment, ArrangmentViewModel>()
                .ForMember(vm => vm.PatientName, cfg => cfg.MapFrom(m => m.Patient.Name));
        }
    }
}
