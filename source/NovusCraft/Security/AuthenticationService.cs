// # Copyright � 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using NovusCraft.Data.Security;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Security
{
	/// <summary>
	/// 	Wrapper for <see cref="FormsAuthentication" /> .
	/// </summary>
	public sealed class AuthenticationService : IAuthenticationService
	{
		readonly IFormsAuthenticationWrapper _formsAuthenticationWrapper;
		readonly IUserAccountRepository _userAccountRepository;

		public AuthenticationService(IUserAccountRepository userAccountRepository, IFormsAuthenticationWrapper formsAuthenticationWrapper)
		{
			_userAccountRepository = userAccountRepository;
			_formsAuthenticationWrapper = formsAuthenticationWrapper;
		}

		#region IAuthenticationService Members

		public bool LogIn(LogInModel logInModel)
		{
			var passwordHash = GenerateHash(logInModel.Password);

			var userAccount = _userAccountRepository.GetUserByEmailAndPassword(logInModel.Email, passwordHash);
			if (userAccount == null)
				return false;

			_formsAuthenticationWrapper.SetAuthCookie(logInModel.Email);
			return true;
		}

		public void LogOut()
		{
			_formsAuthenticationWrapper.RemoveAuthCookie();
		}

		#endregion

		static string GenerateHash(string password)
		{
			var key = new Guid("ee9935ff-a9d5-44c3-ac00-c923783e9265").ToByteArray(); // TODO: Move to config

			using (var hmac = new HMACSHA256(key))
			{
				var passwordBytes = Encoding.Unicode.GetBytes(password);
				var hashBytes = hmac.ComputeHash(passwordBytes);

				return Encoding.Unicode.GetString(hashBytes);
			}
		}
	}
}