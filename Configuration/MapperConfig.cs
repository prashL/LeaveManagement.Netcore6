using AutoMapper;
using LeaveManagementWeb_Core_6.Data;
using LeaveManagementWeb_Core_6.Models;

namespace LeaveManagementWeb_Core_6.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
