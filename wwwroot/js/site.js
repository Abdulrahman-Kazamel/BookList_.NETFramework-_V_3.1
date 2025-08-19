var dataTable;

$(document).ready(function(){
    
    // console.log("Test");
    loadDataTable();
    
    
});

function loadDataTable(){
    dataTable = $("#tableLoad").DataTable({
        "ajax":{
            "url": "/api/books",
            "type":"GET",
            "dataSrc": "data"

        },
        "columns": [
            {"data": "name","width":"20%"},
            {"data": "author","width":"20%"},
            {"data": "isbn","width":"20%"},
            {
                "data":"id",
                "render":function(data){
                    return `<div class="text-center">
                    <a href="/BookList/Edit?id=${data}" class="btn mx-2 btn-success text-white" style="cursor:pointer;width:40%;">Edit</a>
                    
                    <a  class="btn mx-2 btn-danger text-white" 
                    style="cursor:pointer;width:40%;"
                    onclick="Delete('/api/books/?id=' + ${data})">Delete</a>
                    
                    </div>`;
                },"width":"30%"
            }
        ],
        "language":{
            "emptyTable": "no data found"

        },"width":"70%"




    });
}

function Delete(url){
    swal({
        title: "Are you sure?",
        text: "Once Deleted, You will not be able to recover!!!",
        icon:"warning",
        dangerMode:true

    }).then((willDelete) => {
        if(willDelete){
            $.ajax({
                type: "DELETE",
                url:url,
                success: function(data){
                    if(data.success){
                        toastr.success(data.message);
                        dataTable.ajax.reload();

                    }
                    else{
                        toastr.error(data.message);
                    }
                } 


            });
        }

    });
}