public class ResponseModel
{
    public bool IsSuccess { get; set; }
    public object JsonData { get; set; }
    public string ErrorMessage { get; set; }

    public static ResponseModel Success(object data)
    {
        return new ResponseModel { IsSuccess = true, JsonData = data };
    }

    public static ResponseModel Error(string errorMessage)
    {
        return new ResponseModel { IsSuccess = false, ErrorMessage = errorMessage };
    }
}