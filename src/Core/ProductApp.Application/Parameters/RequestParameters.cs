using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Parameters
{
    public class RequestParameters
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public RequestParameters(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
