import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <h1>Support Helpdesk</h1>
    <app-ticket-list></app-ticket-list>
  `,
  styles: []
})
export class AppComponent {
  title = 'ticket-spa';
}
