﻿using System.Text.Json.Serialization;

namespace SpaceTech.Domain.Queries.Params;
public class SearchFormParams
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public string? TableName { get; set; }
    [JsonIgnore]
    public string[]? ReturnFields { get; set; }
    [JsonIgnore]
    public bool? Active { get; set; }

}
