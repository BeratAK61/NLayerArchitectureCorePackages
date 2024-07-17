namespace NLayerCore.Security;

public interface ITokenService
{
    TokenDto CreateJwt(CreateTokenDto createTokenDto);
}
