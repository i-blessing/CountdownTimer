import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { interval, Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public inventory?: Inventory;
  public timers?: Timer[];

  constructor(http: HttpClient) {
    this.getInventory(http);
    this.getTimers(http);
  }

  getInventory(http: HttpClient) {
    http.get<any>('https://localhost:44360/api/inventory').subscribe(result => {
      this.inventory = result.inventory;
    }, error => console.error(error));
  }

  getTimers(http: HttpClient) {
    http.get<any>('https://localhost:44360/api/timer').subscribe(result => {
      this.timers = result.timers;
    }, error => console.error(error));
  }

  public startTimer(t: Timer) {
    var startDate = new Date();
    var endDate = new Date();
    endDate.setSeconds(startDate.getSeconds() + t.duration);

    t.isRunning = true;
    t.startTime = startDate;
    t.endTime = endDate;
    const intervalId = setInterval(() => {
      this.updateTimer(t, intervalId);
    }, 1000);
  }

  public updateTimer(t: Timer, intervalId: any) {
    t.diff = Date.parse(t.endTime.toISOString()) - Date.parse(new Date().toString());
    const days = Math.floor(t.diff / (1000 * 60 * 60 * 24));
    const hours = Math.floor((t.diff / (1000 * 60 * 60)) % 24);
    const minutes = Math.floor((t.diff / 1000 / 60) % 60);
    const seconds = Math.floor((t.diff / 1000) % 60);

    if (days >= 0 && hours >= 0 && minutes >= 0 && seconds >= 0) {
      const str = days + "d " + hours + "h " + minutes + "min " + seconds + "sec";
      t.countDown = str;
    }
    else {
      t.isRunning = false;
      t.isDone = true;
      clearInterval(intervalId);
    }
  }

  title = 'countdown-timer-webapp';
}

// Inventory
interface Inventory {
  items: Item[]
}

interface Item {
  id: number;
  description: string;
  count: number;
}

// Timers
interface Timer {
  id: number,
  name: string,
  isRunning: boolean,
  duration: number,
  startTime: Date,
  endTime: Date,
  countDown: string,
  diff: number,
  isDone: boolean
}
