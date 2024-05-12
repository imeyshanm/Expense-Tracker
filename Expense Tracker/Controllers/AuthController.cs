using Expense_Tracker.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _config;
//        private readonly IUserService _userService;

//        public AuthController(IConfiguration config, IUserService userService)
//        {
//            _config = config;
//            _userService = userService;
//        }

//        [HttpPost("login")]
//        public IActionResult Login(LoginModel loginModel)
//        {
//            // Authenticate user
//            var user = _userService.Authenticate(loginModel.Username, loginModel.Password);

//            if (user == null)
//                return Unauthorized();

//            // Generate tokens
//            var accessToken = TokenUtils.GenerateAccessToken(user, _config["JWT:Secret"]);
//            var refreshToken = TokenUtils.GenerateRefreshToken();

//            // Save refresh token (for demo purposes, this might be stored securely in a database)
//            // _userService.SaveRefreshToken(user.Id, refreshToken);

//            var response = new TokenModel
//            {
//                AccessToken = accessToken,
//                RefreshToken = refreshToken
//            };

//            return Ok(response);
//        }

//        [HttpPost("refresh")]
//        public IActionResult Refresh(TokenModel tokenResponse)
//        {
//            // For simplicity, assume the refresh token is valid and stored securely
//            // var storedRefreshToken = _userService.GetRefreshToken(userId);

//            // Verify refresh token (validate against the stored token)
//            // if (storedRefreshToken != tokenResponse.RefreshToken)
//            //    return Unauthorized();

//            // For demonstration, let's just generate a new access token
//            var newAccessToken = TokenUtils.GenerateAccessTokenFromRefreshToken(tokenResponse.RefreshToken, _config["Jwt:Secret"]);

//            var response = new TokenModel
//            {
//                AccessToken = newAccessToken,
//                RefreshToken = tokenResponse.RefreshToken // Return the same refresh token
//            };

//            return Ok(response);
//        }
//    }
}
