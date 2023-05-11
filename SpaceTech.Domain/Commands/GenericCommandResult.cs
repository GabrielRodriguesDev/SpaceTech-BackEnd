namespace SpaceTech.Domain.Commands;

public class GenericCommandResult
{
    public GenericCommandResult(bool sucess, string message)
    {
        Sucess = sucess;
        Message = message;
    }

    public GenericCommandResult(bool sucess, string message, Object? data)
    {
        Sucess = sucess;
        Message = message;
        Data = data;
    }

    public bool Sucess { get; set; }
    public string Message { get; set; } = null!;
    public Object? Data { get; set; }


}
