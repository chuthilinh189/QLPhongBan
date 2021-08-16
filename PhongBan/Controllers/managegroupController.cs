using QLPhongBan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLPhongBan.Controllers
{
     public class managegroupController : ApiController
     {
          // GET: api/managegroup
          [Route("managegroups")]
          public IEnumerable<managegroupViewModel> Get()
          {
               return managegroupViewModel.Getmanagegroups();
          }

          // GET: api/managegroup/5
          [Route("managegroup/{code}")]
          public managegroupViewModel Get(string code)
          {
               return managegroupViewModel.Getmanagegroup(code);
          }

          [Route("staffmanagegroup/{managegroup}")]
          [HttpGet]
          public List<staffViewModel> Getstaffmanagergroup(string managegroup)
          {
               return managegroupViewModel.Getstaffmanagegroup(managegroup);
          }

          // POST: api/managegroup
          public List<managegroupViewModel> Post([FromBody]managegroupViewModel managegroup)
          {
               return managegroupViewModel.Insertmanagegroup(managegroup);
          }

          [Route("poststaffmanagergroup")]
          [HttpPost]
          public List<staffViewModel> Poststaffmanagergroup([FromBody]string _staffcode, [FromBody] string _managergroupcode, [FromBody] string _edituser, [FromBody] DateTime _edittime)
          {
               return managegroupViewModel.Insertstaffmanagegroup(_staffcode, _managergroupcode, _edituser, _edittime);
          }

          // PUT: api/managegroup/5
          public List<managegroupViewModel> Put([FromBody]managegroupViewModel managegroup)
          {
               return managegroupViewModel.Updatemanagegroup(managegroup);
          }

          [Route("Deletestaffmanagergroup")]
          public List<staffViewModel> Deletestaffmanagergroup([FromBody]string _staffcode, [FromBody]string _managergroupcode)
          {
               return managegroupViewModel.Deletestaffmanagegroup(_staffcode, _managergroupcode);
          }

          // DELETE: api/managegroup/5
          public List<managegroupViewModel> Delete(string code)
          {
               return managegroupViewModel.Deletemanagegroup(code);
          }
     }
}
