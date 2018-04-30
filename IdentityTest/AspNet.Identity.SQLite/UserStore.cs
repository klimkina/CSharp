using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNet.Identity.SQLite
{
	/// <summary>
	/// Class that implements the key ASP.NET Identity user store iterfaces
	/// </summary>
	public class UserStore<TUser, TRole> :
		IUserRoleStore<TUser>,
		IUserPasswordStore<TUser>,
		IQueryableUserStore<TUser>,
		IUserEmailStore<TUser>,
		IUserLockoutStore<TUser, string>,
		IUserStore<TUser>
		where TUser : IdentityUser
		where TRole : IdentityRole
	{
		private UserTable<TUser> userTable;
		private RoleTable<TRole> roleTable;
		private UserRolesTable userRolesTable;
		public SQLiteDatabase Database { get; private set; }
		private bool DisposeContext;


		public IQueryable<TUser> Users
		{
			get
			{
				return userTable.GetUsers().AsQueryable<TUser>();
				//throw new NotImplementedException();
			}
		}


		/// <summary>
		/// Default constructor that initializes a new SQLiteDatabase
		/// instance using the Default Connection string
		/// </summary>
		public UserStore()
		{
			DisposeContext = true;

			new UserStore<TUser, TRole>(new SQLiteDatabase());
		}

		/// <summary>
		/// Constructor that takes a SQLiteDatabase as argument 
		/// </summary>
		/// <param name="database"></param>
		public UserStore(SQLiteDatabase database)
		{
			DisposeContext = false;
			Database = database;
			userTable = new UserTable<TUser>(database);
			roleTable = new RoleTable<TRole>(database);
			userRolesTable = new UserRolesTable(database);
		}

		/// <summary>
		/// Insert a new TUser in the UserTable
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task CreateAsync(TUser user)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			userTable.Insert(user);

			return Task.FromResult<object>(null);
		}

		/// <summary>
		/// Returns an TUser instance based on a userId query 
		/// </summary>
		/// <param name="userId">The user's Id</param>
		/// <returns></returns>
		public Task<TUser> FindByIdAsync(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				throw new ArgumentException("Null or empty argument: userId");
			}

			TUser result = userTable.GetUserById(userId) as TUser;
			if (result != null)
			{
				return Task.FromResult<TUser>(result);
			}

			return Task.FromResult<TUser>(null);
		}

		/// <summary>
		/// Returns an TUser instance based on a userName query 
		/// </summary>
		/// <param name="userName">The user's name</param>
		/// <returns></returns>
		public Task<TUser> FindByNameAsync(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new ArgumentException("Null or empty argument: userName");
			}

			List<TUser> result = userTable.GetUserByName(userName) as List<TUser>;

			// Should I throw if > 1 user?
			if (result != null && result.Count == 1)
			{
				return Task.FromResult<TUser>(result[0]);
			}

			return Task.FromResult<TUser>(null);
		}

		/// <summary>
		/// Updates the UsersTable with the TUser instance values
		/// </summary>
		/// <param name="user">TUser to be updated</param>
		/// <returns></returns>
		public Task UpdateAsync(TUser user)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			userTable.Update(user);

			return Task.FromResult<object>(null);
		}

		public void Dispose()
		{
			if (Database != null)
			{
				if (DisposeContext)
				{
					Database.Dispose();
					Database = null;
				}
			}
		}

		/// <summary>
		/// Inserts a entry in the AspNetUserRoles table
		/// </summary>
		/// <param name="user">User to have role added</param>
		/// <param name="roleName">Name of the role to be added to user</param>
		/// <returns></returns>
		public Task AddToRoleAsync(TUser user, string roleName)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			if (string.IsNullOrEmpty(roleName))
			{
				throw new ArgumentException("Argument cannot be null or empty: roleName.");
			}

			string roleId = roleTable.GetRoleId(roleName);
			if (!string.IsNullOrEmpty(roleId))
			{
				userRolesTable.Insert(user, roleId);
			}

			return Task.FromResult<object>(null);
		}

		/// <summary>
		/// Returns the roles for a given TUser
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<IList<string>> GetRolesAsync(TUser user)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			List<string> roles = userRolesTable.FindByUserId(user.Id);
			{
				if (roles != null)
				{
					return Task.FromResult<IList<string>>(roles);
				}
			}

			return Task.FromResult<IList<string>>(null);
		}

		/// <summary>
		/// Verifies if a user is in a role
		/// </summary>
		/// <param name="user"></param>
		/// <param name="role"></param>
		/// <returns></returns>
		public Task<bool> IsInRoleAsync(TUser user, string role)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			if (string.IsNullOrEmpty(role))
			{
				throw new ArgumentNullException("role");
			}

			List<string> roles = userRolesTable.FindByUserId(user.Id);
			{
				if (roles != null && roles.Contains(role))
				{
					return Task.FromResult<bool>(true);
				}
			}

			return Task.FromResult<bool>(false);
		}

		/// <summary>
		/// Removes a user from a role
		/// </summary>
		/// <param name="user"></param>
		/// <param name="role"></param>
		/// <returns></returns>
		public Task RemoveFromRoleAsync(TUser user, string role)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes a user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task DeleteAsync(TUser user)
		{
			if (user != null)
			{
				userTable.Delete(user);
			}

			return Task.FromResult<Object>(null);
		}

		/// <summary>
		/// Returns the PasswordHash for a given TUser
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<string> GetPasswordHashAsync(TUser user)
		{
			string passwordHash = userTable.GetPasswordHash(user.Id);

			return Task.FromResult<string>(passwordHash);
		}

		/// <summary>
		/// Verifies if user has password
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<bool> HasPasswordAsync(TUser user)
		{
			var hasPassword = !string.IsNullOrEmpty(userTable.GetPasswordHash(user.Id));

			return Task.FromResult<bool>(Boolean.Parse(hasPassword.ToString()));
		}

		/// <summary>
		/// Sets the password hash for a given TUser
		/// </summary>
		/// <param name="user"></param>
		/// <param name="passwordHash"></param>
		/// <returns></returns>
		public Task SetPasswordHashAsync(TUser user, string passwordHash)
		{
			user.PasswordHash = passwordHash;

			return Task.FromResult<Object>(null);
		}

		/// <summary>
		/// Set email on user
		/// </summary>
		/// <param name="user"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public Task SetEmailAsync(TUser user, string email)
		{
			user.Email = email;
			// get username part from email
			user.UserName = email.Substring(0, email.IndexOf('@'));
			userTable.Update(user);

			return Task.FromResult(0);

		}

		/// <summary>
		/// Get email from user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<string> GetEmailAsync(TUser user)
		{
			return Task.FromResult(user.Email);
		}

		/// <summary>
		/// Get if user email is confirmed
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<bool> GetEmailConfirmedAsync(TUser user)
		{
			return Task.FromResult(user.EmailConfirmed);
		}

		/// <summary>
		/// Set when user email is confirmed
		/// </summary>
		/// <param name="user"></param>
		/// <param name="confirmed"></param>
		/// <returns></returns>
		public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
		{
			user.EmailConfirmed = confirmed;
			userTable.Update(user);

			return Task.FromResult(0);
		}

		/// <summary>
		/// Get user by email
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public Task<TUser> FindByEmailAsync(string email)
		{
			if (String.IsNullOrEmpty(email))
			{
				throw new ArgumentNullException("email");
			}

			TUser result = userTable.GetUserByEmail(email) as TUser;
			if (result != null)
			{
				return Task.FromResult<TUser>(result);
			}

			return Task.FromResult<TUser>(null);
		}

		/// <summary>
		/// Get user lock out end date
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
		{
			return
				Task.FromResult(new DateTimeOffset());
		}


		/// <summary>
		/// Set user lockout end date
		/// </summary>
		/// <param name="user"></param>
		/// <param name="lockoutEnd"></param>
		/// <returns></returns>
		public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
		{
			return Task.FromResult(0);
		}

		/// <summary>
		/// Increment failed access count
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<int> IncrementAccessFailedCountAsync(TUser user)
		{
			return Task.FromResult(0);
		}

		/// <summary>
		/// Reset failed access count
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task ResetAccessFailedCountAsync(TUser user)
		{
			return Task.FromResult(0);
		}

		/// <summary>
		/// Get failed access count
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<int> GetAccessFailedCountAsync(TUser user)
		{
			return Task.FromResult(0);
		}

		/// <summary>
		/// Set lockout for the user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task SetLockoutEnabledAsync(TUser user, bool enabled)
		{
			return Task.FromResult(0);
		}

		/// <summary>
		/// Get if lockout is enabled for the user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public Task<bool> GetLockoutEnabledAsync(TUser user)
		{
			return Task.FromResult(false);
		}
	}
}
