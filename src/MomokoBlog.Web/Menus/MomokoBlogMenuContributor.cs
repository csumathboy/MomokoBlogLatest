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
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 2);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 3);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 4);

        // blog menu
        var blogMenu = new ApplicationMenuItem(
                MomokoBlogMenus.Home,
                l["Menu:Blog"],
                "~/",
                icon: "fas fa-blog",
                order: 1
            );

        var isPostGranted = context.IsGrantedAsync(MomokoBlogPermissions.Post.Default);

        if (isPostGranted.Result)
        {
            blogMenu.AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Post, l["Menu:Post"], "/Posts/Post")
            );
        }

        var isClassificationGranted = context.IsGrantedAsync(MomokoBlogPermissions.Classification.Default);

        if (isClassificationGranted.Result)
        {
            blogMenu.AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Classification, l["Menu:Classification"], "/Classifications/Classification")
            );
        }
        var isCommentGranted = context.IsGrantedAsync(MomokoBlogPermissions.Comment.Default);

        if (isCommentGranted.Result)
        {
            blogMenu.AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Comment, l["Menu:Comment"], "/Comments/Comment")
            );
        }
        var isTagGranted = context.IsGrantedAsync(MomokoBlogPermissions.Tag.Default);

        if (isTagGranted.Result)
        {
            blogMenu.AddItem(
                new ApplicationMenuItem(MomokoBlogMenus.Tag, l["Menu:Tag"], "/Tags/Tag")
            );
        }

        if(isClassificationGranted.Result||isCommentGranted.Result||isTagGranted.Result||isPostGranted.Result)
        {
            context.Menu.Items.Insert(1, blogMenu);
        }
        
        return Task.CompletedTask;
    }
}
