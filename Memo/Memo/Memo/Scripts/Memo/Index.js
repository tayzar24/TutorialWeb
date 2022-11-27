$(function () {
	$(document).ready(function () {
		loadData();
	});

	$("#addBtn").click(function () {
		var object = new Object();
		object.IsAddState = true;
		$.ajax({
			url: "/Home/AddEditStudentShow",
			type: "Post",
			contentType: "application/json;charset=utf-8",
			data: '{ input:'+ JSON.stringify(object) +'}',
			dataType: "json",
			success: function (result) {
				console.log(result);
				$("<div id='" + "exampleModalHoder" + "'></div>").appendTo('#DialogContainer');
				$("#exampleModalHoder").html(result.View);
				$("#exampleModal").modal('show');
			},
			error: function (errormessage) {
				alert(errormessage.responseText);
			}
		});
	});

	$(document).on('hidden.bs.modal', '#exampleModal', function () {
		$('#exampleModalHoder').remove();
	})

	function loadData() {
		$.ajax({
			url: "/Home/List",
			type: "GET",
			contentType: "application/json;charset=utf-8",
			dataType: "json",
			success: function (result) {
				var html = '';
				if (result.Success == true) {
					if (result.Students.length > 0) {
						$.each(result.Students.Students, function (key, item) {
							html += '<tr>';
							html += '<td>' + item.Name + '</td>';
							html += '<td>' + item.NRC + '</td>';
							html += '<td>' + item.Phone + '</td>';
							html += '<td>' + item.Address + '</td>';
							html += '<td>' + item.City + '</td>';
							html += '<td><a href="#" onclick="return getbyID(' + item.Name + ')"><i class="fa fa-edit"></i>&nbsp;Edit</a> | <a href="#" onclick="Delele(' + item.Name + ')" style="color:red;"><i class="fa fa-trash"></i>&nbsp;Delete</a></td>';
							html += '</tr>';
						});
					} else {
						html += '<tr>';
						html += '<td colspan="6" style="text-align:center;">Data Not Found!</td>';
						html += '</tr>';
					}
					
					$('.tbody').html(html);
				} else {
					showAlert("Error", "Data reloading fail!", "error");
				}
				
			},
			error: function (errormessage) {
				alert(errormessage.responseText);
			}
		});
	}

	
});