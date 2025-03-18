using QuarterService.Domain.Enums;

namespace QuarterService.Infrastructure.Static
{
    public static class TimeFrameEnumMethods
    {
        public static string GetEnumDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            return attribute?.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)attribute[0]).Description : value.ToString();
        }
    }
}
