$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadProducts", function () {
        LoadProdData();
    })
    LoadProdData();

    function LoadProdData() {
        var tr = '';
        $.ajax({
            url: '/Home/GetProducts',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr +=
                        `<tr> 
                        <td> ${v.appUser.fullName}</td>
                        <td> ${v.title}</td>
                        <td> ${v.content.trim()}</td>
                        <td> ${v.createdDate}</td>
                        <td> ${v.updatedDate}</td>
                        <td> ${v.publishStatus == 1 ? `ok` : `Not ok`}</td>
                        <td> ${v.postCategory.categoryName}</td>
                        <td>
                            <a href='/Home/detail?id=${v.postId}'>Details</a> |
                            <a href='/Home/update?id=${v.postId}'>Edit</a> |
                            <a href='/Home/delete?id=${v.postId}'>Delete</a> 
                        </td>
                    </tr>`
                })
                $("#tablePost").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})