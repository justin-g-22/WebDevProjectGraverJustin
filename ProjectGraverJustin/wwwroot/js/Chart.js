google.charts.load('current', { packages: ['corechart'] })

function drawChart() {

    var data = google.visualization.arrayToDataTable([
        ['Occupation', 'Annual Salary($)', { role: 'style' }],
        ['Nurse', 63500, '#0095CC'],
        ['Doctor', 275000, '#881100'],
        ['Receptionist', 34000, '#111111'],
    ]);

    var options = {
        title: 'Average Worker Salaries'
    };

    var chart = new google.visualization.BarChart(document.getElementById('barchart'));

    chart.draw(data, options);
}

function drawChart2() {

    var data = google.visualization.arrayToDataTable([
        ['Sex', 'Percentage'],
        ['M', 4],
        ['F', 4],
    ]);

    var options = {
        title: ''
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);
}
