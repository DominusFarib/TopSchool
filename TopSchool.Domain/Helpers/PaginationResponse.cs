
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TopSchool.Domain.Helpers;

/// <summary>
/// HttpResponse Extensioned Class - Add Custom Pagination on HttpResponse
/// </summary>
public static class PaginationResponse
{
    /// <summary>
    /// Add Pagination Data on HttpResponse Header
    /// </summary>
    /// <param name="response">HttpResponse</param>
    /// <param name="CurPage">Number of Page</param>
    /// <param name="TotalPages">Total Pages</param>
    /// <param name="ItemsPerPage">Items Per Page</param>
    /// <param name="TotalItems">Total Items to pagination</param>
    public static void AddPagination(this HttpResponse response,
        int CurPage,
        int TotalPages,
        int ItemsPerPage,
        int TotalItems)
    {
        PaginationHeader pageHeader = new PaginationHeader(
                                            CurPage,
                                            TotalPages,
                                            ItemsPerPage,
                                            TotalItems);
        // Set camelCase for header variables names. Ex.: 'totalItems' or 'curPage'
        var camelCaseSetting = new JsonSerializerSettings();
        camelCaseSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();

        response.Headers.Add("Pagination", JsonConvert.SerializeObject(pageHeader, camelCaseSetting));
        response.Headers.Add("Access-Control-Expose-Header", "Pagination");
    }
}