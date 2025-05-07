
namespace Naninovel.UI
{
    public class TitleInventoryButton : ScriptableButton
    {
        private IUIManager uiManager;

        protected override void Awake ()
        {
            base.Awake();

            uiManager = Engine.GetServiceOrErr<IUIManager>();
        }

        protected override void OnButtonClick () => uiManager.GetUI<ICGGalleryUI>()?.Show();
    }
}
