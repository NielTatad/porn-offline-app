using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace UI.Avalonia.Converters;

public sealed class BoolToStarConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b && b ? "⭐" : "☆";

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is string s && s == "⭐";
}


