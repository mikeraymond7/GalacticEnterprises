google.charts.load('current', { packages: ['corechart'] });

function totalSalesCharts() {
    // Instantiate Table
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Category');
    data.addColumn('number', 'Value');

    // Edit data for table format
    var x = document.getElementById("data").innerHTML;
    x = x.trim();
    if (x.charAt(0) == ",") {
        x = x.substring(1);
    }
    var z = x.replace(/"/g, "!");
    x = z.replace(/'/g, "~");

    z = x.replace(/~/g, '"');
    x = z.replace(/!/g, "'");

    var chartData = JSON.parse("[" + x + "]");
    data.addRows(chartData);

    // set options for each chart
    var options_pie = {
        title: 'Total Revenue Per Item',
        titleTextStyle: {
            color: "white",
            fontSize: 25
        },
        width: 700, height: 700,
        is3D: true,
        backgroundColor: "#003754",
        legend: {
            textStyle: { color: 'white', fontSize: 18 }
        }
    };
    /*var options_bar = {
        hAxis: {
            title: "Total Revenue"
        },
        vAxis: {
            title: "Item Name"
        },
        title: 'Total Revenue Per Item',
        legend: {position: 'bottom'}
    };
    var options_line = {
        curveType: 'function',
        legend: { position: 'bottom' },
        chartArea: {
            backgroundColor:  "#003754"

        }
    };
    */
    // Instantiate and draw each chart
    var pie = new google.visualization.PieChart(document.getElementById("pie"));
    pie.draw(data, options_pie);

    /*var bar = new google.visualization.BarChart(document.getElementById("bar"));
    bar.draw(data, options_bar);

    var line = new google.visualization.LineChart(document.getElementById("line"));
    line.draw(data, options_line);
    */

}