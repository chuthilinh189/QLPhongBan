using QLPhongBan.Models.Context;
using QLPhongBan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLPhongBan.Controllers
{
     public class staffController : ApiController
     {
          // GET: api/staff
          [Route("staffs")]
          public IEnumerable<staffViewModel> Getstaffs()
          {
               return staffViewModel.GetStaffs();
          }

          // GET: api/staff/5
          [Route("staff/{code}")]
          public staffViewModel Getstaff(string code)
          {
               return staffViewModel.GetStaff(code);
          }

          [Route("staffbydepartment/{departmentname}")]
          public IEnumerable<staffViewModel> Getstaffbydepartment(string departmentname)
          {
               return staffViewModel.GetStaffByDepartment(departmentname);
          }

          // POST: api/staff
          public List<staffViewModel> Post([FromBody] staffViewModel staff, string _approvedby, DateTime? _approvaltime)
          {
               return staffViewModel.InsertStaff(staff, _approvedby, _approvaltime);
          }

          // PUT: api/staff/5
          public List<staffViewModel> Put([FromBody]staffViewModel staff, string _approvedby, DateTime? _approvaltime)
          {
               return staffViewModel.UpdateStaff(staff, _approvedby, _approvaltime);
          }

          // DELETE: api/staff/5
          public List<departmentViewModel> Delete(string code)
          {
               return departmentViewModel.DeleteDepartment(code);
          }
     }
}
