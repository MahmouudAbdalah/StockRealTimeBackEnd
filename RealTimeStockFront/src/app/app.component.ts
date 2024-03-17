import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']

})
export class AppComponent {
  title: string = 'Frontend Track 2022';

  sayHello(): string {
    return `Hello World, ${this.title}`
  }
}
