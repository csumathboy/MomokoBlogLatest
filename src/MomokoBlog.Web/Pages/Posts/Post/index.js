$(function () {

    $("#PostFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#PostCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#PostFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/PostFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('MomokoBlog');

    var service = momokoBlog.posts.post;
    var createModal = new abp.ModalManager(abp.appPath + 'Posts/Post/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Posts/Post/EditModal');

    var dataTable = $('#PostTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getListByCondition,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('MomokoBlog.Post.Update'),
                                action: function (data) {
                                    window.location.href = '/Posts/Post/EditModal?id=' + data.record.id;        
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('MomokoBlog.Post.Delete'),
                                confirmMessage: function (data) {
                                    return l('PostDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('PostTitle'),
                data: "title"
            },
            {
                title: l('PostAuthor'),
                data: "author"
            },
            {
                title: l('PostClassId'),
                data: "className"
            },
            {
                title: l('PostPicture'),
                data: "picture"
            },
            {
                title: l('PostSort'),
                data: "sort"
            },
            {
                title: l('PostIsTop'),
                data: "isTop"
            },
            {
                title: 'PostPostTags',
                data: "postTagNames",
                render: function (data) {
                    return data.join(", ");
                }
            },
            {
                title: l('PostPostsStatus'),
                data: "postsStatus"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPostButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
