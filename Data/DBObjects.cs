using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder application) 
        {
            using (var scope = application.ApplicationServices.CreateScope())
            {
                //AppDBContent content = application.ApplicationServices.GetRequiredService<AppDBContent>();
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                if (!content.Group.Any())
                {
                    content.AddRange(Groups.Select(c => c.Value));
                    content.SaveChanges();
                }
            }
        }
        private static Dictionary<string, Group> _group;
        public static Dictionary<string, Group> Groups
        {
            get
            {
                if(_group == null)
                {
                    var list = new Group[]
                    {
                        new Group
                        {
                            Id = new Guid(),
                            Name = Constants.NOGROUP
                        }
                    };

                    _group = new Dictionary<string, Group>();
                    foreach(var group in list)
                    {
                        _group.Add(group.Name, group);
                    }
                }

                return _group;
            }
        }
    }
}
