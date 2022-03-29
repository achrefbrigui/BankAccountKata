using BankAccount.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Extensions
{
    public static class ResponseExtensions
    {
        public static Response<T> Success<T>(this T data, string message = "No error.")
        {
            return new Response<T>
            {
                Data = data,
                Message = message,
                Succeeded = true,
                Errors = Array.Empty<string>()
            };
        }

        public static Response Success()
        {
            return new Response
            {
                Message = "No error.",
                Succeeded = true,
                Errors = Array.Empty<string>()
            };
        }

        public static Response Failure(this string message, string[] errors = null)
        {
            return new Response
            {
                Message = message,
                Succeeded = false,
                Errors = errors ?? Array.Empty<string>()
            };
        }
        public static PaginatedData<T> AsPagedData<T>(this List<T> items, int pageNumber, int pageSize)
        {
            return new PaginatedData<T>(items, pageNumber, pageSize);
        }
    }
}
