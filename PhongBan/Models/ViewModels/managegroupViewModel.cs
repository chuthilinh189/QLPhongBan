using QLPhongBan.Models.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLPhongBan.Models.ViewModels
{
     public class managegroupViewModel
     {
          public int STT;
          [Key]
          [StringLength(10)]
          public string code { get; set; }

          [Required]
          [StringLength(100)]
          public string name { get; set; }

          [StringLength(200)]
          public string note { get; set; }

          [StringLength(50)]
          public string edituser { get; set; }

          public DateTime? edittime { get; set; }

          public static List<managegroupViewModel> Getmanagegroups()
          {
               // lấy danh sách phòng ban
               using (var context = new DBContext())
               {
                    List<managegroup> list = new List<managegroup>();
                    list = context.managegroups.ToList();
                    List<managegroupViewModel> listView = new List<managegroupViewModel>();
                    int i = 1;
                    foreach (var x in list)
                    {
                         var v = new managegroupViewModel()
                         {
                              STT = i,
                              code = x.code,
                              name = x.name,
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

          public static managegroupViewModel Getmanagegroup(string code)
          {
               // lấy thông tin phòng ban theo code
               return Getmanagegroups()
                    .Where(s => s.code == code)
                    .FirstOrDefault<managegroupViewModel>();
          }

          public static List<managegroupViewModel> Insertmanagegroup(managegroupViewModel d)
          {
               using (var context = new DBContext())
               {
                    var v = new managegroup()
                    {
                         code = d.code,
                         name = d.name,
                         note = d.note,
                         edituser = d.edituser,
                         edittime = d.edittime
                    };
                    context.managegroups.Add(v);
                    context.SaveChanges();
                    return Getmanagegroups();
               }
          }

          public static List<managegroupViewModel> Updatemanagegroup(managegroupViewModel d)
          {
               using (var context = new DBContext())
               {
                    var v = context.managegroups.Where(s => s.code == d.code).FirstOrDefault<managegroup>();
                    v.name = d.name;
                    v.note = d.note;
                    v.edituser = d.edituser;
                    v.edittime = d.edittime;
                    context.Entry(v).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return Getmanagegroups();
               }
          }

          public static List<managegroupViewModel> Deletemanagegroup(string code)
          {
               using (var context = new DBContext())
               {
                    var v = new managegroup();
                    v = context.managegroups.Where(s => s.code == code).FirstOrDefault<managegroup>();
                    context.Entry(v).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return Getmanagegroups();
               }
          }

          // lấy danh sách nhân viên thuộc managegroup
          public static List<staffViewModel> Getstaffmanagegroup(string managergroup)
          {
               using (var context = new DBContext())
               {
                    // lấy mã maanagergroupcode tuong ứng
                    string managergroupcode = context.managegroups
                         .Where(s => s.name == managergroup)
                         .FirstOrDefault()
                         .code;

                    // Lấy list code của staff thuộc managegroup đó
                    List<string> listcode = context.staffmanagergroups
                              .Where(s => s.managegroupcode == managergroupcode)
                              .Select(s => s.staffcode)
                              .ToList();

                    //lấy list staff thuộc managegroup đó
                    List<staffViewModel> liststaff = staffViewModel.GetStaffs();
                    List<staffViewModel> newlist = new List<staffViewModel>();
                    foreach (var x in listcode)
                    {
                         var staff = new staffViewModel();
                         staff = liststaff.Where(s => s.code == x).FirstOrDefault();
                         newlist.Add(staff);
                    }
                    return newlist;
               }
          }

          // Thêm nhân viên vào managergroup
          public static List<staffViewModel> Insertstaffmanagegroup(string _staffcode, string _managergroupcode, string _edituser, DateTime _edittime)
          {
               using (var context = new DBContext())
               {
                    var x = new staffmanagergroup()
                    {
                         code = managegroupViewModel.Codestaffmanagegroup(),
                         staffcode = _staffcode,
                         managegroupcode = _managergroupcode,
                         edituser = _edituser,
                         edittime = _edittime,
                         _lock = 0
                    };

                    context.staffmanagergroups.Add(x);
                    context.SaveChanges();
                    return Getstaffmanagegroup(_managergroupcode);
               }
          }

          // Xóa nhân viên khỏi managergroup
          public static List<staffViewModel> Deletestaffmanagegroup(string _staffcode, string _managergroupcode)
          {
               using (var context = new DBContext())
               {
                    var x = context.staffmanagergroups
                         .Where(s => s.staffcode == _staffcode)
                         .Where(s => s.managegroupcode == _managergroupcode)
                         .FirstOrDefault();

                    context.Entry(x).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return Getstaffmanagegroup(_managergroupcode);
               }
          }


          // lấy mã staffmanagegroup tự động tăng
          public static string Codestaffmanagegroup()
          {
               using (var context = new DBContext())
               {
                    string code = context.managegroups
                         .OrderByDescending(v => v.code)
                         .FirstOrDefault<managegroup>()
                         .code;
                    int d;
                    int.TryParse(code.Substring(3), out d);
                    d += 1;
                    string max = d.ToString();
                    code = "SMG";
                    for (int i = 4; i <= 10 - max.Length; i++)
                    {
                         code += "0";
                    }
                    code += d.ToString();
                    return code;
               }
          }
     }
}