using QLPhongBan.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace QLPhongBan.Models.ViewModels
{
     public class staffViewModel
     {
          public int STT;
          [Key]
          [StringLength(10)]
          public string code { get; set; }

          [Required]
          [StringLength(100)]
          public string name { get; set; }

          public DateTime? birthday { get; set; }

          [StringLength(300)]
          public string address { get; set; }

          [StringLength(300)]
          public string hometown { get; set; }

          [StringLength(20)]
          public string mobiphone { get; set; }

          [StringLength(100)]
          public string email { get; set; }

          public bool sex { get; set; }

          [StringLength(200)]
          public string departmentname { get; set; }

          [StringLength(100)]
          public string positionname { get; set; }

          public short left { get; set; }

          [StringLength(200)]
          public string note { get; set; }

          [StringLength(50)]
          public string edituser { get; set; }

          public DateTime? edittime { get; set; }

          public static List<staffViewModel> GetStaffs()
          {
               // lấy danh sách phòng ban
               using (var context = new DBContext())
               {
                    List<staff> list = new List<staff>();
                    list = context.staffs.ToList();
                    List<staffViewModel> listView = new List<staffViewModel>();
                    int i = 1;
                    foreach (var x in list)
                    {
                         var v = new staffViewModel();
                         v.STT = i;
                         v.code = x.code;
                         v.name = x.name;
                         v.birthday = x.birthday;
                         v.address = x.address;
                         v.hometown = x.hometown;
                         v.mobiphone = x.mobiphone;
                         v.email = x.email;
                         v.sex = x.sex;
                         v.departmentname = "";
                         if(x.departmentcode != null)
                         {
                              v.departmentname = context.departments
                              .Where(s => s.code == x.departmentcode)
                              .FirstOrDefault<department>()
                              .name;
                         }
                         v.positionname = "";
                         if(x.positioncode != null)
                         {
                              v.positionname = context.positions
                              .Where(s => s.code == x.positioncode)
                              .FirstOrDefault<position>()
                              .name;
                         }
                         v.left = x.left;
                         v.note = x.note;
                         v.edituser = x.edituser;
                         v.edittime = x.edittime;
                         listView.Add(v);
                         i++;
                    }
                    return listView;
               }
          }

          public static staffViewModel GetStaff(string code)
          {
               // lấy thông tin nhan vien theo code
               return GetStaffs()
                    .Where(s => s.code == code)
                    .FirstOrDefault<staffViewModel>();
          }

          public static List<staffViewModel> GetStaffByDepartment(string departmentname)
          {
               return GetStaffs()
                    .Where(s => s.departmentname == departmentname)
                    .ToList();
          }

          public static List<staffViewModel> InsertStaff(staffViewModel d, string _approvedby, DateTime? _approvaltime)
          {
               using (var context = new DBContext())
               {
                    // Tìm lịch sử phòng ban chức vụ cũ nếu có
                    var dph1 = context.departmentpositionhis
                         .Where(s => s.staffcode == d.code)
                         .OrderByDescending(s => s.approvaltime)
                         .FirstOrDefault<departmentpositionhi>();
                    
                    // nếu có thì đổi effect = false
                    if(dph1 != null)
                    {
                         dph1.effect = false;
                         context.Entry(dph1).State = System.Data.Entity.EntityState.Modified;
                    }

                    // Thêm lịch sử phòng ban chức vụ
                    var dph = new departmentpositionhi()
                    {
                         code = Codedepartmentpositionhi(),
                         staffcode = d.code,
                         departmentcode = context.departments
                                   .Where(s => s.name == d.departmentname)
                                   .FirstOrDefault<department>()
                                   .code,
                         positioncode = context.positions
                                   .Where(s => s.name == d.positionname)
                                   .FirstOrDefault<position>()
                                   .code,
                         effect = true,
                         approvedby = _approvedby,
                         approvaltime = _approvaltime,
                         edituser = d.edituser,
                         edittime = d.edittime
                    };
                    context.departmentpositionhis.Add(dph);

                    // thêm nhân viên
                    var v = new staff()
                    {
                         code = d.code,
                         name = d.name,
                         birthday = d.birthday,
                         address = d.address,
                         hometown = d.hometown,
                         mobiphone = d.mobiphone,
                         email = d.email,
                         sex = d.sex,
                         departmentcode = context.departments
                                   .Where(s => s.name == d.departmentname)
                                   .FirstOrDefault<department>()
                                   .code,
                         positioncode = context.positions
                                   .Where(s => s.name == d.positionname)
                                   .FirstOrDefault<position>()
                                   .code,
                         left = d.left,
                         note = d.note,
                         edituser = d.edituser,
                         edittime = d.edittime
                    };
                    context.staffs.Add(v);

                    // Lưu thay đổi
                    context.SaveChanges();
                    return GetStaffs();
               }
          }

          internal static List<staffViewModel> GetStaffByDepartment()
          {
               throw new NotImplementedException();
          }

          public static List<staffViewModel> UpdateStaff(staffViewModel d, string _approvedby, DateTime? _approvaltime)
          {
               using (var context = new DBContext())
               {
                    // Tìm staff cần thay đổi
                    var v = context.staffs
                         .Where(s => s.code == d.code)
                         .FirstOrDefault<staff>();

                    // mã phòng ban mới
                    string newdepartmentcode = context.departments
                              .Where(s => s.name == d.departmentname)
                              .FirstOrDefault<department>()
                              .code;
                    // mã chức vụ mới
                    string newpositioncode = context.positions
                              .Where(s => s.name == d.positionname)
                              .FirstOrDefault<position>()
                              .code;

                    // Nếu có thay đổi phòng ban - chức vụ thì 
                    if (v.departmentcode != newdepartmentcode|| v.positioncode != newpositioncode)
                    {
                         // Tìm lịch sử phòng ban chức vụ cũ
                         var dph1 = context.departmentpositionhis
                              .Where(s => s.staffcode == d.code)
                              .OrderByDescending(s => s.approvaltime)
                              .FirstOrDefault<departmentpositionhi>();

                         // đổi effect của phòng ban chức vụ cũ = false
                         if (dph1 != null)
                         {
                              dph1.effect = false;
                              context.Entry(dph1).State = System.Data.Entity.EntityState.Modified;
                         }

                         // và thêm mới lịch sử phòng ban chức vụ
                         // Thêm lịch sử phòng ban chức vụ
                         var dph = new departmentpositionhi()
                         {
                              code = Codedepartmentpositionhi(),
                              staffcode = d.code,
                              departmentcode = context.departments
                                        .Where(s => s.name == d.departmentname)
                                        .FirstOrDefault<department>()
                                        .code,
                              positioncode = context.positions
                                        .Where(s => s.name == d.positionname)
                                        .FirstOrDefault<position>()
                                        .code,
                              effect = true,
                              approvedby = _approvedby,
                              approvaltime = _approvaltime,
                              edituser = d.edituser,
                              edittime = d.edittime
                         };
                         context.departmentpositionhis.Add(dph);

                    }


                    v.name = d.name;
                    v.birthday = d.birthday;
                    v.address = d.address;
                    v.hometown = d.hometown;
                    v.mobiphone = d.mobiphone;
                    v.email = d.email;
                    v.sex = d.sex;
                    v.departmentcode = newdepartmentcode;
                    v.positioncode = newpositioncode;
                    v.left = d.left;
                    v.note = d.note;
                    v.edituser = d.edituser;
                    v.edittime = d.edittime;
                    context.Entry(v).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return GetStaffs();
               }
          }

          public static List<staffViewModel> DeleteStaff(string code)
          {
               using (var context = new DBContext())
               {
                    var v = new staff();
                    v = context.staffs.Where(s => s.code == code).FirstOrDefault<staff>();
                    context.Entry(v).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return GetStaffs();
               }
          }

          // Lấy mã departmentpositionhi (10 kí tự) tăng dần
          public static string Codedepartmentpositionhi()
          {
               using (var context = new DBContext())
               {
                    string code = context.departmentpositionhis
                         .OrderByDescending(v => v.code)
                         .FirstOrDefault<departmentpositionhi>()
                         .code;
                    int d;
                    int.TryParse(code.Substring(3), out d);
                    d += 1;
                    string max = d.ToString();
                    code = "DPH";
                    for (int i = 4; i <= 10 - max.Length; i++)
                    {
                         code += "0";
                    }
                    code += d.ToString() ;
                    return code;
               }
          }
     }
}
