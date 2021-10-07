using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using AutoMapper;

namespace AuthenticationApi.MappingModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<tempaUsersParam, Users>();
            CreateMap<WemaUsersAccountParam, WemaUsersAccount>().ForMember(x => x.AmountPerDay, opt => opt.Ignore());
            CreateMap<WemaUsersAccountParam, WemaUsersAccount>().ForMember(x => x.AmountPerTransaction, opt => opt.Ignore());
            CreateMap<WemaUsersAccountParam, WemaUsersAccount>().ForMember(x => x.Id, opt => opt.Ignore());
            
            CreateMap<GroupUsersParam, GroupUsers>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<GroupUsersParam, GroupUsers>().ForMember(x => x.DateCreated, opt => opt.Ignore());
            
            CreateMap<CorporateUsersParam, CorporateUsers>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<CorporateUsersParam, CorporateUsers>().ForMember(x => x.DateCreated, opt => opt.Ignore());


           
             
        }
    }
}
