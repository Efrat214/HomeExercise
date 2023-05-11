import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { SharedServiceService } from '../shared-service.service';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent {

  public chart: any
  ngOnInit(): void {
    this.createChart();
  }
  constructor(private db:SharedServiceService){}
  async createChart() {
    this.db.getPositive().subscribe(data=>{
      console.log(data)
    //   const dates = Object.keys(data).map(key => new Date(key).toLocaleDateString(undefined, { day: 'numeric', month: 'short' }));
    // const counts = Object.values(data);
    // console.log(dates)
    const dataArray = Object.entries(data).map(([date, count]) => ({
      date: new Date(date),
      count: count
    }));

    // Sort the array by the date property
    dataArray.sort((a, b) => a.date.getTime() - b.date.getTime());

    // Create the dates and counts arrays from the sorted array
    const dates = dataArray.map(key => new Date(key.date).toLocaleDateString(undefined, { day: 'numeric', month: 'short' }));
    const counts = dataArray.map(obj => obj.count);


    // Create the chart
    
    this.chart = new Chart("MyChart", {
      type: 'line',
      data: {
        labels: dates,
        datasets: [{
          label: 'מספר החולים הפעילים',
          data: counts,
          backgroundColor: 'lightblue'
        }]
      },
     options: {
        aspectRatio:2.5
      }
    })
  
      
    });
  }

  ngOnDestroy(): void {
    if (this.chart) {
      this.chart.destroy();
    }
  }
  downloadChart() {
    // Convert the chart canvas to a base64-encoded image
    const base64Image = this.chart.toBase64Image();
  
    // Convert the base64-encoded image to a Blob object
    const blob = this.base64ToBlob(base64Image, 'image/png');
  
    // Create a download link for the image
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'chart.png';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
  
  base64ToBlob(base64:any, type:any) {
    const byteString = atob(base64.split(',')[1]);
    const ab = new ArrayBuffer(byteString.length);
    const ia = new Uint8Array(ab);
    for (let i = 0; i < byteString.length; i++) {
      ia[i] = byteString.charCodeAt(i);
    }
    return new Blob([ab], { type: type });
  }
  
  
  // createChart(){  
  //   this.chart = new Chart("MyChart", {
  //     type: 'line', //this denotes tha type of chart

  //     data: {// values on X-Axis
  //       labels: ['2022-05-10', '2022-05-11', '2022-05-12','2022-05-13',
	// 							 '2022-05-14', '2022-05-15', '2022-05-16','2022-05-17', ], 
	//        datasets: [
  //         {
  //           label: "active seeks",
  //           data: ['467','576', '572', '79', '92',
	// 							 '574', '573', '576'],
  //           backgroundColor: 'lightblue'
  //         }
  //       ]
  //     },
  //     options: {
  //       aspectRatio:2.5
  //     }
      
  //   });
  // }
}
