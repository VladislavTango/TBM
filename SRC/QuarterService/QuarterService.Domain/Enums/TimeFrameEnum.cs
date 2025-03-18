using System.ComponentModel;

namespace QuarterService.Domain.Enums
{
    public enum TimeFrameEnum
    { 
        [Description("1m")]
        Minutes_1m,

        [Description("3m")]
        Minutes_3m,

        [Description("5m")]
        Minutes_5m,

        [Description("15m")]
        Minutes_15m,

        [Description("30m")]
        Minutes_30m,

        [Description("1h")]
        Hours_1h,

        [Description("2h")]
        Hours_2h,

        [Description("4h")]
        Hours_4h,

        [Description("6h")]
        Hours_6h,

        [Description("8h")]
        Hours_8h,

        [Description("12h")]
        Hours_12h,

        [Description("1d")]
        Days_1d,

        [Description("3d")]
        Days_3d,

        [Description("1w")]
        Weeks_1w,

        [Description("1M")]
        Months_1M
    }
}
