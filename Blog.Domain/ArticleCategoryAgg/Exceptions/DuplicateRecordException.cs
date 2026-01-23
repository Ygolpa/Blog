using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.ArticleCategoryAgg.Exceptions
{
    internal class DuplicateRecordException:Exception
    {
        public DuplicateRecordException()
        {

        }
        public DuplicateRecordException(string message):base(message) 
        {

        }
    }
}
