#region " Imports "

//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
using Sparcpoint.Abstract;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Sparcpoint.Implementations
{
    public class BaseRepository : IBaseRepository
    {
        #region " Variables "

        //public IConfiguration Configuration { get; }
        //private IWebHostEnvironment _hostingEnvironment;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly APIContext _context;

        #endregion

        #region " Constructor "

        //public BaseRepository(IConfiguration configuration, IWebHostEnvironment hostingEnvironment,
        //    IHttpContextAccessor httpContextAccessor, APIContext context)
        public BaseRepository()
        {

            //Configuration = configuration;
            //_hostingEnvironment = hostingEnvironment;
            //_httpContextAccessor = httpContextAccessor;
            //_context = context;
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Get Logged-in User email address
        /// </summary>
        /// <returns></returns>
        public string GetLoggedInUserEmail()
        {
            return "susheel.rp@gmail.com";
            //return _hostingEnvironment.EnvironmentName.ToUpper() != "DEVELOPMENT" ?
            //                _httpContextAccessor.HttpContext.User.Identity.Name :
            //                Configuration["UserImpersonation:UserName"];
        }

       

        

        #endregion
    }
}
