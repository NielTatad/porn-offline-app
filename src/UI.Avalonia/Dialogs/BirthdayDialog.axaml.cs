using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace UI.Avalonia.Dialogs;

public partial class BirthdayDialog : Window
{
    public BirthdayDialog()
    {
        InitializeComponent();
    }

    private void OnOk(object? sender, RoutedEventArgs e)
    {
        var picker = this.FindControl<DatePicker>("DatePicker");
        if (picker?.SelectedDate is DateTimeOffset dto)
        {
            Close(dto.Date);
        }
        else
        {
            Close(null);
        }
    }
}


