$(function () {

    $("#ClassificationFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#ClassificationCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#ClassificationFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/ClassificationFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('MomokoBlog');

    var service = momokoBlog.classifications.classification;
    var createModal = new abp.ModalManager(abp.appPath + 'Classifications/Classification/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Classifications/Classification/EditModal');

    var dataTable = $('#ClassificationTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('MomokoBlog.Classification.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('MomokoBlog.Classification.Delete'),
                                confirmMessage: function (data) {
                                    return l('ClassificationDeletionConfirmationMessage', data.record.id);
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
                title: l('ClassificationName'),
                data: "name"
            },
            {
                title: l('ClassificationDescription'),
                data: "description"
            },
            {
                title: l('ClassificationNickName'),
                data: "nickName"
            },
            {
                title: l('ClassificationArtCount'),
                data: "artCount"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewClassificationButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
