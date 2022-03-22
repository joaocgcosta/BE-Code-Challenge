using MED.MedicationManagement.Domain;
using AutoMapper;

namespace MED.MedicationManagement.Application.Profiles
{
    using MED.MedicationManagement.Application.DTOs.Medication;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Medication Mappings
            CreateMap<Medication, MedicationDto>().ReverseMap();
            CreateMap<Medication, MedicationListDto>().ReverseMap();
            CreateMap<Medication, CreateMedicationDto>().ReverseMap();
            #endregion Medication
        }
    }
}
