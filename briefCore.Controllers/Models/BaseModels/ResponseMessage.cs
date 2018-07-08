namespace briefCore.Controllers.Models.BaseEntities
{
    public class ResponseMessage<T> : BaseResponseMessage
    {
        public T Payload { get; set; }
    }
}
