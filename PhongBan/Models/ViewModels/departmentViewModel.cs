using QLPhongBan.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLPhongBan.Models.ViewModels
{
     public class departmentViewModel
     {
          public int STT;
          [Key]
          [StringLength(10)]
          public string code { get; set; }
          [Required]
          [StringLength(200)]
          public string name { get; set; }

          [StringLength(200)]
          public string parentdepartment { get; set; }

          [StringLength(20)]
          public string phone { get; set; }

          [StringLength(100)]
          public string email { get; set; }

          [StringLength(200)]
          public string note { get; set; }

          [StringLength(50)]
          public string edituser { get; set; }

          public DateTime? edittime { get; set; }

          public static List<departmentViewModel> GetDepartments()
          {
               // lấy danh sách phòng ban
               using (var context = new DBContext())
               {
                    List<department> list = new List<department>();
                    list = context.departments.ToList();
                    List<departmentViewModel> listView = new List<departmentViewModel>();
                    int i = 1;
                    foreach (var x in list)
                    {
                         var v = new departmentViewModel()
                         {
                              STT = i,
                              code = x.code,
                              name = x.name,
                              parentdepartment = context.departments
                                   .Where(s => s.code == x.code)
                                   .FirstOrDefault<department>()
                                   .name,
                              phone = x.phone,
                              email = x.email,
                              note = x.note,
                              edituser = x.edituser,
                              edittime = x.edittime
                         };
                         listView.Add(v);
                         i++;
                    }
                    return listView;
               }
          }

          public static departmentViewModel GetDepartment(string code)
          {
               // lấy thông tin phòng ban theo code
               return GetDepartments()
                    .Where(s => s.code == code)
                    .FirstOrDefault<departmentViewModel>();
          }

          public static List<departmentViewModel> InsertDepartment(departmentViewModel d)
          {
               using (var context = new DBContext())
               {
                    var v = new department()
                    {
                         code = d.code,
                         name = d.name,
                         phone = d.phone,
                         email = d.email,
                         note = d.note,
                         edituser = d.edituser,
                         edittime = d.edittime
                    };
                    v.parentcode = context.departments
                         .Where(s => s.name == d.name)
                         .FirstOrDefault<department>()
                         .code;
                    context.departments.Add(v);
                    context.SaveChanges();
                    return GetDepartments();
               }
          }

          public static List<departmentViewModel> UpdateDepartment(departmentViewModel d)
          {
               using (var context = new DBContext())
               {
                    var v = context.departments.Where(s => s.code == d.code).FirstOrDefault<department>();
                    v.name = d.name;
                    v.phone = d.phone;
                    v.email = d.email;
                    v.note = d.note;
                    v.edituser = d.edituser;
                    v.edittime = d.edittime;
                    v.parentcode = context.departments
                         .Where(s => s.name == d.name)
                         .FirstOrDefault<department>()
                         .code;
                    context.Entry(v).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return GetDepartments();
               }
          }

          public static List<departmentViewModel> DeleteDepartment(string code)
          {
               using (var context = new DBContext())
               {
                    var v = new department();
                    v = context.departments.Where(s => s.code == code).FirstOrDefault<department>();
                    context.Entry(v).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return GetDepartments();
               }
          }
     }
}