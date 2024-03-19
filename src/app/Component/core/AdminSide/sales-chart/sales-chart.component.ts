import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
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
export class SalesChartComponent  implements OnInit , OnChanges {
  
  chart: any;

  constructor() { }
  ngOnChanges(changes: SimpleChanges): void {
    this.draw()
  }
   salesData : number[]= [15500,21500,18500,24000,23900,24000,12000,33798 , 1000 , 9001 , 19120 ,40000];
   Labels : string[]=["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
   minSalesValue:number = Math.min(...this.salesData);
  ngOnInit(): void {
    // Fetch sales data here (e.g., using HttpClient)
    //const salesData : number[]= [15500,21500,18500,24000,23900,24000,12000];
    
    //const salesData = [/* Your sales data here */];

    // Process data to get sales rate per day

    // Calculate the minimum value of sales data
    
    // Process data to get sales rate per day

    // Initialize chart
    this.draw()
   
  }
  draw(): void {
    // Destroy the existing chart instance if it exists
    if (this.chart) {
      this.chart.destroy();
    }
  
    this.chart = new Chart('canvas', {
      type: 'line',
      data: {
       // labels: ['SaturDay', 'SunDay', 'MonDay','Tuesday ','Wednesday ','Thursday ','Friday'],
        labels:this.Labels,
      //   datasets: [{
      //     label: "Earnings",
      //     pointRadius: 3,
      //     data: salesData,
      //     backgroundColor: '#675548',
      //     borderColor:'#675548', 
      //     // '#007bff',
      //     pointHitRadius: 10,
      // pointBorderWidth: 2,
      //     borderWidth: 3
      //   }],
        datasets: [{
          label: "Earnings",
          //lineTension: 0.3,
          backgroundColor: '#675548',
          borderColor:'#675548', 
          pointRadius: 3,
          // pointBackgroundColor: "rgba(78, 115, 223, 1)",
          // pointBorderColor: "rgba(78, 115, 223, 1)",
          pointHoverRadius: 3,
          pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
          pointHoverBorderColor: "rgba(78, 115, 223, 1)",
          pointHitRadius: 10,
          pointBorderWidth: 2,
          data:this.salesData 
          //[0, 10000, 5000, 15000, 10000, 20000, 15000, 25000, 20000, 30000, 25000, 40000],
        }],
      },
      options: {
        scales: {
          y: {
            type: 'linear',
            min: this.minSalesValue, // Set the minimum value of the y-axis scale
            beginAtZero: false 
          }
        }
      },

    });
  }
  

 

 
  onSelectionChange(event: any): void {
    // Update chart based on the selection here
    console.log(event.target.value)
    if (event.target.value === "This Week") {
      // Call a method to update the chart for "This Week"
      this.Labels=['SaturDay', 'SunDay', 'MonDay','Tuesday ','Wednesday ','Thursday ','Friday']
      this.salesData=[15500,21500,18500,24000,23900,24000,12000]
      this.draw()
     // this.weekselected = true;
      // Update the chart as necessary
   } else if (event.target.value === "This Year") {
      // Call a method to update the chart for "This Year"
      this.salesData = [15500,21500,18500,24000,23900,24000,12000,33798 , 1000 , 9001 , 19120 ,40000];
      this.Labels =["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
      //this.weekselected = false;
      this.draw()
      // Update the chart as necessary
    }
    //console.log(this.weekselected , "  " , this.yearselected);
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
