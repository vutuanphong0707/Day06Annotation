using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab06.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Họ tên không vượt quá 50 ký tự")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Remote(action: "VerifyPhone", controller: "Account")]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 20 ký tự")]
        public string Password { get; set; }

        [Display(Name = "Facebook")]
        [Url(ErrorMessage = "Đường dẫn Facebook không hợp lệ")]
        public string Facebook { get; set; }
    }
}
