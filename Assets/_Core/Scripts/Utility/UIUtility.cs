using Better.Locators.Runtime;
using StartlingPlay.Services.UI;

namespace StartlingPlay.Utility
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