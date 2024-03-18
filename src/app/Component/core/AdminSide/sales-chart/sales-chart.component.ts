import { Component, OnInit } from '@angular/core';
// import { ChartDataSets,  } from 'chart.js';
// import { Color, Label } from 'ng2-charts'

// // Or, depending on how ng2-charts exports types
// import { ChartOptions } from 'chart.js';
import { Chart } from 'chart.js/auto'; 
@Component({
  selector: 'app-sales-chart',
  templateUrl: './sales-chart.component.html',
  styleUrls: ['./sales-chart.component.css']
})
export class SalesChartComponent  implements OnInit {
  
  chart: any;

  constructor() { }

  ngOnInit(): void {
    // Fetch sales data here (e.g., using HttpClient)
    const salesData : number[]= [15500,21500,18500,24000,23900,24000,12000];
    //const salesData = [/* Your sales data here */];

    // Process data to get sales rate per day

    // Calculate the minimum value of sales data
    const minSalesValue = Math.min(...salesData);
    // Process data to get sales rate per day

    // Initialize chart
    this.chart = new Chart('canvas', {
      type: 'line',
      data: {
        labels: ['SaturDay', 'SunDay', 'MonDay','Tuesday ','Wednesday ','Thursday ','Friday'],
        datasets: [{
          label: 'Sales ',
          data: salesData,
          backgroundColor: '#675548',
          borderColor:'#675548', 
          // '#007bff',
          borderWidth: 3
        }]
      },
      options: {
        scales: {
          y: {
            type: 'linear',
            min: minSalesValue, // Set the minimum value of the y-axis scale
            beginAtZero: false 
          }
        }
      }
    });
  }
  weekselected : boolean = true
  yearselected : boolean = false
  weekcheck(){
    this.weekselected = true;
    this.yearselected = false
  }
  yaercheck(){
    this.weekselected = false;
    this.yearselected = true
  }

  // chart: any;
  // weekselected: boolean = true;

  // constructor() { }

  // ngOnInit(): void {
  //   this.initChart();
  // }

  // initChart(): void {
  //   const salesData: number[] = [15500,21500,18500,24000,23900,24000,12000];
  //   this.chart = new Chart('canvas', {
  //     type: 'line',
  //     data: {
  //       labels: ['Saturday', 'Sunday', 'Monday','Tuesday', 'Wednesday', 'Thursday', 'Friday'],
  //       datasets: [{
  //         label: 'Sales',
  //         data: salesData,
  //         backgroundColor: '#675548',
  //         borderColor: '#675548',
  //         borderWidth: 3
  //       }]
  //     },
  //     options: {
  //       scales: {
  //         y: {
  //           beginAtZero: false 
  //         }
  //       }
  //     }
  //   });
  // }

  onSelectionChange(event: any): void {
    // Update chart based on the selection here
    if (event.target.value === "This Week") {
      // Call a method to update the chart for "This Week"
      this.weekselected = true;
      // Update the chart as necessary
    } else if (event.target.value === "This Year") {
      // Call a method to update the chart for "This Year"
      this.weekselected = false;
      // Update the chart as necessary
    }
  } 
  // public lineChartData: ChartDataSets[] = [
  //   { data: [65, 59, 80, 81, 56, 55, 40], label: 'Sales' },
  // ];
  // public lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
  // public lineChartOptions: ChartOptions = {
  //   responsive: true,
  // };
  
  // public lineChartColors: Color[] = [
  //   {
  //     borderColor: 'black',
  //     backgroundColor: 'rgba(255,0,0,0.3)',
  //   },
  // ];
  // public lineChartLegend = true;
  // public lineChartType = 'line';
  // public lineChartPlugins = [];
  // view: any;
  // colorScheme: any;
  // multi: any[];
  // gradient: boolean;
  // showLegend: boolean;
  // showXAxis: boolean;
  // showYAxis: boolean;
  // showXAxisLabel: boolean;
  // showYAxisLabel: boolean;
  // xAxisLabel: string;
  // yAxisLabel: string;
  // autoScale: boolean;
}

// import { Component } from '@angular/core';
// import { ChartDataSets, ChartOptions } from 'chart.js';
// import { Color, Label } from 'ng2-charts';

// @Component({
//   selector: 'app-sales-chart',
//   templateUrl: './sales-chart.component.html',
//   styleUrls: ['./sales-chart.component.css']
// })
// export class SalesChartComponent {
//   public lineChartData: ChartDataSets[] = [
//     { data: [65, 59, 80, 81, 56, 55, 40], label: 'Sales' },
//   ];
//   public lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
//   public lineChartOptions: (ChartOptions & { annotation: any }) = {
//     responsive: true,
//   };
//   public lineChartColors: Color[] = [
//     {
//       borderColor: 'black',
//       backgroundColor: 'rgba(255,0,0,0.3)',
//     },
//   ];
//   public lineChartLegend = true;
//   public lineChartType = 'line';
//   public lineChartPlugins = [];
// }
