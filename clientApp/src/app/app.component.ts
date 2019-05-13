import { Component, Renderer2, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  sidebarOpened: boolean = false;

  constructor(private renderer: Renderer2) { }

  toggleMenu() {
    this.sidebarOpened = !this.sidebarOpened;
    this.sidebarOpened ? this.renderer.setStyle(document.body, 'overflow', 'hidden') : this.renderer.setStyle(document.body, 'overflow', 'auto');
  }
}
