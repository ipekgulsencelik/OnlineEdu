using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.WebUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDTO>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Kategori Adı Boş bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog Kategori Adı en fazla 30 karakter olmalıdır.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Blog Kategori Adı en az 3 karakter olmalıdır.");
        }
    }
}