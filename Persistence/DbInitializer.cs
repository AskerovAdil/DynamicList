using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer
    {
        /// <summary>
        /// Проверка при стартер приложения, создана ли бд
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(UserDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
