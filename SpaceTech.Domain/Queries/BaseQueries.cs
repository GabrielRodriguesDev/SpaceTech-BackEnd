using SpaceTech.Domain.Attributes;
using SpaceTech.Domain.Queries.Params;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace SpaceTech.Domain.Queries;
public class BaseQueries
{
    public static string[] ExtractReturnFields<T>()
    {
        var type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();
        string[] tableFields = properties.Select(propertie =>
        {
            var field = propertie.GetCustomAttributes().Select(atribute => atribute is IgnoreProperty).FirstOrDefault();
            if (!field)
            {
                return propertie.Name;
            }
            return "";
        }).Where(field => !String.IsNullOrEmpty(field)).ToArray();
        return tableFields;
    }

    public static string SearchForm(SearchFormParams searchFormParams)
    {
        var sql = new StringBuilder();
        sql.Append("SELECT ");
        sql.AppendJoin(", ", searchFormParams.TableFields!);

        sql.AppendLine($" FROM {searchFormParams.TableName} ");

        sql.AppendLine(" WHERE Id = @Id ");

        if(searchFormParams.Active != null) 
        {
            sql.AppendLine(" AND ACTIVE = @Active ");
        }

        return sql.ToString();
    }
}
