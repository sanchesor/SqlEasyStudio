using SqlEasyStudio.PlaginGateway;

namespace SqlEasyStudio.PluginGateway
{
    public interface IPluginFormProvider
    {
        void Show(string formName);
        void Hide(string formName);
        void ToggleVisible(string formName);

        IPluginFormContainer FormContainer { get; }
    }
}
