namespace TakeAway.WebUI.Dtos.IdentityDtos
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto dto);
    }
}
