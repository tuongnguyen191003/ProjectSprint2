﻿using ShoppingOnline.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agile_Ecommerce.Models
{
	public class ProductModel
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên Sản phẩm")]
        [MinLength(4, ErrorMessage = "Yêu cầu nhập tên Sản phẩm ít nhất 4 ký tự")]
        public string Name { get; set; }
        public string Slug { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mô tả Sản phẩm")]
        [MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả Sản phẩm ít nhất 4 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập giá Sản phẩm")]
        [Column(TypeName = "decimal(18,0)")] // Định dạng decimal
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]  // Hiển thị  'N0' (không chữ số thập phân)
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn 1 thương hiệu")]
        [Range(1, int.MaxValue, ErrorMessage = "Yêu cầu chọn 1 thương hiệu")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn 1 danh mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Yêu cầu chọn 1 danh mục")]
        public int CategoryId { get; set; }


        public CategoryModel Category { get; set; }

        public BrandModel Brand { get; set; }
        
        //[Required(ErrorMessage = "Yêu cầu chọn hình ảnh")]
        public string Image { get; set; }
        [NotMapped]
        [FileExtension]
        //[Required(ErrorMessage = "Yêu cầu tải lên hình ảnh")]
        public IFormFile? ImageUpload { get; set; }
        public List<RatingModel> Ratings { get; set; } = new List<RatingModel>();
    }
}

