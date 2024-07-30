using Volo.Abp.Settings;

namespace MomokoBlog.Settings;

public class MomokoBlogSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MomokoBlogSettings.MySetting1));
    }
}
