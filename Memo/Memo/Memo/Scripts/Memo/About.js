var sortName = "";
var sortDirection = "ASC";
$(function () {
	GetCustomers(1);
});
$("body").on("click", "#tblCustomers th a", function () {
	sortName = $(this).html();
	sortDirection = sortDirection == "ASC" ? "DESC" : "ASC";
	GetCustomers(1);
});
$("body").on("click", ".Pager .page", function () {
	GetCustomers(parseInt($(this).attr('page')));
});
function GetCustomers(pageIndex) {
	$.ajax({
		type: "POST",
		url: "/Home/StudentList",
		data: '{pageIndex: ' + pageIndex + ', sortName: "' + sortName + '", sortDirection: "' + sortDirection + '"}',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: OnSuccess,
		failure: function (response) {
			alert(response.d);
		},
		error: function (response) {
			alert(response.d);
		}
	});
};
function OnSuccess(response) {
	var model = response;
	console.log(response);
	var row = $("#tblCustomers tr:last-child").removeAttr("style").clone(true);
	$("#tblCustomers tr").not($("#tblCustomers tr:first-child")).remove();
	$.each(model.Students.Students, function () {
		var customer = this;
		$("td", row).eq(0).html(customer.Name);
		$("td", row).eq(1).html(customer.NRC);
		$("td", row).eq(2).html(customer.Phone);
		$("td", row).eq(3).html(customer.Address);
		$("#tblCustomers").append(row);
		row = $("#tblCustomers tr:last-child").clone(true);
	});

	$(".Pager").ASPSnippets_Pager({
		ActiveCssClass: "current",
		PagerCssClass: "pager",
		PageIndex: model.Students.Paging.PageIndex,
		PageSize: model.Students.Paging.PageSize,
		RecordCount: model.Students.Paging.RecordCount
	});
};