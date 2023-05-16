namespace SpaceTech.Domain.Models;
public class PaginatedAnswerModel<T> where T : class
{
    public PaginatedAnswerModel(int take, int skip, int total, T data)
    {
        Take = take;
        Skip = skip;
        Total = total;
        Data = data;
    }

    public int Take { get; set; }
    public int Skip { get; set; }
    public int Total { get; set; } 
    public T Data { get; set; }
}
