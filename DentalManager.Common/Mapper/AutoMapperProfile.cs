namespace DentalManager.Common.Mapper
{
    using AutoMapper;
    using DentalManager.Models;
    using DentalManager.Models.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Patient, PatientViewModel>();
        }
    }
}
