using System.Threading.Tasks;
using MomokoBlog.Permissions;
using MomokoBlog.Localization;
using MomokoBlog.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace MomokoBlog.Web.Menus;

public class MomokoBlogMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<MomokoBlogResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MomokoBlogMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        var isClassificationGranted = context.IsGrantedAsync(MomokoBlogPermissions.Classification.Default);

        if (isClassificationGranted.Result)
        {
            context.Menu.GetAdministration().AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Classification, l["Menu:Classification"], "/Classifications/Classification")
            );
        }
        var isCommentGranted = context.IsGrantedAsync(MomokoBlogPermissions.Comment.Default);

        if (isCommentGranted.Result)
        {
            context.Menu.GetAdministration().AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Comment, l["Menu:Comment"], "/Comments/Comment")
            );
        }
        var isTagGranted = context.IsGrantedAsync(MomokoBlogPermissions.Tag.Default);

        if (isTagGranted.Result)
        {
            context.Menu.GetAdministration().AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Tag, l["Menu:Tag"], "/Tags/Tag")
            );
        }
        var isPostGranted = context.IsGrantedAsync(MomokoBlogPermissions.Post.Default);

        if (isPostGranted.Result)
        {
            context.Menu.GetAdministration().AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Post, l["Menu:Post"], "/Posts/Post")
            );
        }

        return Task.CompletedTask;
    }
}
