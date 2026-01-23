using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        void DoesExistTitle(string title);
    }
}
