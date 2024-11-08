import { Component } from '@angular/core';

import { ShellComponent } from './core/components/shell/shell.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ShellComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}
