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
export class SalesChartComponent implements OnInit, OnChanges {

  chart: any;

  constructor() { }
  ngOnChanges(changes: SimpleChanges): void {
    this.draw()
  }
  salesData: number[] = [ 100,150,200,250,300,350, 400  ];
  Labels: string[] = ['السبت', 'الاحد', 'الاثنين', 'الثلاثاء', 'الاربعاء', 'الخميس', 'الجمعة']
  minSalesValue: number = Math.min(...this.salesData);
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
        // pointRadius: 3,
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
          backgroundColor: 'rgba(255, 181, 52, 0.3)', // Adjust the alpha value (0.3) to control transparency
          borderColor: '#FFB534',
         // pointStyle: 'circle', 
          pointRadius: 2, // Adjust the radius value as needed
          pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
          pointHoverBorderColor: "rgba(78, 115, 223, 1)",
          pointHitRadius: 10,
          pointBorderWidth: 2,
          data: this.salesData,
          fill: 'origin' // Fill the area below the line
          //[0, 10000, 5000, 15000, 10000, 20000, 15000, 25000, 20000, 30000, 25000, 40000],
        }],
      },
      options: {
        maintainAspectRatio: false, // Disable maintaining aspect ratio
        aspectRatio: 0.9, // Set the desired aspect ratio (width:height)
        responsive: true,
        scales: {
          y:
           {
            ticks: {
              color: "#9f9f9f",
              maxTicksLimit: 5,
               
            },
            grid: {
              color: 'rgba(255,255,255,0.05)', // Controls the color of the grid lines
              // Removed drawBorder since it's not recognized here
              // drawTicks:false,
              // //z:100
              // tickColor:"#ccc"
            },
            type:'linear'
            ,min:this.minSalesValue,
            beginAtZero:false,
            
          },
          x: {
            ticks: {
              color: "#9f9f9f",
            },
            grid: {
              display: false, // Can be used to hide the grid lines
              // Here too, drawBorder has been removed
            }
          }
        },
      },

    });


    // this.chart = new Chart('canvas', {
    //   type: 'line',
    //   data: {
    //     labels: this.Labels,
    //     datasets: [{
    //       label: "Earnings",
    //       borderColor: "#6bd098",
    //       backgroundColor: "#6bd098",
    //       pointRadius: 0,
    //       pointHoverRadius: 0,
    //       borderWidth: 3,
    //       data: this.salesData
    //     },
    //     // {
    //     //   borderColor: "#f17e5d",
    //     //   backgroundColor: "#f17e5d",
    //     //   pointRadius: 0,
    //     //   pointHoverRadius: 0,
    //     //   borderWidth: 3,
    //     //   data: [320, 340, 365, 360, 370, 385, 390, 384, 408, 420]
    //     // },
    //     // {
    //     //   borderColor: "#fcc468",
    //     //   backgroundColor: "#fcc468",
    //     //   pointRadius: 0,
    //     //   pointHoverRadius: 0,
    //     //   borderWidth: 3,
    //     //   data: [370, 394, 415, 409, 425, 445, 460, 450, 478, 484]
    //     // }
    //   ]
    //   },
    //   options: {
    //     plugins: {
    //       legend: {
    //         display: false
    //       },
    //       tooltip: {
    //         enabled: true
    //       }
    //     },
    //     scales: {
    //       y:
    //        {
    //         ticks: {
    //           color: "#9f9f9f",
    //           maxTicksLimit: 5,
              
    //         },
    //         grid: {
    //           color: 'rgba(255,255,255,0.05)', // Controls the color of the grid lines
    //           // Removed drawBorder since it's not recognized here
    //           // drawTicks:false,
    //           // //z:100
    //           // tickColor:"#ccc"
    //         },
    //         type:'linear'
    //         ,min:this.minSalesValue,
    //         beginAtZero:false,
            
    //       },
    //       x: {
    //         ticks: {
    //           color: "#9f9f9f",
    //         },
    //         grid: {
    //           display: false, // Can be used to hide the grid lines
    //           // Here too, drawBorder has been removed
    //         }
    //       }
    //     },
        
    //   }
    // });
    
  }





  onSelectionChange(event: any): void {
    // Update chart based on the selection here
    console.log(event.target.value)
    if (event.target.value === "This Week") {
      // Call a method to update the chart for "This Week"
      this.Labels = ['السبت', 'الاحد', 'الاثنين', 'الثلاثاء', 'الاربعاء', 'الخميس', 'الجمعة']
      this.salesData = [15500, 21500, 18500, 24000, 23900, 24000, 12000]
    this.minSalesValue= Math.min(...this.salesData);
      this.draw()
      // this.weekselected = true;
      // Update the chart as necessary
    } else if (event.target.value === "This Year") {
      // Call a method to update the chart for "This Year"
      this.salesData = [15500, 21500, 18500, 24000, 23900, 24000, 12000, 33798, 1000, 9001, 19120, 40000 ];
      this.Labels = ["يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو", "يوليو", "اغسطس", "سبتمبر", "اكتوبر", "نوفمبر", "ديسمبر"]
      //this.weekselected = false;
    this.minSalesValue= Math.min(...this.salesData);

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
