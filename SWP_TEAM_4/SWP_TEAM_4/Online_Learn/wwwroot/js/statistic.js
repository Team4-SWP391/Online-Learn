$(document).ready(function () {
    $('#menu').click(function () {
        let width = document.getElementById('sidenav').clientWidth;
        if (width === 0) {
            $('#sidenav').css("width", "320px");
            $('#chart').css({
                "left": "350px"
            })
        } else {
            $('#sidenav').css("width", "0px");
            $('#chart').css({
                "left": "250px"
            })
        }
    });

    //Get BestSeller Course
    $('#bestSeller').click(function (event) {
        event.preventDefault();
        $('#bestSeller').addClass("active");
        $('#revenue').removeClass("active");
        $('#topUsers').removeClass("active");
        GetBestSellCourses();
    });
    function GetBestSellCourses() {
        $.ajax({
            type: "get",
            url: "/Statistic/GetBestSellCourses",
            dataType: "JSON",
            success: function (result) {
                google.charts.load('current', {
                    'packages': ['corechart']
                });

                google.charts.setOnLoadCallback(function () {
                    drawChart1(result);
                });
            }
        });
    }

    function drawChart1(result) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'name');
        data.addColumn('number', 'amount')
        var dataArray = [];
        $.each(result, function (i, obj) {
            dataArray.push([obj.courseName, obj.count]);
        });
        data.addRows(dataArray.reverse());
        var column_options = {
            legend: 'center',
            title: 'Top 5 Best Seller Courses',
            width: 1200,
            height: 600,
            hAxis: { title: 'Quantity (unit: courses)' }

           
        };
        var columnchart = new google.visualization.ColumnChart(document.getElementById('chart'));
        columnchart.draw(data, column_options);
    };

    //Get Top Users
    $('#topUsers').click(function (event) {
        event.preventDefault();
        $('#bestSeller').removeClass("active");
        $('#revenue').removeClass("active");
        $('#topUsers').addClass("active");
        GetTopUsers();
    });
    function GetTopUsers() {
        $.ajax({
            type: "get",
            url: "/Statistic/GetTopUsers",
            dataType: "JSON",
            success: function (result) {
                google.charts.load('current', {
                    'packages': ['corechart']
                });

                google.charts.setOnLoadCallback(function () {
                    drawChart2(result);
                });
            }
        });
    }
    function drawChart2(result) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'name');
        data.addColumn('number', 'amount')
        var dataArray = [];
        $.each(result, function (i, obj) {
            dataArray.push([obj.username, obj.totalPrice]);
        });
        data.addRows(dataArray.reverse());
        var columnchart_options = {
            legend: 'center',
            title: 'Top 5 Users',
            width: 1200,
            height: 600,
            vAxis: { title: 'Total payment (unit: dollar)' },
            hAxis: { title: 'Username' }
        };
        var columnchart = new google.visualization.ColumnChart(document.getElementById('chart'));
        columnchart.draw(data, columnchart_options);
    };

    //Get Revenue by month
    $('#revenue').click(function (event) {
        event.preventDefault();
        $('#bestSeller').removeClass("active");
        $('#revenue').addClass("active");
        $('#topUsers').removeClass("active");
        GetRevenueByMonth();
    });
    function GetRevenueByMonth() {
        $.ajax({
            type: "get",
            url: "/Statistic/GetRevenueMonthly",
            dataType: "JSON",
            success: function (result) {
                google.charts.load('current', {
                    'packages': ['corechart']
                });

                google.charts.setOnLoadCallback(function () {
                    drawChart3(result);
                });
            }
        });
    }
    function drawChart3(result) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'name');
        data.addColumn('number', 'amount')
        var dataArray = [];
        $.each(result, function (i, obj) {
            dataArray.push([`${obj.month}/${obj.year}`, obj.revenueMonth]);
        });
        data.addRows(dataArray);
        var columnchart_options = {
            legend: 'center',
            title: 'Revenue by Month',
            width: 1200,
            height: 600,
            hAxis: { title: 'Unit: dollar' }
        };
        var columnchart = new google.visualization.ComboChart(document.getElementById('chart'));
        columnchart.draw(data, columnchart_options);
    };
})




