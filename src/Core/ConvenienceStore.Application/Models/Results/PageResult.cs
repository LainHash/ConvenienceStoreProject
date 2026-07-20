using System.Net;

namespace ConvenienceStore.Application.Models.Results
{
    public class PageResult<T> : Result<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int IndexPage { get; set; }
        public int PageSize { get; set; }

        private PageResult(
            T? data,
            bool isSucceed,
            string message,
            int totalItems,
            int indexPage,
            int pageSize,
            HttpStatusCode statusCode)
            : base(data, isSucceed, message, statusCode)
        {
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            IndexPage = indexPage;
            PageSize = pageSize;
        }

        public static PageResult<T> Succeed(
            T? data,
            string message,
            int totalItems,
            int indexPage = 1,
            int pageSize = 12,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new(data, true, message, totalItems, indexPage, pageSize, statusCode);
        }
    }
}
