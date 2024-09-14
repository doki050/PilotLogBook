using AutoMapper;
using Domain.Model.PilotDocuments;

namespace Domain.UseCases.LogBooks;

public class DtoMappings : Profile
{
    public DtoMappings()
    {
        CreateMap<CreateLogBook.Dto, LogBook>();
    }
}
