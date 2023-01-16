using AutoMapper;
using DataLayer.Data;
using WebApi.Features.JournalSearch;

namespace WebApi.Profiles
{
    public class JournalEntryProfile : Profile
    {
        public JournalEntryProfile()
        {
            this.CreateMap<Journalentry, JournalSearchResponse>()
                .IncludeMembers(src => src.JournalEntryTags)
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Title))
                .ForMember(dest => dest.CarbCount, src => src.MapFrom(x => x.JournalEntryNutritionalInfo.Nutritionalinfo.Carbohydrates));

            this.CreateMap<Journalentrytag, string>()
                .ForMember(dest => dest, obj => obj.MapFrom(src => src.Tag.Description));
        }
    }
}
