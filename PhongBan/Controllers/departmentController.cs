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
    public class departmentController : ApiController
    {
          // GET: api/DMPhongBan
          [Route("departments")]
          public IEnumerable<departmentViewModel> Get()
          {
               return departmentViewModel.GetDepartments();
          }

          // GET: api/DMPhongBan/5
          [Route("department/{code}")]
          public departmentViewModel Get(string code)
          {
               return departmentViewModel.GetDepartment(code);
          }

          [Route("staffdepartment/{departmentcode}")]
          [HttpGet]
          public List<staffViewModel> Getstaffdepartment(string departmentcode)
          {
               return staffViewModel.GetStaffByDepartment(departmentcode);
          }

          // POST: api/DMPhongBan
          public List<departmentViewModel> Post([FromBody]departmentViewModel department)
          {
               return departmentViewModel.InsertDepartment(department);
          }

          // PUT: api/DMPhongBan/5
          public List<departmentViewModel> Put([FromBody]departmentViewModel department)
          {
               return departmentViewModel.UpdateDepartment(department);
          }

          // DELETE: api/DMPhongBan/5
          public List<departmentViewModel> Delete(string code)
          {
               return departmentViewModel.DeleteDepartment(code);
          }
    }
}
