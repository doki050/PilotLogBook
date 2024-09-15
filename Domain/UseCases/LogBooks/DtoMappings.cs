using AutoMapper;
using Domain.Model.PilotDocuments;

namespace Domain.UseCases.LogBooks;

public class DtoMappings : Profile
{
    public DtoMappings()
    {
        CreateMap<CreateLogBook.Dto, LogBook>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore()); // Ignore the UserId from the DTO, we'll set it manually
    }
}
