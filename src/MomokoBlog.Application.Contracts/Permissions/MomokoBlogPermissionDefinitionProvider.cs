using MomokoBlog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MomokoBlog.Permissions;

public class MomokoBlogPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MomokoBlogPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MomokoBlogPermissions.MyPermission1, L("Permission:MyPermission1"));

        var classificationPermission = myGroup.AddPermission(MomokoBlogPermissions.Classification.Default, L("Permission:Classification"));
        classificationPermission.AddChild(MomokoBlogPermissions.Classification.Create, L("Permission:Create"));
        classificationPermission.AddChild(MomokoBlogPermissions.Classification.Update, L("Permission:Update"));
        classificationPermission.AddChild(MomokoBlogPermissions.Classification.Delete, L("Permission:Delete"));

        var commentPermission = myGroup.AddPermission(MomokoBlogPermissions.Comment.Default, L("Permission:Comment"));
        commentPermission.AddChild(MomokoBlogPermissions.Comment.Create, L("Permission:Create"));
        commentPermission.AddChild(MomokoBlogPermissions.Comment.Update, L("Permission:Update"));
        commentPermission.AddChild(MomokoBlogPermissions.Comment.Delete, L("Permission:Delete"));

        var tagPermission = myGroup.AddPermission(MomokoBlogPermissions.Tag.Default, L("Permission:Tag"));
        tagPermission.AddChild(MomokoBlogPermissions.Tag.Create, L("Permission:Create"));
        tagPermission.AddChild(MomokoBlogPermissions.Tag.Update, L("Permission:Update"));
        tagPermission.AddChild(MomokoBlogPermissions.Tag.Delete, L("Permission:Delete"));

        var postPermission = myGroup.AddPermission(MomokoBlogPermissions.Post.Default, L("Permission:Post"));
        postPermission.AddChild(MomokoBlogPermissions.Post.Create, L("Permission:Create"));
        postPermission.AddChild(MomokoBlogPermissions.Post.Update, L("Permission:Update"));
        postPermission.AddChild(MomokoBlogPermissions.Post.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MomokoBlogResource>(name);
    }
}
