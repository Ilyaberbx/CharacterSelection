using Better.Locators.Runtime;
using StarlingPlay.Services.UI;

namespace StarlingPlay.Utility
{
    public static class UIUtility
    {
        private static readonly ServiceProperty<ScreenService> _serviceProperty = new();
        private static ScreenService ScreenService => _serviceProperty.CachedService;

        public static void CloseAll()
        {
            ScreenService.Close();
        }
    }
}