using BiliLite.Models.Common;
using BiliLite.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BiliLite.Controls.Settings
{
    public sealed partial class FocusModeSettingControl : UserControl
    {
        // 用于保存专注模式状态的变量
        public bool IsFocusModeEnabled { get; set; }

        public FocusModeSettingControl()
        {
            this.InitializeComponent();
            // 读取持久化配置
            swFocusMode.IsOn = SettingService.GetValue<bool>(SettingConstants.Other.FOCUS_MODE_ENABLED, false);
            IsFocusModeEnabled = swFocusMode.IsOn;
            swFocusMode.Toggled += SwFocusMode_Toggled;
        }
        private void SwFocusMode_Toggled(object sender, RoutedEventArgs e)
        {
            // 根据ToggleSwitch的状态更改变量
            IsFocusModeEnabled = swFocusMode.IsOn;
            // 持久化保存配置
            SettingService.SetValue(SettingConstants.Other.FOCUS_MODE_ENABLED, IsFocusModeEnabled);
        }
    }
}