using SpaceTech.Domain.Attributes;
using SpaceTech.Domain.Queries.Params;
using System.Reflection;
using System.Text;

namespace SpaceTech.Domain.Queries;
public class BaseQueries
{
    public static string[] ExtractReturnFieldsForQuery<T>()
    {
        var type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();
        string[] returnFields = properties.Select(propertie =>
        {
            var field = propertie.GetCustomAttributes().Select(atribute => atribute is IgnoreProperty).FirstOrDefault();
            if (!field)
            {
                return propertie.Name;
            }
            return "";
        }).Where(field => !String.IsNullOrEmpty(field)).ToArray();
        return returnFields;
    }

    public static SearchParams ExtractReturnFieldsForSearch<T>(SearchParams searchParams)
    {
        var type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();
        searchParams.ReturnFields = properties.Select(propertie =>
        {
            var field = propertie.GetCustomAttributes().Select(atribute => atribute is IgnoreProperty).FirstOrDefault();
            if (!field)
            {
                return propertie.Name;
            }
            return "";
        }).Where(field => !String.IsNullOrEmpty(field)).ToArray();

        searchParams.SearchFields = properties.Select(propertie =>
        {
            var field = propertie.GetCustomAttributes().Select(atribute => atribute is Search).FirstOrDefault();
            if (field)
            {
                return propertie.Name;
            }
            return "";
        }).Where(field => !String.IsNullOrEmpty(field)).ToArray();

        return searchParams;
    }

    public static string Search(SearchParams searchParams, bool totalizer = false)
    {
        var sql = new StringBuilder();
        sql.AppendLine("SELECT ");
        if(totalizer)
        {
            sql.AppendLine(" COUNT(1) ");
        } else
        {
            sql.AppendJoin(", ", searchParams.ReturnFields!);
        }
        
        sql.AppendLine($" FROM {searchParams.TableName} ");
        sql.AppendLine(" WHERE 1=1 ");
        if (!String.IsNullOrEmpty(searchParams.TextForSearch))
        {
            if(searchParams.SearchFields is not null || searchParams.SearchFields!.Length > 0)
            {
                sql.AppendLine("AND ( ");
                var firstSearch = true;
                foreach (var searchField in searchParams.SearchFields!)
                {
                    if(firstSearch) {
                        sql.AppendLine($"( {searchField} LIKE CONCAT('%',@TextForSearch,'%'))");
                        firstSearch = false;
                    } else
                    {
                        sql.AppendLine($" OR ( {searchField} LIKE CONCAT('%',@TextForSearch,'%'))");
                    }
                    
                }
                sql.AppendLine(" ) ");
            }
        }

        if(!totalizer) {
            if(!String.IsNullOrEmpty(searchParams.Order))
            {
                sql.AppendLine($" ORDER BY {searchParams.Order} ");
            }

            if(searchParams.Take == 0)
            {
                searchParams.Take = 25;
            }
            sql.AppendLine(" LIMIT @Take OFFSET @Skip ");
        }

        return sql.ToString();
    }

    public static string SearchForm(SearchFormParams searchFormParams)
    {
        var sql = new StringBuilder();
        sql.Append("SELECT ");
        sql.AppendJoin(", ", searchFormParams.ReturnFields!);

        sql.AppendLine($" FROM {searchFormParams.TableName} ");

        sql.AppendLine(" WHERE Id = @Id ");

        if (searchFormParams.Active != null)
        {
            sql.AppendLine(" AND ACTIVE = @Active ");
        }

        return sql.ToString();
    }
}
