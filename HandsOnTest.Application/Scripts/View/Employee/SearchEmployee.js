function SearchEmployee() {

    this.Search = function () {

        var data = $("#txtId").val();

        $.ajax({
            url: '/Employee/Search',
            type: "POST",
            dataType: "JSON",
            data: {data},
            success: function (data) {
                if (data.Result) {
                    $("#tblInformation").empty();

                    $.each(data.Response, function (i, item) {
                        $("<tr> <td>" + item.Id +
                            "</td><td>" + item.Name +
                            "</td><td>" +item.ContractTypeName +
                            "</td><td>" + item.RoleId +
                            "</td><td>" + item.RoleName +
                            "</td><td>" + item.RoleDescription +
                            "</td><td>" + (item.HourlySalary).toLocaleString() +
                            "</td><td>" + (item.MonthlySalary).toLocaleString() +
                            "</td><td>" +(item.AnnualSalary).toLocaleString()+
                            "</td></tr>").appendTo("#tblInformation");
                    });
                }
                else {
                    $("#tblInformation").empty();
                    alert(data.Message);
                }
            }
        });

        $("#txtId").val("");
    };

}


var objSearch = new SearchEmployee();


$(document).ready(function () {
    $("#btnSearch").click(function () {
        objSearch.Search();
    });
});