namespace IdentityService.DataAccess.Services.Login.System.Models;

public interface IMapper<RequestModel, ResponseModel>
{
    ResponseModel MapFromRequest  (RequestModel requestModel);
    
    RequestModel MapFromResponse  (ResponseModel requestModel);
    
    List<ResponseModel> MapFromRequest  (List<RequestModel> requestModel);
    
    List<RequestModel> MapFromResponse  (List<ResponseModel> requestModel);
}

