using System.Text.Json.Serialization;

namespace SpaceTech.Domain.Queries.Params;
public class SearchParams
{

    public int Take { get; set; }
    public int Skip { get; set; }
    public string? TextForSearch { get; set; }
    public string? Order { get; set; }
    [JsonIgnore]
    public string? TableName { get; set; }
    [JsonIgnore]
    public string[]? ReturnFields { get; set; }
    [JsonIgnore]
    public string[]? SearchFields { get; set; }


}
