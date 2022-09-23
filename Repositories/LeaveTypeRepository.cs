using LeaveManagementWeb_Core_6.Contracts;
using LeaveManagementWeb_Core_6.Data;

namespace LeaveManagementWeb_Core_6.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
