import { NgIf, AsyncPipe, NgForOf } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { ListagemCategoria } from '../../categorias/models/categoria.models';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-filtro-categorias',
  standalone: true,
  imports: [NgIf, NgForOf, MatChipsModule],
  template: `
    <mat-chip-listbox>
      <mat-chip-option (click)="filtrar()" selected
        >Todas as notas</mat-chip-option
      >

      <mat-chip-option
        *ngFor="let categoria of categorias"
        (click)="filtrar(categoria.id)"
        >{{ categoria.titulo }}</mat-chip-option
      >
    </mat-chip-listbox>
  `,
})
export class FiltroCategoriasComponent {
  @Input({ required: true }) categorias: ListagemCategoria[];

  @Output() filtroAcionado: EventEmitter<number | undefined>;

  constructor() {
    this.categorias = [];

    this.filtroAcionado = new EventEmitter();
  }

  filtrar(categoriaId?: number) {
    this.filtroAcionado.emit(categoriaId);
  }
}
