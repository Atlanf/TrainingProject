using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Helpers
{
    public static class PageVerifier
    {
        private static readonly int _defaultPageSize = 5;
        private static readonly int _defaultPage = 1;

        public static int CheckPage(int page, int maxPages)
        {
            if (page <= 0)
            {
                return _defaultPage;
            }
            else
            {
                if (page > maxPages)
                {
                    return maxPages;
                }
            }
            return page;
        }

        public static int CheckPageSize(int pageSize, int totalQuestions)
        {
            if (pageSize > totalQuestions)
            {
                return totalQuestions;
            }
            else
            {
                if (pageSize <= 0)
                {
                    return _defaultPageSize;
                }
            }
            return pageSize;
        }
    }
}
