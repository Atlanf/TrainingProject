using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
{
    public class PagedResultDTO<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
    }
}
