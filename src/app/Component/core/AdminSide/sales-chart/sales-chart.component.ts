import { Dashboard } from './../../../../models/dashboard';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
// import { ChartDataSets,  } from 'chart.js';
// import { Color, Label } from 'ng2-charts'

// // Or, depending on how ng2-charts exports types
// import { ChartOptions } from 'chart.js';
import { Chart } from 'chart.js/auto';
import { DashboardService } from 'src/app/services/dashboard.service';
@Component({
  selector: 'app-sales-chart',
  templateUrl: './sales-chart.component.html',
  styleUrls: ['./sales-chart.component.css']
})
export class SalesChartComponent implements OnInit, OnChanges {

  chart: any;
  //chart: any;
  salesData: number[] = [];
  Labels: string[] = [];
  minSalesValue: number = 0;
  constructor(private dashserv:DashboardService) { }
  ngOnChanges(changes: SimpleChanges): void {
    this.draw()
  }
  salesDataLabel : Dashboard[] = []
  // salesData: number[] = [];
  // Labels: number[] = []
  // minSalesValue: number = Math.min(...this.salesData);
  ngOnInit(): void {
  
    this.getProfitByWeek()

  }
  draw(): void {
    if (this.chart) {
      this.chart.destroy();
    }

    this.chart = new Chart('canvas', {
      type: 'line',
      data: {
        labels: this.Labels,
        datasets: [{
          label: "Earnings",
          backgroundColor: 'rgba(255, 181, 52, 0.3)',
          borderColor: '#FFB534',
          pointRadius: 2,
          pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
          pointHoverBorderColor: "rgba(78, 115, 223, 1)",
          pointHitRadius: 10,
          pointBorderWidth: 2,
          data: this.salesData,
          fill: 'origin'
        }],
      },
      options: {
        maintainAspectRatio: false,
        aspectRatio: 0.9,
        responsive: true,
        scales: {
          y: {
            ticks: {
              color: "#9f9f9f",
              maxTicksLimit: 5,
            },
            grid: {
              color: 'rgba(255,255,255,0.05)',
            },
            type: 'linear',
            min: this.minSalesValue,
            beginAtZero: false,
          },
          x: {
            ticks: {
              color: "#9f9f9f",
            },
            grid: {
              display: false,
            }
          }
        },
      },
    });
  }

  getProfitByWeek(): void {
    this.dashserv.getprofitByweek().subscribe((data) => {
      console.log("labels",data)
      this.Labels = data.map(item => item.timeInterval.toString());
      this.salesData = data.map(item => item.profit);
      this.minSalesValue = Math.min(...this.salesData);
      console.log("labels",this.Labels)
      
      console.log("sales",this.salesData)
      console.log("min sales",this.minSalesValue)

      this.draw();
    });
  }
  getProfitByYear(): void {
    this.dashserv.getprofitByYear().subscribe((data) => {
      this.Labels = data.map(item => item.timeInterval.toString());
      this.salesData = data.map(item => item.profit);
      this.minSalesValue = Math.min(...this.salesData);
      this.draw();
    });
  }

  onSelectionChange(event: any): void {
    if (event.target.value === "This Week") {
      this.getProfitByWeek();
    } else if (event.target.value === "This Year") {
      this.getProfitByYear();
    }
  }
}