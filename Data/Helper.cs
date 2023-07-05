using WebAPITask_1.Data.Interfaces;
using WebAPITask_1.Data.Repository;

namespace WebAPITask_1.Data
{
    public class Helper
    {
        public static (bool checkResult, Guid parseGuid) checkIdGroup(string guidValue)
        {
            var check = Guid.TryParse(guidValue, out var result);
            if (check)
            {
                return (true, result);
            }
            else
            {
                return (false, Guid.Empty);
            }
        }
    }
}
