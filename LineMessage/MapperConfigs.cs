using AutoMapper;
using LineMessage.DTO;
using System.IO;

namespace LineMessage
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<DataServices.Models.WebHookMessage, DTO.WebHookRequset>().ReverseMap();
            CreateMap<DataServices.Models.DeliveryContext, DTO.DeliveryContext>().ReverseMap();
            CreateMap<DataServices.Models.Event, DTO.Event>().ReverseMap();
            CreateMap<DataServices.Models.Message, DTO.Message>().ReverseMap();
            CreateMap<DataServices.Models.Source, DTO.Source>().ReverseMap();

            CreateMap<DataServices.Models.LineNotifyConfig, DTO.LineNotifyConfigRequest>().ReverseMap();
            CreateMap<DataServices.Models.LineNotifyConfig, DTO.LineNotifyConfigRequestUpdate>().ReverseMap();
            
        }
    }
}
